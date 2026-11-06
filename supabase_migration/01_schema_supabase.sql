-- ==============================================================================
-- SCRIPT DDL COMPLETO PARA SUPABASE (POSTGRESQL) - SISTEMA ELYON VENTAS & CXC
-- ==============================================================================

-- 1. ESQUEMAS DE SEGURIDAD (ELYON_dbPermisosV)
CREATE TABLE IF NOT EXISTS permisos_usuarios (
    pk_permisousuario SERIAL PRIMARY KEY,
    vchusuario VARCHAR(50) NOT NULL UNIQUE,
    vchusuariosistema VARCHAR(50),
    no_nomina VARCHAR(20),
    vchcorreo VARCHAR(100),
    vchcontrasena VARCHAR(500),
    bitactivo BOOLEAN DEFAULT TRUE,
    fk_plantel INT DEFAULT 0,
    bitverificacion BOOLEAN DEFAULT TRUE,
    intautenticacion INT DEFAULT 1,
    bitloggeado BOOLEAN DEFAULT FALSE,
    dttfechacreacion TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    bitadmn BOOLEAN DEFAULT FALSE,
    dtfechanacimiento DATE,
    vchnombre VARCHAR(100),
    vchpaterno VARCHAR(100),
    vchmaterno VARCHAR(100),
    vchclavedepto VARCHAR(50),
    vchdescdepto VARCHAR(150),
    vchdescpuesto VARCHAR(150),
    seguridadadmin BOOLEAN DEFAULT FALSE
);

