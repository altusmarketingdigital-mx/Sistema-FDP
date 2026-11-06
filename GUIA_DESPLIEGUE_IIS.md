# 🚀 Guía de Despliegue en Producción — IIS & Node.js

**Proyecto:** AppElyonVentas Web (Frutería del Puerto / Cuentas por Cobrar)  
**Fecha:** 2026-11-06  
**Versión:** 1.0.0 Release

---

## 1. Arquitectura de Despliegue

```
Servidor Windows Server con IIS
├── Sitio 1: ApiVentas (Puerto 5050 o HTTPS :443/api)
│   ├── Runtime: ASP.NET Core Hosting Bundle (.NET 8)
│   ├── Origen: D:\Personales\AppElyonVentas-master\publish\api\
│   └── Base de Datos: SQL Server Local / Remoto
│
└── Sitio 2: Frontend Web (Puerto 3050 o HTTPS :443)
    ├── Runtime: Node.js (Servicio Windows vía PM2 o iisnode / Reverse Proxy)
    ├── Origen: D:\Personales\AppElyonVentas-master\frontend\web-elyon-ventas\
    └── Build: .next/ optimizado (npm run start)
```

---

## 2. Pasos para Desplegar la API en IIS

### Requisitos Previos:
* Instalar **.NET 8 Hosting Bundle** (incluye IIS AspNetCoreModuleV2).
* Habilitar el rol de **IIS** con soporte de WebSockets y autenticación anónima.

### Configuración del Sitio en IIS:
1. Abrir **Administrador de IIS**.
2. Crear un nuevo Grupo de Aplicaciones:
   - **Nombre:** `AppPool_ApiVentas`
   - **Versión de .NET CLR:** `Sin código administrado` (No Managed Code)
   - **Modo de canalización administrada:** `Integrada`
3. Crear un nuevo Sitio Web:
   - **Nombre del sitio:** `ApiVentas`
   - **Grupo de aplicaciones:** `AppPool_ApiVentas`
   - **Ruta de acceso física:** `D:\Personales\AppElyonVentas-master\publish\api`
   - **Enlace:** Puerto `5050` o enlace a subdominio/SSL.

### Archivo `web.config` generado automáticamente en `publish\api`:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet" arguments=".\ApiVentas.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
```

---

## 3. Pasos para Desplegar el Frontend (Next.js)

### Opción Recomendada (Servicio de fondo con PM2):
1. Instalar PM2 de manera global:
   ```bash
   npm install -g pm2
   ```
2. Iniciar el servicio desde la carpeta del frontend:
   ```bash
   cd D:\Personales\AppElyonVentas-master\frontend\web-elyon-ventas
   pm2 start npm --name "elyon-web" -- start -- -p 3050
   pm2 save
   ```
3. Para iniciar automáticamente al encender el servidor:
   ```bash
   pm2-startup install
   ```

### Enrutamiento inverso en IIS (URL Rewrite + ARR):
Si se desea servir el frontend por el puerto estándar 80/443 de IIS, se puede configurar una regla de Reverse Proxy hacia `http://localhost:3050`.

---

## 4. Configuración de Base de Datos y Credenciales

* El usuario técnico en SQL Server es **`usr_elyon_api`**, el cual cuenta estrictamente con permisos `GRANT EXECUTE` sobre los Stored Procedures.
* La cadena de conexión en producción se encuentra en `appsettings.json`:
  ```json
  "ConnectionStrings": {
    "Inventario": "Server=localhost;Database=Tss_Inventario;User Id=usr_elyon_api;Password=Ely0n_V3ntas#2026!Sec;TrustServerCertificate=True;",
    "Seguridad": "Server=localhost;Database=ELYON_dbPermisosV;User Id=usr_elyon_api;Password=Ely0n_V3ntas#2026!Sec;TrustServerCertificate=True;"
  }
  ```

---

## 5. Validación y Criterios de Éxito en Producción

- [x] Login con usuario `luiscastro` validando contra `spr_VerificaUsuario`.
- [x] Generación de pedidos y reserva de folios correlativos en `Tss_Generar_Pedido`.
- [x] Impresión térmica de tickets de 80 mm vía diálogo del navegador (`@media print`).
- [x] Aplicación de abonos en `sp_Tss_Registro_Pago_Cliente` y cambio de estado de remisión.
- [x] Exportación a Excel funcional sin necesidad de librerías de Microsoft Office.
