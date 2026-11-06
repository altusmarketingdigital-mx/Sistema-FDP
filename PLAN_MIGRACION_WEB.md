# Plan de migración a Web — AppElyonVentas (Frutería del Puerto)

Fecha: 2026-11-05

## 1. Diagnóstico del sistema actual

### 1.1 Arquitectura

```
WinForms (AppElyonCXC, .NET 4.0)
   │  serializa el modelo a XML
   ▼
ElyonModelCxC  ──SOAP──►  WebElyonCxC (ASMX: WsCxC.asmx, WsCuentasC.asmx)
                                  │  switch(strTipo) con ~156 "case"
                                  ▼
                          ElyonManagerCxC (SqlHelper + Stored Procedures)
                                  ▼
                 SQL Server: ELYON_dbPermisosV (seguridad) + Tss_Inventario (negocio)
```

| Proyecto | Rol | Tamaño aprox. |
|---|---|---|
| `AppElyonCXC` | UI WinForms, ~65 pantallas, Crystal Reports, impresión de tickets | ~150 archivos |
| `ElyonModelCxC` | Modelos + proxies SOAP + `SQLHelper` | ~8,500 líneas |
| `ElyonManagerCxC` | Lógica de acceso a datos (solo SPs, sin SQL en línea) | ~6,000 líneas |
| `WebElyonCxC` | Servicios ASMX genéricos (`dsObtener(strXML, strTipo)`) | ~1,250 líneas |
| `Tss_Pedido_Fruteria_Del_Puerto` | Instalador (.vdproj) | — |

**Punto a favor:** toda la lógica de datos ya vive en **~140 stored procedures**. El backend nuevo puede reutilizarlos casi sin cambios.

### 1.2 Módulos funcionales (pantallas)

| Módulo | Pantallas | Notas |
|---|---|---|
| Pedidos | 7 | `Frm_GenerarPedido` (1,324 líneas) es el núcleo: captura, folios, días de crédito, conversión a nota de remisión |
| Cliente / Pagos | 1 | Registro de pago de cliente (612 líneas) |
| Cancelar documentos | 2 | Cancelación de notas de remisión |
| Catálogos | 10 | Clientes, productos, proveedores, grupos, departamentos, historiales, carga masiva de productos |
| Inventario | 1 | Inventario inicial por producto |
| Administración (CxC) | 12 | Clientes, empresas, estado de cuenta, búsquedas, permisos |
| Cargas | 2 | Bancos, cargos de banco |
| Reportes | 9 | Crystal Reports: bancos, clientes, empresas, vendedores, movimientos, tickets de pedido y remisión |
| Mantenimiento / Seguridad | 20 | Usuarios, menús, accesos, niveles de seguridad, avisos, notificaciones, parámetros, **respaldos (SMO)**, conexiones |
| Configuración | 1 | Datos del contribuyente |

El menú es **dinámico**: se carga de BD (`sp_MenuPorUsuario`) y abre cada formulario por nombre con `Activator.CreateInstance`. En web, cada entrada de menú se mapea a una ruta.

### 1.3 Dependencias que NO pasan tal cual a web

| Dependencia | Problema en web | Reemplazo propuesto |
|---|---|---|
| Crystal Reports (8 `.rpt`) | No corre en .NET 8 ni en navegador | Vista de impresión HTML limpia (regla PDF de Elyon Web) o PDF en servidor (QuestPDF) |
| Impresión de ticket (`Ticket.cs`, `PrintDocument`, impresoras configuradas por equipo) | El navegador no elige impresora ni manda directo a la térmica | Opción A: vista HTML 80 mm + `window.print()`. Opción B: endpoint de impresión en el agente local (`Elyon.CajaAgent` ya existe para la terminal de tarjeta) |
| Excel Interop (`UcGrid.cs`) | Requiere Office instalado | Exportar a Excel en el cliente (SheetJS) o en servidor (ClosedXML) |
| SMO / respaldos de BD (`FrmRespados`) | No debe hacerse desde una web | Sacar del sistema: job de SQL Agent administrado por TI |
| Configuración local (`app.config`, impresoras por usuario) | No existe en web | Configuración por usuario/caja en BD |
| SOAP/ASMX + XML genérico | Contrato opaco, difícil de asegurar | REST con endpoints tipados y JWT |

### 1.4 Riesgos y hallazgos

