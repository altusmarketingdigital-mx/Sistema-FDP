-- 1. Crear Login a nivel de Servidor si no existe
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'usr_elyon_api')
BEGIN
    CREATE LOGIN [usr_elyon_api] 
    WITH PASSWORD = N'Ely0n_V3ntas#2026!Sec', 
         DEFAULT_DATABASE = [Tss_Inventario], 
         CHECK_EXPIRATION = OFF, 
         CHECK_POLICY = OFF;
END
GO

-- 2. Permisos en base de datos Tss_Inventario
USE [Tss_Inventario];
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'usr_elyon_api')
BEGIN
    CREATE USER [usr_elyon_api] FOR LOGIN [usr_elyon_api];
END

-- Otorgar solo permiso de ejecucion de Stored Procedures
GRANT EXECUTE TO [usr_elyon_api];
GO

-- 3. Permisos en base de datos ELYON_dbPermisosV
USE [ELYON_dbPermisosV];
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'usr_elyon_api')
BEGIN
    CREATE USER [usr_elyon_api] FOR LOGIN [usr_elyon_api];
END

-- Otorgar solo permiso de ejecucion de Stored Procedures
GRANT EXECUTE TO [usr_elyon_api];
GO