CREATE TABLE IF NOT EXISTS aplicaciones (
    pk_aplicacion SERIAL PRIMARY KEY,
    vchnombreapp VARCHAR(100) NOT NULL,
    vchdescripcion VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS menus (
    pk_menu SERIAL PRIMARY KEY,
    fk_aplicacion INT REFERENCES aplicaciones(pk_aplicacion),
    idpadre INT,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(5),
    url VARCHAR(255),
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS menus_usuarios (
    pk_menuusuario SERIAL PRIMARY KEY,
    fk_menu INT REFERENCES menus(pk_menu),
    fk_permisousuario INT REFERENCES permisos_usuarios(pk_permisousuario)
);

CREATE TABLE IF NOT EXISTS botones_menus (
    pk_botonmenu SERIAL PRIMARY KEY,
    fk_menus INT REFERENCES menus(pk_menu),
    vchnombreboton VARCHAR(100),
    vchdescripcion VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS permisos_usuarios_botones (
    pk_permisousuarioboton SERIAL PRIMARY KEY,
    fk_botonmenu INT REFERENCES botones_menus(pk_botonmenu),
    fk_permisousuario INT REFERENCES permisos_usuarios(pk_permisousuario)
);

CREATE TABLE IF NOT EXISTS bitacora_uso_aplicaciones (
    pk_bitacora SERIAL PRIMARY KEY,
    intusuario INT,
    intidaplicacion INT,
    dttfecha TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    vchequipo VARCHAR(50)
);


-- 2. ESQUEMAS DE NEGOCIO & VENTAS (Tss_Inventario)
CREATE TABLE IF NOT EXISTS tss_grupo (
    pk_id_grupo SERIAL PRIMARY KEY,
    vchclavegrupo VARCHAR(50),
    vchnombre VARCHAR(150),
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_departamento (
    pk_id_departamento SERIAL PRIMARY KEY,
    vchclavedepartamento VARCHAR(50),
    vchnombre VARCHAR(150),
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_producto (
    pk_id_producto SERIAL PRIMARY KEY,
    vchclaveproducto VARCHAR(50) NOT NULL UNIQUE,
    vchnombre VARCHAR(255) NOT NULL,
    vchlocalizacion VARCHAR(150),
    bitarticulocondecimal BOOLEAN DEFAULT FALSE,
    vch_um_compra VARCHAR(20) DEFAULT 'PZA',
    vch_um_venta VARCHAR(20) DEFAULT 'PZA',
    vchcontenido VARCHAR(20) DEFAULT '1',
    intclavegrupo INT,
    intclavedepartamento INT,
    vchinventariominimo VARCHAR(20),
    vchinventariomaximo VARCHAR(20),
    bitproductoexento BOOLEAN DEFAULT FALSE,
    fltieps NUMERIC(18, 4) DEFAULT 0,
    fltiva NUMERIC(18, 4) DEFAULT 0,
    fltpreciocompra NUMERIC(18, 4) DEFAULT 0,
    ftl_margenutilidad_1 NUMERIC(18, 4) DEFAULT 0,
    flt_precioventa_1 NUMERIC(18, 4) DEFAULT 0,
    ftl_margenutilidad_2 NUMERIC(18, 4) DEFAULT 0,
    flt_precioventa_2 NUMERIC(18, 4) DEFAULT 0,
    ftl_margenutilidad_3 NUMERIC(18, 4) DEFAULT 0,
    flt_precioventa_3 NUMERIC(18, 4) DEFAULT 0,
    vch_clave_unidad_medida VARCHAR(20),
    vch_clave_prodservicio VARCHAR(20),
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_cliente (
    pk_id_cliente SERIAL PRIMARY KEY,
    vchconsecutivo_pv VARCHAR(100),
    vchcontacto VARCHAR(200),
    vchnombre VARCHAR(255) NOT NULL,
    vchcalle VARCHAR(200),
    vchnoexterior VARCHAR(50),
    vchnointerior VARCHAR(50),
    vchcolonia VARCHAR(150),
    vchciudad VARCHAR(150),
    vchcodigopostal VARCHAR(20),
    vchmunicipio VARCHAR(150),
    vchestado VARCHAR(100),
    vchpais VARCHAR(100) DEFAULT 'México',
    vchemail VARCHAR(150),
    vchtelefono VARCHAR(50),
    vchtelefono_2 VARCHAR(50),
    vchrfc VARCHAR(50),
    vchlimitecredito NUMERIC(18, 2) DEFAULT 0,
    intdiascredito INT DEFAULT 0,
    vchnocuenta VARCHAR(50),
    bbloqueocliente BOOLEAN DEFAULT FALSE,
    vchmotivobloqueo VARCHAR(255),
    bclienteexportacion BOOLEAN DEFAULT FALSE,
    intcostofactuacion INT DEFAULT 0,
    fldescuento NUMERIC(18, 2) DEFAULT 0,
    vchcomentarios TEXT,
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_generar_pedido (
    pk_id_genera_pedido SERIAL PRIMARY KEY,
    vchfolio VARCHAR(25) NOT NULL,
    fk_id_usuario INT REFERENCES permisos_usuarios(pk_permisousuario),
    dtp_fechaventa TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    fk_id_cliente INT REFERENCES tss_cliente(pk_id_cliente),
    intdiascredito INT DEFAULT 0,
    dtp_fechavencimientocredito TIMESTAMP WITH TIME ZONE,
    fk_metodo_pago INT DEFAULT 1,
    fk_forma_pago INT DEFAULT 1,
    flt_totalventa NUMERIC(18, 2) NOT NULL DEFAULT 0,
    vchcomentario TEXT,
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_generar_pedido_detalle (
    pk_id_generar_pedido_detalle SERIAL PRIMARY KEY,
    fk_id_generar_pedido INT REFERENCES tss_generar_pedido(pk_id_genera_pedido) ON DELETE CASCADE,
    fk_id_clave_producto VARCHAR(50) NOT NULL,
    vchcomentarioproducto TEXT,
    fltcantidad NUMERIC(18, 4) NOT NULL,
    vchumventa VARCHAR(20) DEFAULT 'PZA',
    fltprecioventa NUMERIC(18, 2) NOT NULL,
    dcdescuento NUMERIC(18, 2) DEFAULT 0,
    fltimporte NUMERIC(18, 2) NOT NULL,
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_nota_remision (
    pk_id_nota_remision SERIAL PRIMARY KEY,
    fk_id_no_pedido INT REFERENCES tss_generar_pedido(pk_id_genera_pedido),
    dtp_fecha_nota_remision TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    fk_id_cajero INT REFERENCES permisos_usuarios(pk_permisousuario),
    vchestatus_nota_remision VARCHAR(50) DEFAULT 'Sin Pago',
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_registro_pago_cliente (
    pk_id_registro_pago_cliente SERIAL PRIMARY KEY,
    fk_id_cliente INT REFERENCES tss_cliente(pk_id_cliente),
    fk_id_nota_remision INT REFERENCES tss_nota_remision(pk_id_nota_remision),
    flt_saldo_anterior NUMERIC(18, 2) NOT NULL,
    flt_interes NUMERIC(18, 2) DEFAULT 0,
    flt_saldo_favor NUMERIC(18, 2) DEFAULT 0,
    flt_pago_aplicar NUMERIC(18, 2) NOT NULL,
    flt_saldo_nuevo NUMERIC(18, 2) NOT NULL,
    dtp_fecha_timbrado TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_registro_pago_cliente_detalle (
    pk_id_registro_pago_cliente_detalle SERIAL PRIMARY KEY,
    fk_id_registro_pago_cliente INT REFERENCES tss_registro_pago_cliente(pk_id_registro_pago_cliente) ON DELETE CASCADE,
    fk_id_forma_pago INT DEFAULT 1,
    flt_importe_pago NUMERIC(18, 2) NOT NULL,
    flt_total_pago NUMERIC(18, 2) NOT NULL,
    flt_cambio_pago NUMERIC(18, 2) DEFAULT 0,
    bactivo BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS tss_cancelar_nota_remision (
    pk_id_cancelar_nota_remisio SERIAL PRIMARY KEY,
    fk_id_nota_remision INT REFERENCES tss_nota_remision(pk_id_nota_remision),
    dtp_fecha TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    fk_id_cajero INT REFERENCES permisos_usuarios(pk_permisousuario)
);

CREATE TABLE IF NOT EXISTS tss_datos_del_contribuyente (
    pk_id_datos_contribuyente SERIAL PRIMARY KEY,
    vchrazonsocial VARCHAR(255),
    vchrfc VARCHAR(50),
    vchcalle VARCHAR(200),
    vchnoext VARCHAR(50),
    vchnoint VARCHAR(50),
    vchcolonia VARCHAR(150),
    vchcodigopostal VARCHAR(20),
    vchtelefono VARCHAR(50)
);

-- ==============================================================================
-- FIN DDL POSTGRESQL PARA SUPABASE
-- ==============================================================================