1. **Credenciales en texto plano** en `app.config` y `Web.config` (usuario `sa`). Hay que cambiar esas contraseñas y no llevarlas al repositorio nuevo.
2. **No hay scripts de BD** en el repositorio (tablas ni SPs de `Tss_Inventario`). Hay que extraerlos del servidor antes de empezar.
3. **Archivos ilegibles** en disco: `AppElyonCXC/Form1.Designer.cs` y `AppElyonCXC/frmAniversario.cs` dan error de E/S. Parecen secundarios, pero hay que recuperarlos de otra copia o confirmar que no se usan.
4. La carpeta no es repositorio git: no hay historial.
5. Lógica de negocio mezclada en los formularios (cálculos de totales, descuentos, validaciones en `Frm_GenerarPedido`, `Frm_Registrar_Pago_Cliente`). Hay que extraerla y documentarla con cuidado: es donde está el riesgo funcional.
6. La autenticación usa un esquema propio (`Encripta.cs`, `spr_VerificaUsuario`) sobre `ELYON_dbPermisosV`, que es una base de seguridad tipo Elyon.

## 2. Arquitectura destino (recomendada)

**Decisión tomada (2026-11-05): aplicación independiente**, con su propio repositorio, login, menú y despliegue. Usa el mismo stack que **Elyon Web** (`E:\ELYON WEB`) y copia sus patrones, pero no depende de `ApiSeguridad` ni comparte código con ese proyecto.

- **Frontend:** Next.js 14 (App Router) + TypeScript + React (`web-elyon-ventas/`).
- **Backend:** una sola **.NET 8 Web API** (`ApiVentas/`) con `Microsoft.Data.SqlClient` llamando a los **mismos stored procedures**. Controllers por módulo: Auth, Seguridad, Catálogos, Pedidos, Remisiones, Pagos, Inventario, Reportes.
- **Seguridad propia:** JWT emitido por `ApiVentas`. Se reutiliza la base `ELYON_dbPermisosV` y sus SPs (`spr_VerificaUsuario`, `sp_MenuPorUsuario`, `spCargaBotonesUsuarioMenu`, etc.). La validación de contraseña con `Encripta.cs` se porta tal cual para no obligar a reiniciar contraseñas; más adelante se puede migrar a BCrypt al iniciar sesión.
- **Configuración y secretos:** cadenas de conexión y llave JWT fuera del repositorio (variables de entorno o `appsettings.Production.json` solo en el servidor), con un usuario SQL de permisos mínimos en lugar de `sa`.
- **BD:** SQL Server existente (`Tss_Inventario` + `ELYON_dbPermisosV`). Los cambios de SP se versionan en `db/` dentro del repositorio y se registran en `PENDIENTES_PRODUCCION.md`.
- **Impresión de tickets:** vista HTML de 80 mm + `window.print()` en la primera versión. Si se necesita imprimir directo sin diálogo, se hace un agente local pequeño, tomando como modelo `Elyon.CajaAgent`.
- **Despliegue:** IIS: un sitio para la API y otro para el frontend (Node). Se puede adaptar `GUIA_DESPLIEGUE_IIS.md` de Elyon Web.

Estructura del repositorio:

```
AppElyonVentasWeb/
  ApiVentas/            .NET 8 Web API
  web-elyon-ventas/     Next.js
  db/                   scripts de tablas y SPs (línea base + cambios)
  docs/                 inventario funcional, manuales
  legacy/               código WinForms actual (solo consulta)
```

## 3. Plan de trabajo por fases

Estimaciones para **1 desarrollador full-stack**; son orientativas y se ajustan tras la Fase 0.

### Fase 0 — Preparación (1 semana)
- [ ] Crear repositorio git y subir el código actual tal como está (línea base).
- [ ] Recuperar o descartar `Form1.Designer.cs` y `frmAniversario.cs`.
- [ ] Extraer de SQL Server el script de `Tss_Inventario` y los SPs de `ELYON_dbPermisosV` que usa la app.
- [ ] Cambiar las contraseñas expuestas (`sa`) y quitarlas de los config.
- [ ] Inventario funcional: por cada pantalla, qué SP usa, qué valida y qué imprime (tabla `pantalla → strTipo → SP`). Base: los `case` de `WsCxC.cs` y `WsCuentasC.cs`.
- [ ] Crear usuario SQL de permisos mínimos para la API (solo `EXECUTE` sobre los SPs necesarios).

