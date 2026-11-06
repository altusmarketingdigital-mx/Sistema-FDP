# GUÍA DE MIGRACIÓN A SUPABASE (POSTGRESQL) - SISTEMA ELYON VENTAS & CXC

Este paquete contiene todo lo necesario para migrar la base de datos de SQL Server a Supabase (PostgreSQL).

---

## 📁 Estructura del Paquete
- `01_schema_supabase.sql`: Script DDL PostgreSQL con todas las tablas, llaves primarias, llaves foráneas e índices.
- `csv/`: Carpeta con todos los datos exportados en formato CSV (UTF-8) directamente desde SQL Server:
  - `Permisos_Usuarios.csv` (Usuarios y contraseñas cifradas)
  - `Aplicaciones.csv` & `AplicacionesUsuarios.csv`
  - `Menus.csv` & `MenusUsuarios.csv`
  - `Botones_menus.csv` & `Permisos_UsuariosBotones.csv`
  - `Tss_Grupo.csv`
  - `Tss_Departamento.csv`
  - `Tss_Medidas_Pesos.csv`
  - `Tss_Forma_Pago.csv`
  - `Tss_Datos_Del_Contribuyente.csv`
  - `Tss_Producto.csv` (6,843 productos)
  - `Tss_Cliente.csv` (3,837 clientes)
  - `Tss_Generar_Pedido.csv` (548 pedidos)
  - `Tss_Generar_Pedido_Detalle.csv` (2,272 partidas de pedidos)
  - `Tss_Nota_Remision.csv` (80 remisiones)
  - `Tss_Registro_Pago_Cliente.csv` (11 pagos)
  - `Tss_Registro_Pago_Cliente_Detalle.csv` (11 abonos/partidas)
- `import_to_supabase.py`: Script automatizado para cargar todos los datos respetando integridad referencial.

---

## 🚀 Pasos para Ejecutar la Migración

### Paso 1: Crear la estructura en Supabase
1. Ingresa a tu proyecto en [Supabase Dashboard](https://supabase.com/dashboard).
2. Ve a la sección **SQL Editor**.
3. Abre y copia el contenido del archivo `01_schema_supabase.sql`.
4. Pega el SQL y pulsa **Run**. Esto creará todas las tablas con sus llaves e índices.

### Paso 2: Cargar los Datos

#### Opción A: Carga automática con Script de Python (Recomendado)
1. Instala el conector:
   ```bash
   pip install psycopg2-binary
   ```
2. Ejecuta el script de carga pasando la cadena de conexión de tu proyecto de Supabase:
   ```bash
   python import_to_supabase.py "postgresql://postgres:[TU_CONTRASEÑA]@[HOST_SUPABASE]:5432/postgres"
   ```

#### Opción B: Carga Manual desde el Dashboard de Supabase
1. En el Dashboard de Supabase ve a **Table Editor**.
2. Selecciona cada tabla en el siguiente orden estricto (para respetar claves foráneas):
   1. `aplicaciones`
   2. `permisos_usuarios`
   3. `menus`
   4. `menus_usuarios`
   5. `botones_menus`
   6. `permisos_usuarios_botones`
   7. `tss_grupo`
   8. `tss_departamento`
   9. `tss_medidas_pesos`
   10. `tss_forma_pago`
   11. `tss_datos_del_contribuyente`
   12. `tss_producto`
   13. `tss_cliente`
   14. `tss_generar_pedido`
   15. `tss_generar_pedido_detalle`
   16. `tss_nota_remision`
   17. `tss_registro_pago_cliente`
   18. `tss_registro_pago_cliente_detalle`
3. Usa la opción **Import data via CSV** de cada tabla subiendo su archivo CSV correspondiente.