### Fase 1 — Fundaciones y seguridad propia (2–3 semanas)
- [ ] Crear `ApiVentas` (.NET 8): estructura, Swagger, manejo de errores, logging, CORS para el frontend.
- [ ] Autenticación: login contra `spr_VerificaUsuario` + `Encripta.cs` portado, emisión y refresco de JWT, cambio y recuperación de contraseña (SMTP).
- [ ] Autorización: menú por usuario (`sp_MenuPorUsuario`) y botones por menú; política de permisos en API y frontend.
- [ ] Mapear cada formulario del menú en BD (nombre `Frm...`) a una ruta web.
- [ ] Frontend: proyecto Next.js, layout, login, menú dinámico, guardas de permisos (`hasPermission`).
- [ ] Componentes base: tabla con búsqueda/paginación/exportar a Excel, formulario CRUD, buscador modal (sustituye a los `FrmBusca*`), vista de impresión.

### Fase 2 — Catálogos (2–3 semanas)
- [ ] Productos (incluye combos de medida y peso), grupos, departamentos, proveedores.
- [ ] Clientes (CRUD, bitácora, historial) y carga masiva de productos (subir archivo a la API).
- [ ] Empresas, vendedores, bancos y relaciones vendedor-cliente/empresa.
- [ ] Datos del contribuyente.

### Fase 3 — Operación de ventas (3–4 semanas) ⚠️ núcleo
- [ ] Generar pedido: captura de productos, folio, días de crédito, totales y descuentos (portar exactamente la lógica de `Frm_GenerarPedido`).
- [ ] Buscar y actualizar pedido.
- [ ] Convertir pedido a nota de remisión.
- [ ] Ticket de pedido y de nota de remisión (vista 80 mm).
- [ ] Inventario inicial por producto.

### Fase 4 — Cuentas por cobrar (2 semanas)
- [ ] Registrar pago de cliente + boleta de pago.
- [ ] Estado de cuenta del cliente.
- [ ] Cancelación de notas de remisión (con permisos y motivo).
- [ ] Búsquedas de notas, pagos y pedidos; reimpresión de documentos.

### Fase 5 — Reportes (1–2 semanas)
- [ ] Reemplazar los 8 Crystal Reports: movimientos, clientes, empresas, vendedores, bancos y tickets.
- [ ] Exportación a PDF/Excel.

### Fase 6 — Administración (2–3 semanas)
- [ ] Usuarios (alta, datos, foto), aplicaciones, menús, botones por menú, accesos y niveles de seguridad.
- [ ] Avisos, notificaciones, parámetros y tipos de proceso.
- [ ] Bitácora de uso y usuarios conectados.
- [ ] Retirar del alcance: respaldos SMO y "conexiones WS".

### Fase 7 — Pruebas, piloto y salida (2 semanas)
- [ ] Pruebas en paralelo: mismos pedidos/pagos en escritorio y web, comparar totales y folios.
- [ ] Pruebas de impresión en las impresoras reales de la tienda.
- [ ] Piloto con 1–2 usuarios, corrección de hallazgos.
- [ ] Despliegue en IIS (API + frontend), HTTPS, manual de usuario, capacitación.
- [ ] Retiro de la versión de escritorio y de los servicios ASMX.

**Total estimado:** 16–21 semanas (≈ 4–5 meses) con un desarrollador. Es un poco más que integrarlo en Elyon Web porque la seguridad y la administración se construyen dentro de esta app.

## 4. Orden de entrega sugerido

Entregar valor pronto sin romper la operación: la app de escritorio sigue funcionando sobre la misma BD mientras la web crece. Orden: Login/menú → Catálogos → Pedidos y tickets → Pagos/CxC → Reportes → Administración. Como ambas comparten los SPs, pueden convivir durante la transición.

## 5. Criterios de "terminado" por pantalla

- Usa los mismos SPs (o versiones nuevas registradas en pendientes de producción).
- Botones registrados en `ELYON_dbPermisosV` y protegidos con permiso en API y frontend.
- Imprime solo el contenido (sin layout) y la ventana se cierra sola.
- Probada contra el resultado de la versión de escritorio con los mismos datos.
- Guía de ayuda de la pantalla.
