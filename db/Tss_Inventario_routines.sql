/****** Object: fn_montoALetra ******/
create  FUNCTION [dbo].[fn_montoALetra](@Numero NUMERIC(20,2)) 
---- =============================================
-- Author:		<Miguel Gutierrez Arroyo> /<Jorge G. Ramirez Hijar>
-- Create date: <06/09/2012><30/07/2019>
-- Description:	<Funcion para convertir numeros a letras>
--				<@DEC = 1 - Usar Decimales >
--				<@DEC = 0 - No Usar Decimales >
-- =============================================
RETURNS VARCHAR(MAX)
BEGIN
DECLARE 
  @lnEntero INT, 
  @lcRetorno VARCHAR(512), 
  @Res VARCHAR(MAX), 
  @lnTerna INT, 
  @lcMiles VARCHAR(512),
  @lcCadena VARCHAR(512),
  @lnUnidades INT, 
  @lnDecenas INT,
  @lnCentenas INT,
  @lnFraccion INT

  SELECT @lnEntero = CAST(@Numero AS INT),
    @lnFraccion = (@Numero - @lnEntero) * 100,
    @lcRetorno = ''
    ,@lnTerna= 1

	IF @lnEntero = 0 BEGIN SET @lcRetorno = 'CERO' END
  WHILE @lnEntero > 0
  BEGIN /* WHILE */
    -- Recorro terna por terna
    SELECT @lcCadena = ''
    SELECT @lnUnidades = @lnEntero % 10
    SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
    SELECT @lnDecenas = @lnEntero % 10
    SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
    SELECT @lnCentenas = @lnEntero % 10
    SELECT @lnEntero = CAST(@lnEntero/10 AS INT)

    -- Analizo las unidades
    SELECT @lcCadena =
    CASE /* UNIDADES */
      WHEN @lnUnidades = 1 AND @lnTerna = 1 THEN 'UN ' + @lcCadena
      WHEN @lnUnidades = 1 AND @lnTerna <> 1 THEN 'UN ' + @lcCadena
      WHEN @lnUnidades = 2 THEN 'DOS ' + @lcCadena
      WHEN @lnUnidades = 3 THEN 'TRES ' + @lcCadena
      WHEN @lnUnidades = 4 THEN 'CUATRO ' + @lcCadena
      WHEN @lnUnidades = 5 THEN 'CINCO ' + @lcCadena
      WHEN @lnUnidades = 6 THEN 'SEIS ' + @lcCadena
      WHEN @lnUnidades = 7 THEN 'SIETE ' + @lcCadena
      WHEN @lnUnidades = 8 THEN 'OCHO ' + @lcCadena
      WHEN @lnUnidades = 9 THEN 'NUEVE ' + @lcCadena
      ELSE @lcCadena
    END /* UNIDADES */

    -- Analizo las decenas
    SELECT @lcCadena =
    CASE /* DECENAS */
      WHEN @lnDecenas = 1 THEN
        CASE @lnUnidades
          WHEN 0 THEN 'DIEZ '
          WHEN 1 THEN 'ONCE '
          WHEN 2 THEN 'DOCE '
          WHEN 3 THEN 'TRECE '
          WHEN 4 THEN 'CATORCE '
          WHEN 5 THEN 'QUINCE '
          ELSE 'DIECI' + @lcCadena
        END
      WHEN @lnDecenas = 2 AND @lnUnidades = 0 THEN 'VEINTE ' + @lcCadena
      WHEN @lnDecenas = 2 AND @lnUnidades <> 0 THEN 'VEINTI' + @lcCadena
      WHEN @lnDecenas = 3 AND @lnUnidades = 0 THEN 'TREINTA ' + @lcCadena
      WHEN @lnDecenas = 3 AND @lnUnidades <> 0 THEN 'TREINTA Y ' + @lcCadena
      WHEN @lnDecenas = 4 AND @lnUnidades = 0 THEN 'CUARENTA ' + @lcCadena
      WHEN @lnDecenas = 4 AND @lnUnidades <> 0 THEN 'CUARENTA Y ' + @lcCadena
      WHEN @lnDecenas = 5 AND @lnUnidades = 0 THEN 'CINCUENTA ' + @lcCadena
      WHEN @lnDecenas = 5 AND @lnUnidades <> 0 THEN 'CINCUENTA Y ' + @lcCadena
      WHEN @lnDecenas = 6 AND @lnUnidades = 0 THEN 'SESENTA ' + @lcCadena
      WHEN @lnDecenas = 6 AND @lnUnidades <> 0 THEN 'SESENTA Y ' + @lcCadena
      WHEN @lnDecenas = 7 AND @lnUnidades = 0 THEN 'SETENTA ' + @lcCadena
      WHEN @lnDecenas = 7 AND @lnUnidades <> 0 THEN 'SETENTA Y ' + @lcCadena
      WHEN @lnDecenas = 8 AND @lnUnidades = 0 THEN 'OCHENTA ' + @lcCadena
      WHEN @lnDecenas = 8 AND @lnUnidades <> 0 THEN 'OCHENTA Y ' + @lcCadena
      WHEN @lnDecenas = 9 AND @lnUnidades = 0 THEN 'NOVENTA ' + @lcCadena
      WHEN @lnDecenas = 9 AND @lnUnidades <> 0 THEN 'NOVENTA Y ' + @lcCadena
      ELSE @lcCadena
    END /* DECENAS */


    -- Analizo las centenas
    SELECT @lcCadena =
    CASE /* CENTENAS */
      WHEN @lnCentenas = 1 AND @lnUnidades = 0 AND @lnDecenas = 0 THEN 'CIEN ' + @lcCadena
      WHEN @lnCentenas = 1 AND NOT(@lnUnidades = 0 AND @lnDecenas = 0) THEN 'CIENTO ' + @lcCadena
      WHEN @lnCentenas = 2 THEN 'DOSCIENTOS ' + @lcCadena
      WHEN @lnCentenas = 3 THEN 'TRESCIENTOS ' + @lcCadena
      WHEN @lnCentenas = 4 THEN 'CUATROCIENTOS ' + @lcCadena
      WHEN @lnCentenas = 5 THEN 'QUINIENTOS ' + @lcCadena
      WHEN @lnCentenas = 6 THEN 'SEISCIENTOS ' + @lcCadena
      WHEN @lnCentenas = 7 THEN 'SETECIENTOS ' + @lcCadena
      WHEN @lnCentenas = 8 THEN 'OCHOCIENTOS ' + @lcCadena
      WHEN @lnCentenas = 9 THEN 'NOVECIENTOS ' + @lcCadena
      ELSE @lcCadena
    END /* CENTENAS */

    -- Analizo la terna
    SELECT @lcCadena = 
    CASE /* TERNA */
      WHEN @lnTerna = 1 THEN @lcCadena
      WHEN @lnTerna = 2 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) THEN @lcCadena + ' MIL '
      WHEN @lnTerna = 3 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) AND 
        @lnUnidades = 1 AND @lnDecenas = 0 AND @lnCentenas = 0 THEN @lcCadena + ' MILLON '
      WHEN @lnTerna = 3 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) AND
        NOT (@lnUnidades = 1 AND @lnDecenas = 0 AND @lnCentenas = 0) THEN @lcCadena + ' MILLONES '
      WHEN @lnTerna = 4 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) THEN @lcCadena + ' MIL MILLONES '
      ELSE ''
    END /* TERNA */

    -- Armo el retorno terna a terna
    SELECT @lcRetorno = @lcCadena  + @lcRetorno
    SELECT @lnTerna = @lnTerna + 1

  END /* WHILE */

	DECLARE @Fraccion VARCHAR(MAX)	
	
	SET @Fraccion = RIGHT('00'+CAST(@lnFraccion AS VARCHAR),2)

	RETURN 
		'(' + @lcRetorno + 
			CASE @lcRetorno WHEN 'UN' THEN 'PESO ' ELSE 'PESOS ' END
		+@Fraccion +'/100 M.N.)'
--	CASE @DEC WHEN 1
--	THEN  RTRIM(@lcRetorno) + ' PUNTO ' + @Fraccion  
--	ELSE
--	 RTRIM(@lcRetorno)
--	 END  

END

GO

/****** Object: ds_ObtenerDatosFormatoTicket ******/


create procedure ds_ObtenerDatosFormatoTicket
	@PK_Id_Genera_Pedido INT
as
begin
	select Pedido.FK_Id_Usuario as Id_Usuario, Usuario.vchUsuario as Usuario, Pedido.dtp_FechaVenta as Fecha_Venta, 
	Pedido.FK_Id_Cliente as Id_Cliente, Cliente.vchNombre as Nombre_Cliente, vchCalle + ', # ' + Cliente.vchNoExterior + ' - ' + Cliente.vchNoInterior as Domicilio_Cliente,
	Cliente.vchColonia as Colonia_Cliente, Cliente.vchCiudad as Ciudad_Cliente, Cliente.vchCodigoPostal as Cp_Cliente, Cliente.vchMunicipio as Municipio_Cliente, 
	Cliente.vchEstado as Estado_Cliente, Cliente.vchPais as Pais_Cliente, Cliente.vchEmail as Correo_Cliente, Cliente.vchTelefono as Telefono_Cliente, Cliente.vchRFC as RFC_Cliente, 
	Cliente.vchLimiteCredito as Limite_Credito_Cliente, Cliente.intDiasCredito as Dias_Credito_Cliente, Cliente.vchNoCuenta as No_Cuenta_Cliente
	from Tss_Generar_Pedido Pedido
	inner join [ELYON_dbPermisosV].[dbo].[Permisos_Usuarios] Usuario on Usuario.PK_PermisoUsuario = Pedido.FK_Id_Usuario
	inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
	where Pedido.PK_Id_Genera_Pedido = @PK_Id_Genera_Pedido
end

GO

/****** Object: sp_Adm_ASP_Datos_Contribuyente ******/


CREATE procedure [dbo].[sp_Adm_ASP_Datos_Contribuyente]
	@intAccion INT, 
	@vchRazonSocial VARCHAR(250), 
    @vchRFC VARCHAR(50), 
    @vchPais VARCHAR(250), 
    @vchEstado VARCHAR(250), 
    @vchCiudad VARCHAR(250), 
    @vchCalle VARCHAR(50), 
    @vchNoInt VARCHAR(50), 
    @vchNoExt VARCHAR(50), 
    @vchColonia VARCHAR(250), 
    @vchCodigoPostal VARCHAR(20), 
    @vchTelefono VARCHAR(50), 
    @vchEmail VARCHAR(250)
as
begin
	if (@intAccion = 1)
	begin
		select vchRazonSocial as Razon_Social, vchRFC as RFC, vchPais as Pais, vchEstado as Estado, vchCiudad as Ciudad, vchCalle as Calle, 
		vchNoInt as No_Int, vchNoExt as No_Ext, vchColonia as Colonia, vchCodigoPostal as Codigo_Postal, vchTelefono as Telefono, 
		vchEmail as Email
		from Tss_Datos_Del_Contribuyente
	end

	if (@intAccion = 2)
	begin
		update Tss_Datos_Del_Contribuyente
		set vchRazonSocial = @vchRazonSocial, vchRFC = @vchRFC, vchPais = @vchPais, vchEstado = @vchEstado, vchCiudad = @vchCiudad, 
		vchCalle = @vchCalle, vchNoInt = @vchNoInt, vchNoExt = @vchNoExt, vchColonia = @vchColonia, vchCodigoPostal = @vchCodigoPostal, 
		vchTelefono = @vchTelefono, vchEmail = @vchEmail
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3)
	begin
		select vchRazonSocial as Razon_Social, vchRFC as RFC, vchPais as Pais, vchEstado as Estado, vchCiudad as Ciudad, vchCalle as Calle, 
		vchNoInt as No_Int, vchNoExt as No_Ext, vchColonia as Colonia, vchCodigoPostal as Codigo_Postal, vchTelefono as Telefono, 
		vchEmail as Email
		from Tss_Datos_Del_Contribuyente
		where vchRFC = @vchRFC
	end
end
GO

/****** Object: sp_Buscar_Pedido ******/
CREATE procedure sp_Buscar_Pedido
	@intAccion INT,
	@IdCliente INT, 
	@FolioPedido VARCHAR(10), 
	@IdPedido INT
as
begin
	if (@intAccion = 1) -- MOSTRAR TODO EL HISTORIAL DE PEDIDOS
	begin
		select Pedido.PK_Id_Genera_Pedido as Id_Pedido, Pedido.vchFolio as Folio, Pedido.dtp_FechaVenta as Fecha_Pedido, Cliente.vchNombre as Cliente
		from Tss_Generar_Pedido Pedido
		inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente and Pedido.bActivo = 1
	end

	if (@intAccion = 2)
	begin
		select Pedido.PK_Id_Genera_Pedido as Id_Pedido, Pedido.vchFolio as Folio, Pedido.dtp_FechaVenta as Fecha_Pedido, Cliente.vchNombre as Cliente
		from Tss_Generar_Pedido Pedido
		inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
		where Cliente.PK_Id_Cliente = @IdCliente
	end

	if (@intAccion = 3)
	begin
		select Pedido.PK_Id_Genera_Pedido as Id_Pedido, Pedido.vchFolio as Folio, Pedido.dtp_FechaVenta as Fecha_Pedido, Cliente.PK_Id_Cliente as Id_Cliente, Cliente.vchNombre as Cliente
		from Tss_Generar_Pedido Pedido
		inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
		where Pedido.PK_Id_Genera_Pedido = @IdPedido and Pedido.vchFolio = @FolioPedido
	end
end
GO

/****** Object: sp_CargarPedido ******/

-- [sp_CargarPedido] 19218, 'TK', 304, 2, ''


CREATE procedure [dbo].[sp_CargarPedido]
	@IdPedido INT, 
	@IdFolioPedido VARCHAR(10), 
	@IdCliente INT,
	@intAccion INT, 
	@Id_Clave_Producto VARCHAR(MAX)
as
begin 
	if(@intAccion = 1) -- OBTENER ENCABEZADO DE PEDIDO --
	begin
		select Pedido.PK_Id_Genera_Pedido as Id, Pedido.vchFolio as Folio, Pedido.FK_Id_Usuario as Id_Usuario, Pedido.dtp_FechaVenta as Fecha_Venta, Pedido.FK_Id_Cliente as Id_Cliente, 
		Pedido.intDiasCredito as Dias_Credito, Pedido.dtp_FechaVencimientoCredito as Fecha_Vencimiento, Pedido.FK_Metodo_Pago as Metodo_Pago, Pedido.FK_Forma_Pago as Forma_Pago, 
		Pedido.flt_TotalVenta as Total_Venta, Pedido.vchComentario as Comentario, Cliente.vchNombre as Nombre_Cliente, Cliente.flDescuento as Descuento, 
		Cliente.vchCalle + ' # ' + Cliente.vchNoExterior + ' - ' + Cliente.vchNoInterior + ', Col. ' + Cliente.vchColonia + ', Cp. ' + Cliente.vchCodigoPostal as Domicilio_Cliente
		from Tss_Generar_Pedido Pedido
		inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
		where Pedido.PK_Id_Genera_Pedido = @IdPedido and Pedido.vchFolio = @IdFolioPedido and Cliente.PK_Id_Cliente = @IdCliente
	end

	if (@intAccion = 2) -- OBTENEMOS EL DETALLE DEL PEDIDO -
	begin
		select Pedido.FK_Id_Clave_Producto as [Clave Producto], Producto.vchNombre as Descripcion, Pedido.fltCantidad as Cantidad, '' as UM,
		/*Pedido.vchUmVenta as UM,*/ Round(Pedido.fltPrecioVenta, 2) as [Precio Venta], 
		Round(Producto.flt_PrecioVenta_2, 2) as [Precio Venta 2], 
		Round(Producto.flt_PrecioVenta_3, 2) as [Precio Venta 3], 
		Pedido.dcDescuento as Descuento, Round(Pedido.fltImporte, 2) as Importe 
		from Tss_Generar_Pedido_Detalle Pedido
		inner join Tss_Producto Producto on Convert(Varchar(150), Producto.vchClaveProducto) = Pedido.FK_Id_Clave_Producto
		where FK_Id_Generar_Pedido = @IdPedido
	end

	if (@intAccion = 3)
	begin 
		select vchUmVenta as UM
		from Tss_Generar_Pedido_Detalle
		where FK_Id_Generar_Pedido = @IdPedido and Convert(Varchar(150), FK_Id_Clave_Producto) = Convert(Varchar, @Id_Clave_Producto)
	end
end

GO

/****** Object: sp_Datos_Contribuyente ******/
create procedure sp_Datos_Contribuyente
as
begin
	select vchRazonSocial, vchRFC, vchPais, vchEstado, vchCiudad, vchCalle, vchNoInt, vchNoExt, vchColonia, vchCodigoPostal, vchTelefono, vchEmail 
	from Tss_Datos_Del_Contribuyente
end

GO

/****** Object: sp_ObtenerBoletaRemision ******/

-- sp_ObtenerBoletaRemision 1021

CREATE  procedure [dbo].[sp_ObtenerBoletaRemision]
	@idPedido int
as
begin
	DECLARE @SALDO NUMERIC(20,2)
	SET @SALDO  = 0

	DECLARE @PEDIDO INT

	select 
	NR.PK_Id_Nota_Remision as No_Nota_Remision, 
	NR.FK_Id_No_Pedido as Id_Pedido_Generado, 
	NR.dtp_Fecha_Nota_Remision as Fecha_Nota_Remision, 
	NR.FK_Id_Cajero as Id_Cajero, V.vchUsuario as Cajero, 
	NR.vchEstatus_Nota_Remision as Estatus_Nota_Remision
	from Tss_Nota_Remision NR
	left join ELYON_dbPermisosV.dbo.Permisos_Usuarios V ON NR.FK_Id_Cajero = V.PK_PermisoUsuario
	where NR.PK_Id_Nota_Remision = @idPedido

	SELECT @PEDIDO = FK_Id_No_Pedido FROM Tss_Nota_Remision WHERE PK_Id_Nota_Remision = @idPedido

	SELECT @SALDO = SUM(PD.fltImporte)
	FROM [Tss_Generar_Pedido_Detalle] PD
	LEFT JOIN Tss_Generar_Pedido GP ON PD.FK_Id_Generar_Pedido = GP.PK_Id_Genera_Pedido
	WHERE PD.FK_Id_Generar_Pedido = @idPedido
	
	SELECT GP.vchFolio as Folio, GP.PK_Id_Genera_Pedido as Id_Pedido, 
	GP.FK_Id_Usuario as Id_Usuario, 
	Usuario.vchUsuario as Usuario, 
	GP.dtp_FechaVenta as Fecha_Venta, 
	GP.FK_Id_Cliente as Id_Cliente,
	Cliente.vchNombre as Nombre_Cliente, 
	vchCalle + ', # ' + Cliente.vchNoExterior + ' - ' + Cliente.vchNoInterior as Domicilio_Cliente,
	Cliente.vchColonia as Colonia_Cliente, 
	Cliente.vchCiudad as Ciudad_Cliente, 
	Cliente.vchCodigoPostal as Cp_Cliente, 
	Cliente.vchMunicipio as Municipio_Cliente, 
	Cliente.vchEstado as Estado_Cliente, 
	Cliente.vchPais as Pais_Cliente, 
	Cliente.vchEmail as Correo_Cliente, 
	Cliente.vchTelefono as Telefono_Cliente, 
	Cliente.vchRFC as RFC_Cliente, 
	Cliente.vchLimiteCredito as Limite_Credito_Cliente, 
	Cliente.intDiasCredito as Dias_Credito_Cliente,
	Cliente.vchNoCuenta as No_Cuenta_Cliente
		, P.vchClaveProducto AS CLAVE_PRODUCTO 
		, P.vchNombre AS DESCRIPCION
		, sum(PD.fltCantidad) AS CANTIDAD
		, PD.fltPrecioVenta AS PRECIO
		, PD.dcDescuento AS DESCUENTO
		, (sum(PD.fltCantidad) * PD.fltPrecioVenta) AS IMPORTE
		,dbo.fn_montoALetra(@SALDO)	AS	Letra				
	FROM Tss_Generar_Pedido_Detalle PD
	LEFT JOIN Tss_Generar_Pedido GP ON GP.PK_Id_Genera_Pedido = PD.FK_Id_Generar_Pedido
	LEFT JOIN Tss_Producto p ON P.vchClaveProducto = PD.FK_Id_Clave_Producto 
	LEFT join [ELYON_dbPermisosV].[dbo].[Permisos_Usuarios] Usuario on Usuario.PK_PermisoUsuario = GP.FK_Id_Usuario
	LEFT join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = GP.FK_Id_Cliente
	WHERE PD.FK_Id_Generar_Pedido = @PEDIDO

	group by P.vchClaveProducto, P.vchNombre, PD.fltPrecioVenta, PD.dcDescuento, PD.fltImporte, GP.PK_Id_Genera_Pedido, GP.FK_Id_Usuario, Usuario.vchUsuario,
	GP.dtp_FechaVenta, GP.FK_Id_Cliente, Cliente.vchNombre, Cliente.vchCalle, Cliente.vchNoExterior, Cliente.vchNoInterior,	Cliente.vchColonia, 
	Cliente.vchCiudad, Cliente.vchCodigoPostal, Cliente.vchMunicipio, Cliente.vchEstado, Cliente.vchPais, Cliente.vchEmail, Cliente.vchTelefono, 
	Cliente.vchRFC, Cliente.vchLimiteCredito, Cliente.intDiasCredito, Cliente.vchNoCuenta, GP.vchFolio
	
	select vchRazonSocial as Razon_Social, vchRFC as RFC, vchCalle + ' #' + vchNoExt + ' - ' + vchNoInt as Domicilio, 
	vchColonia as Colonia,  vchCodigoPostal as CP, vchTelefono as Telefono
	from [dbo].[Tss_Datos_Del_Contribuyente]
	
	select flt_TotalVenta as Total_Venta, dbo.fn_montoALetra(flt_TotalVenta) as Total_Letra
	from Tss_Generar_Pedido
	WHERE PK_Id_Genera_Pedido = @PEDIDO
end
GO

/****** Object: sp_Tss_Bitacora_Registro_Cliente ******/
create procedure sp_Tss_Bitacora_Registro_Cliente
	@ClavePV VARCHAR(20)
as
begin
	insert into Registro_Cliente values (@ClavePV)
	---
	IF (@@ERROR = 0)					
		SELECT 0 AS [respuesta]	-- CORRECTO		
	ELSE
		SELECT 1 AS [respuesta] -- INCORRECTO
end
GO

/****** Object: sp_Tss_Cancelar_Nota_Remision ******/
CREATE procedure [dbo].[sp_Tss_Cancelar_Nota_Remision]
	@PK_Id_Cancelar_Nota_Remisio INT, 
	@FK_Id_Nota_Remision INT, 
	@dtp_Fecha DATETIME, 
	@FK_Id_Cajero INT,
	@intAccion INT
as
begin
	if (@intAccion = 1) -- REGISTRO CANCELACIÓN DOCUMENTO
	begin
		insert into Tss_Cancelar_Nota_Remision (FK_Id_Nota_Remision, dtp_Fecha, FK_Id_Cajero)
		values (@FK_Id_Nota_Remision, @dtp_Fecha, @FK_Id_Cajero) 
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 2) -- CANCELAMOS EL PEDIDO
	begin
		declare @Id_Pedido INT
		select @Id_Pedido = FK_Id_No_Pedido from Tss_Nota_Remision where PK_Id_Nota_Remision = @FK_Id_Nota_Remision

		update Tss_Generar_Pedido
		set bActivo = 1
		where PK_Id_Genera_Pedido = @Id_Pedido
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- CANCELAMOS LA NOTA DE REMISIÓN DEL PEDIDO
	begin
		update Tss_Nota_Remision
		set bActivo = 0, vchEstatus_Nota_Remision = 'Cancelado'
		where PK_Id_Nota_Remision = @FK_Id_Nota_Remision
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end
end

GO

/****** Object: sp_Tss_CargaCombos ******/

CREATE procedure [dbo].[sp_Tss_CargaCombos]
	@Valor1 int
as
begin
	if (@Valor1 = 1)
	begin
		select PK_Id_Grupo as Id, vchNombre_Grupo as Grupo
		from Tss_Grupo
		where bActivo = 1
	end

	if (@Valor1 = 2)
	begin
		select PK_Id_Departamento as Id, vchNombre_Departamento as Departamento
		from Tss_Departamento
		where bActivo = 1
	end

	if (@Valor1 = 3)
	begin
		select PK_Id_Metodo_Pago as Clave, vchDescripcion as Descr
		from Tss_MetodoPago 
		where bActivo = 1
	end

	if (@Valor1 = 4)
	begin
		select PK_Id_Forma_Pago as Clave, vchDescripcion as Descr
		from Tss_FormaPago
		where bActivo = 1
	end

	if (@Valor1 = 5)
	begin
		select PK_Id_Forma_Pago as Id, vchDescripcion as Descripcion
		from Tss_Forma_Pago
		where bActivo = 1
	end

	if (@Valor1 = 6)
	begin
		select PK_Id_Tipo_Catalogo as Id, vchDescripcion as Descripcion
		from Tss_Tipo_Catalogo
		where bActivo = 1
	end	
end


GO

/****** Object: sp_Tss_Cargar_Combo_Medidas ******/
create procedure sp_Tss_Cargar_Combo_Medidas
as
begin
	select PK_Id_Medidas as Id, vchNombre as UM
	from Tss_Medidas_Pesos
end
GO

/****** Object: sp_Tss_Cliente ******/

CREATE procedure [dbo].[sp_Tss_Cliente]
	@PK_Id_Cliente INT, -- 0
	@vchConsecutivo_PV VARCHAR(2000) NULL, -- 1
	@vchContacto VARCHAR(2000) NULL, -- 2
	@vchNombre VARCHAR(2000), -- 3
	@vchCalle VARCHAR(2000), -- 4
	@vchNoExterior VARCHAR(2000), -- 5
	@vchNoInterior VARCHAR(2000), -- 6
	@vchColonia VARCHAR(2000), -- 7
	@vchCiudad VARCHAR(2000), -- 8
	@vchCodigoPostal VARCHAR(2000), -- 9
	@vchMunicipio VARCHAR(2000), -- 10
	@vchEstado VARCHAR(2000), -- 11
	@vchPais VARCHAR(2000), -- 12
	@vchEmail VARCHAR(2000), -- 13
	@vchTelefono VARCHAR(2000), -- 14
	@vchTelefono_2 VARCHAR(2000), -- 15
	@vchRFC VARCHAR(2000), -- 16
	@vchLimiteCredito VARCHAR(2000), -- 17
	@intDiasCredito INT, -- 18
	@vchNoCuenta VARCHAR(2000), -- 19
	@bBloqueoCliente BIT, -- 20
	@vchMotivoBloqueo VARCHAR(2000), -- 21
	@bClienteExportacion BIT, -- 22
	@intCostoFactuacion INT, -- 23
	@flDescuento FLOAT, -- 24
	@vchComentarios VARCHAR(2000), -- 25
	@intAccion INT -- 26
	--@bActivo BIT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO
	begin
		insert into Tss_Cliente (vchConsecutivo_PV, vchContacto, vchNombre, vchCalle, vchNoExterior, vchNoInterior, vchColonia, vchCiudad, vchCodigoPostal, vchMunicipio, vchEstado, vchPais, vchEmail, vchTelefono, vchTelefono_2, vchRFC, vchLimiteCredito,
					intDiasCredito, vchNoCuenta, bBloqueoCliente, vchMotivoBloqueo, bClienteExportacion,  intCostoFactuacion, flDescuento, vchComentarios, bActivo)
		values (@vchConsecutivo_PV, @vchContacto, @vchNombre, @vchCalle, @vchNoExterior, @vchNoInterior, @vchColonia, @vchCiudad, @vchCodigoPostal, @vchMunicipio, @vchEstado, @vchPais, @vchEmail, @vchTelefono, @vchTelefono_2, @vchRFC, @vchLimiteCredito,
				@intDiasCredito, @vchNoCuenta, @bBloqueoCliente, @vchMotivoBloqueo, @bClienteExportacion, @intCostoFactuacion, @flDescuento, @vchComentarios, 1)
			---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO
	begin
		update Tss_Cliente
		set vchConsecutivo_PV = @vchConsecutivo_PV, vchContacto = @vchContacto, vchNombre = @vchNombre, vchCalle = @vchCalle, vchNoExterior = @vchNoExterior, vchNoInterior = @vchNoInterior, vchColonia = @vchColonia, vchCiudad = @vchCiudad, vchCodigoPostal = @vchCodigoPostal, 
			vchMunicipio = @vchMunicipio, vchEstado = @vchEstado, vchPais = @vchPais, vchEmail = @vchEmail, vchTelefono = @vchTelefono, vchTelefono_2 = @vchTelefono_2, vchRFC = @vchRFC, vchLimiteCredito = @vchLimiteCredito,
			intDiasCredito = @intDiasCredito, vchNoCuenta = @vchNoCuenta, bBloqueoCliente = @bBloqueoCliente, vchMotivoBloqueo = @vchMotivoBloqueo, bClienteExportacion = @bClienteExportacion, 
			intCostoFactuacion = @intCostoFactuacion, flDescuento = @flDescuento, vchComentarios = @vchComentarios
		where PK_Id_Cliente = @PK_Id_Cliente
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO 
	begin
		update Tss_Cliente
		set bActivo = 0
		where PK_Id_Cliente = @PK_Id_Cliente
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR TODOS LOS REGISTROS
	begin
		select PK_Id_Cliente as Id, vchConsecutivo_PV as Id_PV, vchContacto as Contacto, vchNombre as Nombre, vchCalle as Calle, vchNoExterior as No_Exterior, vchNoInterior as No_Interior, vchColonia as Colonia, vchCiudad as Ciudad, vchCodigoPostal as Codigo_Postal,
			   vchMunicipio as Municipio, vchEstado as Estado, vchPais as Pais, vchEmail as Email, vchTelefono as Telefono, vchTelefono_2 as Telefono_2, vchRFC as RFC, vchLimiteCredito as Limite_Credito, intDiasCredito as Dias_Credito, 
			   vchNoCuenta as No_Cuenta, bBloqueoCliente as Bloqueo_Cliente, vchMotivoBloqueo as Motivo_Bloqueo, bClienteExportacion as Exportacion,  intCostoFactuacion as Costo_Factura, flDescuento as Descuento, vchComentarios as Comentarios
		from Tss_Cliente
		where bActivo = 1
	end

	if (@intAccion = 5) -- FILTRAR LOS REGISTROS
	begin
		select PK_Id_Cliente as Id, vchConsecutivo_PV as Id_PV, vchContacto as Contacto, vchNombre as Nombre, vchCalle as Calle, vchNoExterior as No_Exterior, vchNoInterior as No_Interior, vchColonia as Colonia, vchCiudad as Ciudad, vchCodigoPostal as Codigo_Postal,
			   vchMunicipio as Municipio, vchEstado as Estado, vchPais as Pais, vchEmail as Email, vchTelefono as Telefono, vchTelefono_2 as Telefono_2, vchRFC as RFC, vchLimiteCredito as Limite_Credito, intDiasCredito as Dias_Credito, 
			   vchNoCuenta as No_Cuenta, bBloqueoCliente as Bloqueo_Cliente, vchMotivoBloqueo as Motivo_Bloqueo, bClienteExportacion as Exportacion,  intCostoFactuacion as Costo_Factura, flDescuento as Descuento, vchComentarios as Comentarios
		from Tss_Cliente
		where bActivo = 1 and vchRFC LIKE '%' + @vchRFC + '%'
	end

	if (@intAccion = 6) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Cliente as Id, vchConsecutivo_PV as Id_PV, vchContacto as Contacto, vchNombre as Nombre, vchCalle as Calle, vchNoExterior as No_Exterior, vchNoInterior as No_Interior, vchColonia as Colonia, vchCiudad as Ciudad, vchCodigoPostal as Codigo_Postal,
			   vchMunicipio as Municipio, vchEstado as Estado, vchPais as Pais, vchEmail as Email, vchTelefono as Telefono, vchTelefono_2 as Telefono_2, vchRFC as RFC, vchLimiteCredito as Limite_Credito, intDiasCredito as Dias_Credito, 
			   vchNoCuenta as No_Cuenta, bBloqueoCliente as Bloqueo_Cliente, vchMotivoBloqueo as Motivo_Bloqueo, bClienteExportacion as Exportacion,  intCostoFactuacion as Costo_Factura, flDescuento as Descuento, vchComentarios as Comentarios
		from Tss_Cliente
		where bActivo = 1 and PK_Id_Cliente = @PK_Id_Cliente
	end
end
GO

/****** Object: sp_Tss_Datos_Del_Cliente_PEDIDO ******/
CREATE procedure sp_Tss_Datos_Del_Cliente_PEDIDO
	@Id_Pedido INT
as
begin
	select Pedido.FK_Id_Cliente as Id_Cliente, Cliente.vchNombre as Nombre, Cliente.vchRFC as RFC, Cliente.vchCalle + ' No. ' + Cliente.vchNoExterior as Calle, Cliente.vchColonia as Colonia, 
	Cliente.vchCodigoPostal as Codigo_Postal
	from [dbo].[Tss_Generar_Pedido] Pedido
	inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
	where PK_Id_Genera_Pedido = @Id_Pedido
end

GO

/****** Object: sp_Tss_Datos_Del_Contribuyente ******/
create procedure sp_Tss_Datos_Del_Contribuyente
	@PK_Id_Datos INT,
	@vchRazonSocial VARCHAR(250), 
	@vchRFC VARCHAR(50), 
	@vchPais VARCHAR(250),
	@vchEstado VARCHAR(250),
	@vchCiudad VARCHAR(250),
	@vchCalle VARCHAR(50),
	@vchNoInt VARCHAR(50),
	@vchNoExt VARCHAR(50), 
	@vchColonia VARCHAR(250),
	@vchCodigoPostal VARCHAR(20), 
	@vchTelefono VARCHAR(50), 
	@vchEmail VARCHAR(250)
as
begin
	if not exists (select * from Tss_Datos_Del_Contribuyente where vchRFC = @vchRFC)
	begin
		insert into Tss_Datos_Del_Contribuyente (vchRazonSocial, vchRFC, vchPais, vchEstado, vchCiudad, vchCalle, vchNoInt, vchNoExt, vchColonia, vchCodigoPostal, vchTelefono, vchEmail)
		values (@vchRazonSocial, @vchRFC, @vchPais, @vchEstado, @vchCiudad, @vchCalle, @vchNoInt, @vchNoExt, @vchColonia, @vchCodigoPostal, @vchTelefono, @vchEmail)
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	else
	begin
		update Tss_Datos_Del_Contribuyente
		set vchRazonSocial = @vchRazonSocial, vchRFC = @vchRFC, vchPais = @vchPais, vchEstado = @vchEstado, vchCiudad = @vchCiudad, vchCalle = @vchCalle, vchNoInt = @vchNoInt, vchNoExt = @vchNoExt, 
		vchColonia = @vchColonia, vchCodigoPostal = @vchCodigoPostal, vchTelefono = @vchTelefono, vchEmail = @vchEmail
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end
end
GO

/****** Object: sp_Tss_Departamento ******/
create procedure sp_Tss_Departamento
	@PK_Id_Departamento INT, 
	@vchNombre_Departamento VARCHAR(100),
	@intAccion INT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO
	begin
		if not exists (select * from Tss_Departamento where vchNombre_Departamento = @vchNombre_Departamento)
		begin
			insert into Tss_Departamento (vchNombre_Departamento, bActivo)
			values (@vchNombre_Departamento, 1)
			---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
		end

		else
		begin
			select 2 as [respuesta] -- EL GRUPO YA EXISTE
		end
	end

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO
	begin
		update Tss_Departamento
		set vchNombre_Departamento = @vchNombre_Departamento
		where PK_Id_Departamento = @PK_Id_Departamento
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO 
	begin
		update Tss_Departamento
		set bActivo = 0
		where PK_Id_Departamento = @PK_Id_Departamento
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR TODOS LOS REGISTROS
	begin
		select PK_Id_Departamento as Id, vchNombre_Departamento as Departamento
		from Tss_Departamento
		where bActivo = 1
	end

	if (@intAccion = 5) -- FILTRAR LOS REGISTROS
	begin
		select PK_Id_Departamento as Id, vchNombre_Departamento as Departamento
		from Tss_Departamento
		where bActivo = 1 and vchNombre_Departamento LIKE '%' + @vchNombre_Departamento + '%'
	end

	if (@intAccion = 6) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Departamento as Id, vchNombre_Departamento as Departamento
		from Tss_Departamento
		where bActivo = 1 and PK_Id_Departamento = @PK_Id_Departamento
	end
end
GO

/****** Object: sp_Tss_Folio_Pedido ******/
CREATE procedure sp_Tss_Folio_Pedido
	@PK_Id_Folio_Pedido INT,
	@vchClaveFolio VARCHAR(25),
	@FK_Id_Usuario INT,
	@vch_IP_Equipo VARCHAR(25),
	@intAccion INT
	--bActivo BIT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO
	begin
		insert into Tss_Folio_Pedido (vchClaveFolio, FK_Id_Usuario, vch_IP_Equipo, bActivo)
		values ( @vchClaveFolio, @FK_Id_Usuario, @vch_IP_Equipo, 1)
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end 

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO 
	begin
		
		update Tss_Folio_Pedido 
		set vchClaveFolio = @vchClaveFolio, FK_Id_Usuario = @FK_Id_Usuario, vch_IP_Equipo = @vch_IP_Equipo
		where PK_Id_Folio_Pedido = @PK_Id_Folio_Pedido
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO 
	begin
		update Tss_Folio_Pedido 
		set bActivo = 0
		where PK_Id_Folio_Pedido = @PK_Id_Folio_Pedido
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR TODOS LOS REGISTROS 
	begin
		select PK_Id_Folio_Pedido as Id, vchClaveFolio as Clave, FK_Id_Usuario as Id_Usuario, vch_IP_Equipo as IP_Equipo
		from Tss_Folio_Pedido
		where bActivo = 1
	end

	if (@intAccion = 5) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Folio_Pedido as Id, vchClaveFolio as Clave, FK_Id_Usuario as Id_Usuario, vch_IP_Equipo as IP_Equipo
		from Tss_Folio_Pedido
		where bActivo = 1 and PK_Id_Folio_Pedido = @PK_Id_Folio_Pedido
	end

	if (@intAccion = 6) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Folio_Pedido as Id, vchClaveFolio as Clave, FK_Id_Usuario as Id_Usuario, vch_IP_Equipo as IP_Equipo
		from Tss_Folio_Pedido
		where bActivo = 1 and vch_IP_Equipo = @vch_IP_Equipo and FK_Id_Usuario = @FK_Id_Usuario
	end
end
GO

/****** Object: sp_Tss_Generar_Pedido ******/

CREATE procedure [dbo].[sp_Tss_Generar_Pedido]
	@intAccion INT, 
	
	-- REGISTRO ENCABEZADO PEDIDO
	@PK_Id_Genera_Pedido INT,
	@vchFolio VARCHAR(25),
	@FK_Id_Usuario INT, 
	@dtp_FechaVenta DATETIME, 
	@FK_Id_Cliente INT,
	@intDiasCredito INT, 
	@dtp_FechaVencimientoCredito DATETIME, 
	@FK_Metodo_Pago INT,
	@FK_Forma_Pago INT,
	@flt_TotalVenta FLOAT,
	@vchComentario VARCHAR(150),

	-- REGISTRO DETALLE PEDIDO
	@PK_Id_Generar_Pedido_Detalle INT,
	@FK_Id_Generar_Pedido INT,
	@FK_Id_Clave_Producto VARCHAR(150), 
	@fltCantidad FLOAT, 
	@vchComentarioProducto VARCHAR(MAX),
	@vchUmVenta VARCHAR(20), 
	@fltPrecioVenta FLOAT,
	@dcDescuento DECIMAL, 
	@fltImporte FLOAT
as
begin
	if (@intAccion = 1) -- GENERAR ID DE PEDIDO
	begin
		Declare @UltimoID INT, @Id INT
		select @UltimoID = IDENT_CURRENT('Tss_Generar_Pedido')
		print @UltimoID

		if (@UltimoID is null)
		begin
			set @Id = 1
			SELECT @Id AS No_Pedido
		end
		
		else
		begin
			SELECT @UltimoID + 1 AS No_Pedido
		end
	end

	if (@intAccion = 2) -- REGISTRO DE ENCABEZADO DE PEDIDO
	begin
		insert into Tss_Generar_Pedido (vchFolio, FK_Id_Usuario, dtp_FechaVenta, FK_Id_Cliente, intDiasCredito, dtp_FechaVencimientoCredito, FK_Metodo_Pago, 
										FK_Forma_Pago, flt_TotalVenta, vchComentario, bActivo)
		values (@vchFolio, @FK_Id_Usuario, @dtp_FechaVenta, @FK_Id_Cliente, @intDiasCredito, @dtp_FechaVencimientoCredito, @FK_Metodo_Pago, 
										0, @flt_TotalVenta, @vchComentario, 1)
		---
		IF (@@ERROR = 0)
		begin
			SELECT 0 AS [respuesta]	-- CORRECTO		
			select IDENT_CURRENT('Tss_Generar_Pedido') as Id
		end
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- REGISTRO DE DETALLE DE PEDIDO
	begin
		insert into Tss_Generar_Pedido_Detalle (FK_Id_Generar_Pedido, FK_Id_Clave_Producto, vchComentarioProducto, fltCantidad, vchUmVenta, fltPrecioVenta, dcDescuento, fltImporte, bActivo)
		values (@FK_Id_Generar_Pedido, @FK_Id_Clave_Producto, @vchComentarioProducto, @fltCantidad, @vchUmVenta, @fltPrecioVenta, @dcDescuento, @fltImporte, 1)
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR ENCABEZADO PEDIDO
	begin
		select Pedido.vchFolio + ' ' + CONVERT(VARCHAR(10), Pedido.PK_Id_Genera_Pedido) as Id, Pedido.vchFolio as Folio, Pedido.FK_Id_Usuario as Id_Cajero, Usuario.vchUsuario as Cajero, Pedido.dtp_FechaVenta as Fecha_Venta, Pedido.FK_Id_Cliente as Id_Cliente, 
		Cliente.vchNombre as Nombre_Cliente, Pedido.intDiasCredito as Dias_Credito, Pedido.dtp_FechaVencimientoCredito as Vencha_Vencimiento, Pedido.FK_Metodo_Pago as Id_Metodo_Pago, Metodo.vchDescripcion as Metodo_Pago,
		Pedido.FK_Forma_Pago as Id_Forma_Pago, ISNULL(Forma.vchDescripcion, 'No registrado') as Forma_Pago, Pedido.flt_TotalVenta as Total_Pedido, Pedido.vchComentario as Comentario
		from Tss_Generar_Pedido Pedido
		left join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
		left join Tss_MetodoPago Metodo on Metodo.PK_Id_Metodo_Pago = Pedido.FK_Metodo_Pago
		left join Tss_FormaPago Forma on Forma.PK_Id_Forma_Pago = Pedido.FK_Forma_Pago
		left join ELYON_dbPermisosV.[dbo].[Permisos_Usuarios] Usuario on Usuario.PK_PermisoUsuario = Pedido.FK_Id_Usuario
		where Pedido.bActivo = 1 and Pedido.PK_Id_Genera_Pedido = @PK_Id_Genera_Pedido  
		
	end

	if (@intAccion = 5) -- CARGAR DETALLE PEDIDO
	begin
		select PedDet.Fk_Id_Clave_Producto as Clave_Producto, Producto.vchNombre as Producto, 
		PedDet.fltCantidad as Cantidad, PedDet.fltPrecioVenta as Precio_Venta, PedDet.dcDescuento as Descuento, PedDet.fltImporte as Importe
		from Tss_Generar_Pedido_Detalle PedDet
		inner join Tss_Producto Producto on Producto.vchClaveProducto = PedDet.Fk_Id_Clave_Producto and Producto.bActivo = 1
		where PedDet.FK_Id_Generar_Pedido = @PK_Id_Genera_Pedido and PedDet.bActivo = 1
	end

	if (@intAccion = 6) -- CARGAR HISTORIAL PEDIDOS
	begin
		select Pedido.vchFolio as Folio, Pedido.PK_Id_Genera_Pedido as Id_Pedido, Pedido.vchFolio + ' ' + CONVERT(VARCHAR(10), 
		Pedido.PK_Id_Genera_Pedido) as Id, Pedido.FK_Id_Usuario as Id_Cajero, Pedido.dtp_FechaVenta as Fecha_Venta, 
		Pedido.FK_Id_Cliente as Id_Cliente, Cliente.vchNombre as Nombre_Cliente, Pedido.intDiasCredito as Dias_Credito, 
		Pedido.dtp_FechaVencimientoCredito as Vencha_Vencimiento
		--Pedido.FK_Metodo_Pago as Id_Metodo_Pago, Metodo.vchDescripcion as Metodo_Pago,
		--Pedido.FK_Forma_Pago as Id_Forma_Pago, Forma.vchDescripcion as Forma_Pago, 
		--Pedido.flt_TotalVenta as Total_Pedido, Pedido.vchComentario as Comentario
		from Tss_Generar_Pedido Pedido
		left join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = Pedido.FK_Id_Cliente
		--left join Tss_MetodoPago Metodo on Metodo.PK_Id_Metodo_Pago = Pedido.FK_Metodo_Pago
		--left join Tss_FormaPago Forma on Forma.PK_Id_Forma_Pago = Pedido.FK_Forma_Pago
		--left join ELYON_dbPermisosV.[dbo].[Permisos_Usuarios] Usuario on Usuario.PK_PermisoUsuario = Pedido.FK_Id_Usuario
		where Pedido.bActivo = 1 and Pedido.PK_Id_Genera_Pedido NOT IN (select FK_Id_No_Pedido from Tss_Nota_Remision) 
		order by Pedido.PK_Id_Genera_Pedido
	end

	if (@intAccion = 7) -- ACTUALIZAR DE ENCABEZADO DE PEDIDO
	begin
		update Tss_Generar_Pedido
		set vchFolio = @vchFolio, FK_Id_Usuario = @FK_Id_Usuario, dtp_FechaVenta = @dtp_FechaVenta, FK_Id_Cliente = @FK_Id_Cliente, 
		intDiasCredito = @intDiasCredito, dtp_FechaVencimientoCredito = @dtp_FechaVencimientoCredito, FK_Metodo_Pago = @FK_Metodo_Pago, FK_Forma_Pago = @FK_Forma_Pago, 
		flt_TotalVenta = @flt_TotalVenta, vchComentario = @vchComentario, bActivo = 1
		where bActivo = 1 and PK_Id_Genera_Pedido = @PK_Id_Genera_Pedido 
		---
		IF (@@ERROR = 0)
		begin
			delete from Tss_Generar_Pedido_Detalle where FK_Id_Generar_Pedido = @FK_Id_Generar_Pedido
			SELECT 0 AS [respuesta]	-- CORRECTO		
			select @PK_Id_Genera_Pedido as Id
		end
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 8) -- ACTUALIZAR DE DETALLE DE PEDIDO
	begin
		insert into Tss_Generar_Pedido_Detalle (FK_Id_Generar_Pedido, FK_Id_Clave_Producto, fltCantidad, vchUmVenta, fltPrecioVenta, dcDescuento, fltImporte, bActivo)
		values (@FK_Id_Generar_Pedido, @FK_Id_Clave_Producto, @fltCantidad, @vchUmVenta, @fltPrecioVenta, @dcDescuento, @fltImporte, 1)
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end
end


GO

/****** Object: sp_Tss_Grupo ******/
CREATE procedure sp_Tss_Grupo
	@PK_Id_Grupo INT, 
	@vchNombre_Grupo VARCHAR(100),
	@intAccion INT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO
	begin
		if not exists (select * from Tss_Grupo where vchNombre_Grupo = @vchNombre_Grupo)
		begin
			insert into Tss_Grupo (vchNombre_Grupo, bActivo)
			values (@vchNombre_Grupo, 1)
			---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
		end

		else
		begin
			select 2 as [respuesta] -- EL GRUPO YA EXISTE
		end
	end

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO
	begin
		update Tss_Grupo
		set vchNombre_Grupo = @vchNombre_Grupo
		where PK_Id_Grupo = @PK_Id_Grupo
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO 
	begin
		update Tss_Grupo
		set bActivo = 0
		where PK_Id_Grupo = @PK_Id_Grupo
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR TODOS LOS REGISTROS
	begin
		select PK_Id_Grupo as Id, vchNombre_Grupo as Grupo
		from Tss_Grupo
		where bActivo = 1
	end

	if (@intAccion = 5) -- FILTRAR LOS REGISTROS
	begin
		select PK_Id_Grupo as Id, vchNombre_Grupo as Grupo
		from Tss_Grupo
		where bActivo = 1 and vchNombre_Grupo LIKE '%' + @vchNombre_Grupo + '%'
	end

	if (@intAccion = 6) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Grupo as Id, vchNombre_Grupo as Grupo
		from Tss_Grupo
		where bActivo = 1 and PK_Id_Grupo = @PK_Id_Grupo
	end
end
GO

/****** Object: sp_Tss_Inventario_Producto ******/
CREATE procedure sp_Tss_Inventario_Producto
	@PK_Id_Inventario INT, 
	@FK_Id_ClaveProducto INT,
	@intUnidadesCompra_Fisco INT,
	@intUnidadesVenta_Fisco INT,
	@intUnidadesVenta_InicialCalculado INT,
	@flt_Importa FLOAT,
	@intAccion INT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO 
	begin
		insert into Tss_Inventario_Producto (FK_Id_ClaveProducto, intUnidadesCompra_Fisco, intUnidadesVenta_Fisco, intUnidadesVenta_InicialCalculado, flt_Importa, bActivo)
		values (@FK_Id_ClaveProducto, @intUnidadesCompra_Fisco, @intUnidadesVenta_Fisco, @intUnidadesVenta_InicialCalculado, @flt_Importa, 1)
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO 
	begin
		update Tss_Inventario_Producto 
		set FK_Id_ClaveProducto = @FK_Id_ClaveProducto, intUnidadesCompra_Fisco = @intUnidadesCompra_Fisco, intUnidadesVenta_Fisco = @intUnidadesVenta_Fisco, intUnidadesVenta_InicialCalculado = @intUnidadesVenta_InicialCalculado, 
			flt_Importa = @flt_Importa
		where PK_Id_Inventario = @PK_Id_Inventario
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO 
	begin
		update Tss_Inventario_Producto 
		set bActivo = 0
		where PK_Id_Inventario = @PK_Id_Inventario
		---
		IF (@@ERROR = 0)					
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR TODOS LOS REGISTROS 
	begin
		select PK_Id_Inventario as Id, FK_Id_ClaveProducto as Clave, intUnidadesCompra_Fisco as Unidad_Compra_Fisico, intUnidadesVenta_Fisco as Unidad_Venta_Fisico, intUnidadesVenta_InicialCalculado as Unidad_Venta_Inicial_Calculado,
	           flt_Importa as Importe
		from Tss_Inventario_Producto
		where bActivo = 1
	end

	if (@intAccion = 5) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Inventario as Id, FK_Id_ClaveProducto as Clave, intUnidadesCompra_Fisco as Unidad_Compra_Fisico, intUnidadesVenta_Fisco as Unidad_Venta_Fisico, intUnidadesVenta_InicialCalculado as Unidad_Venta_Inicial_Calculado,
	           flt_Importa as Importe
		from Tss_Inventario_Producto
		where bActivo = 1 and PK_Id_Inventario  = @PK_Id_Inventario
	end
end
GO

/****** Object: sp_Tss_Nota_Remision ******/
CREATE procedure [dbo].[sp_Tss_Nota_Remision]
	@PK_Id_Nota_Remision INT,
	@FK_Id_No_Pedido INT,
	@dtp_Fecha_Nota_Remision DATETIME, 
	@FK_Id_Cajero INT,
	@vchEstatus_Nota_Remision VARCHAR(25), 
	@FK_Id_Cliente INT,
	@intAccion INT
as
begin	
	if (@intAccion = 1) -- GENERAR ID DE NOTA DE REMISIÓN
	begin
		Declare @UltimoID INT, @Id INT
		select @UltimoID = IDENT_CURRENT('Tss_Nota_Remision')

		if (@UltimoID is null)
		begin
			set @Id = 1
			SELECT @Id AS No_Nota_Remision
		end
		
		else
		begin
			SELECT @UltimoID + 1 AS No_Nota_Remision
		end
	end

	if (@intAccion = 2) -- REGISTRO NOTA DE REMISIÓN
	begin
		insert into Tss_Nota_Remision (FK_Id_No_Pedido, dtp_Fecha_Nota_Remision, FK_Id_Cajero, vchEstatus_Nota_Remision, bActivo)
		values (@FK_Id_No_Pedido, @dtp_Fecha_Nota_Remision, @FK_Id_Cajero, @vchEstatus_Nota_Remision, 1)
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- VALIDAMOS QUE EL PEDIDO NO TENGA NOTA DE REMISIÓN
	begin
		if not exists (select * from Tss_Nota_Remision where FK_Id_No_Pedido = @FK_Id_No_Pedido)
			SELECT 0 AS [respuesta]
		else
			SELECT 1 AS [respuesta]
	end

	if (@intAccion = 4) -- OBTENEMOS LA INFORMACIÓN DE LA NOTA DE REMISIÓN
	begin
		select Remision.PK_Id_Nota_Remision as Id_Nota, Remision.FK_Id_No_Pedido as Id_Pedido, Remision.dtp_Fecha_Nota_Remision as Fecha_Nota_Remision, Remision.FK_Id_Cajero as Id_Cajero, 
		Remision.vchEstatus_Nota_Remision as Estatus_Remision, Pedido.dtp_FechaVenta as Fecha_Venta_Pedido, Pedido.dtp_FechaVencimientoCredito as Fecha_Vencimiento_Credito, 
		Pedido.intDiasCredito as Dias_Credito, Pedido.flt_TotalVenta as Adeudo
		from Tss_Nota_Remision Remision
		left join Tss_Generar_Pedido Pedido on Pedido.PK_Id_Genera_Pedido = Remision.FK_Id_No_Pedido
		where Remision.bActivo = 1 and Remision.PK_Id_Nota_Remision = @PK_Id_Nota_Remision
	end

	if (@intAccion = 5) -- ACTUALIZAR ESTADO DE NOTA DE REMISIÓN A PAGADO
	begin
		update Tss_Nota_Remision 
		set vchEstatus_Nota_Remision = 'Pagado'
		where PK_Id_Nota_Remision = @PK_Id_Nota_Remision
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 6) -- VALIDAMOS SI EXISTE LA NOTA DE REMISIÓN
	begin
		if exists (select * from Tss_Nota_Remision where PK_Id_Nota_Remision = @PK_Id_Nota_Remision)
			SELECT 1 AS [respuesta]	-- EXISTE NOTA DE REMISION	
		else
			SELECT 0 AS [respuesta]	-- NO EXISTE NOTA DE REMISION	
	end

	if (@intAccion = 7) -- MOSTRAMOS LAS NOTAS DE REMISIÓN QUE CORRESPONDEN AL CLIENTE
	begin 
		select Remision.PK_Id_Nota_Remision as Id_Nota, Remision.FK_Id_No_Pedido as Id_Pedido, Remision.dtp_Fecha_Nota_Remision as Fecha_Nota_Remision, Remision.FK_Id_Cajero as Id_Cajero, 
		Remision.vchEstatus_Nota_Remision as Estatus_Remision, Pedido.dtp_FechaVenta as Fecha_Venta_Pedido, Pedido.dtp_FechaVencimientoCredito as Fecha_Vencimiento_Credito, 
		Pedido.intDiasCredito as Dias_Credito, Pedido.flt_TotalVenta as Adeudo
		from Tss_Nota_Remision Remision
		left join Tss_Generar_Pedido Pedido on Pedido.PK_Id_Genera_Pedido = Remision.FK_Id_No_Pedido
		where Remision.bActivo = 1 and Pedido.FK_Id_Cliente = @FK_Id_Cliente 
		and Remision.PK_Id_Nota_Remision NOT IN (select PK_Id_Registro_Pago_Cliente from Tss_Registro_Pago_Cliente where FK_Id_Cliente = @FK_Id_Cliente)
	end

	if (@intAccion = 8) -- CARGAMOS LAS NOTAS DE REMISIÓN ACTIVAS
	begin
		select NR.PK_Id_Nota_Remision as No_Nota, GP.vchFolio + ' ' + Convert(Varchar, NR.FK_Id_No_Pedido) as No_Pedido, C.vchNombre as Cliente, PU.vchUsuario as Cajero,
		Convert(DATE, NR.dtp_Fecha_Nota_Remision) as Fecha_Remision, Convert(DATE, GP.dtp_FechaVenta) as Fecha_Venta, Convert(DATE, GP.dtp_FechaVencimientoCredito) as Fecha_Vencimiento, 
		GP.intDiasCredito as Dias_Credito
		from Tss_Nota_Remision NR
		inner join Tss_Generar_Pedido GP on GP.PK_Id_Genera_Pedido = NR.FK_Id_No_Pedido
		inner join Tss_Cliente C on C.PK_Id_Cliente = GP.FK_Id_Cliente
		inner join [ELYON_dbPermisosV].[dbo].[Permisos_Usuarios] PU on PU.PK_PermisoUsuario = NR.FK_Id_Cajero
		where vchEstatus_Nota_Remision = 'Sin Pago'
	end
end



GO

/****** Object: sp_Tss_Obtener_Cajero ******/
CREATE procedure sp_Tss_Obtener_Cajero
	@IdUsuario INT
as
begin
	select vchUsuario as Usuario
	from ELYON_dbPermisosV.[dbo].[Permisos_Usuarios]
	where PK_PermisoUsuario = @IdUsuario
end
GO

/****** Object: sp_Tss_ObtenerInformacionDocumento_Nota_Remision ******/
CREATE procedure [dbo].[sp_Tss_ObtenerInformacionDocumento_Nota_Remision]
	@Id_Nota_Remision INT, 
	@intAccion INT
as
begin
	if (@intAccion = 1) -- CARGAR INFORMACIÓN DE DOCUMENTO
	begin
		select NotRem.FK_Id_No_Pedido as Id_Pedido, NotRem.dtp_Fecha_Nota_Remision as Fecha_Nota_Remision, NotRem.FK_Id_Cajero as Id_Cajero_Nota_Remision, NotRem.vchEstatus_Nota_Remision as Estatus_Nota_Remision,
		GenPed.vchFolio + ' ' + CONVERT(VARCHAR(MAX), GenPed.PK_Id_Genera_Pedido) as Id_Pedido, GenPed.dtp_FechaVenta as Fecha_Pedido, GenPed.FK_Id_Usuario as Id_Cajero_Generar_Pedido, GenPed.FK_Id_Cliente as Id_Cliente_Generar_Pedido, GenPed.intDiasCredito as Dias_Credito,
		GenPed.dtp_FechaVencimientoCredito as Fecha_Vencimiento_Generar_Pedido, GenPed.FK_Metodo_Pago as Id_Metodo_Pago_Genera_Pedido, GenPed.FK_Forma_Pago as Id_Forma_Pago_Genera_Pedido, GenPed.flt_TotalVenta as Total_Genera_Pedido,
		Clie.PK_Id_Cliente as Id_Cliente, Clie.vchNombre as Nombre_Cliente, Clie.vchRFC as RFC_Cliente
		from Tss_Nota_Remision NotRem
		inner join Tss_Generar_Pedido GenPed on GenPed.PK_Id_Genera_Pedido = NotRem.FK_Id_No_Pedido
		inner join Tss_Cliente Clie on Clie.PK_Id_Cliente = GenPed.FK_Id_Cliente
		where NotRem.PK_Id_Nota_Remision = @Id_Nota_Remision
	end

	if (@intAccion = 2) -- CARGAR INFORMACIÓN DE PEDIDO
	begin
		select GPD.FK_Id_Clave_Producto as Clave_Producto, P.vchNombre as Producto, GPD.fltCantidad as Cantidad, GPD.fltPrecioVenta as Precio_Venta, GPD.dcDescuento as Descuento, GPD.fltImporte as Importe
		from Tss_Nota_Remision NR
		inner join Tss_Generar_Pedido_Detalle GPD on GPD.FK_Id_Generar_Pedido = NR.FK_Id_No_Pedido
		inner join Tss_Producto P on P.vchClaveProducto = GPD.FK_Id_Clave_Producto
		where NR.PK_Id_Nota_Remision = @Id_Nota_Remision
	end

	if (@intAccion = 3) -- OBTENEMOS PAGO DE NOTA DE REMISIÓN
	begin
		select ISNULL(PK_Id_Registro_Pago_Cliente, '0') as No_Pago, ISNULL(FK_Id_Nota_Remision, '0') as No_Nota_Remision, ISNULL(dtp_Fecha_Timbrado, GETDATE()) as Fecha_Pago, ISNULL('Efectivo', '0') as Forma_Pago
		from Tss_Registro_Pago_Cliente
		where FK_Id_Nota_Remision = 8
	end
end
GO

/****** Object: sp_Tss_Producto ******/
CREATE procedure [dbo].[sp_Tss_Producto]
	@PK_Id_Producto INT,
	@vchClaveProducto VARCHAR(50),
	@vchNombre VARCHAR(150),
	@vchLocalizacion VARCHAR(150),
	@bitArticuloConDecimal BIT,
	@vch_UM_Compra VARCHAR(10),
	@vch_UM_Venta VARCHAR(10),
	@vchContenido VARCHAR(10),
	@intClaveGrupo INT,
	@intClaveDepartamento INT,
	@vchInventarioMinimo VARCHAR(10),
	@vchInventarioMaximo VARCHAR(10),
	@bitProductoExento BIT, 
	@fltIEPS FLOAT,
	@fltIVA FLOAT,
	@fltPrecioCompra FLOAT,
	@ftl_MargenUtilidad_1 FLOAT, 
	@flt_PrecioVenta_1 FLOAT,
	@ftl_MargenUtilidad_2 FLOAT, 
	@flt_PrecioVenta_2 FLOAT,
	@ftl_MargenUtilidad_3 FLOAT, 
	@flt_PrecioVenta_3 FLOAT,
	@vch_Clave_Unidad_Medida VARCHAR(15), 
	@vch_Clave_ProdServicio VARCHAR(15), 
	@intAccion INT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO
	begin
		if not exists (select * from Tss_Producto where vchNombre = @vchNombre)
		begin
			insert into Tss_Producto (vchClaveProducto, vchNombre, vchLocalizacion, bitArticuloConDecimal, vch_UM_Compra, vch_UM_Venta, vchContenido,
					intClaveGrupo, intClaveDepartamento, vchInventarioMinimo, vchInventarioMaximo, bitProductoExento, fltIEPS, fltIVA, 
					fltPrecioCompra, ftl_MargenUtilidad_1, flt_PrecioVenta_1, ftl_MargenUtilidad_2, flt_PrecioVenta_2, ftl_MargenUtilidad_3, 
					flt_PrecioVenta_3, vch_Clave_Unidad_Medida, vch_Clave_ProdServicio, bActivo)
			values (@vchClaveProducto, @vchNombre, @vchLocalizacion, @bitArticuloConDecimal, @vch_UM_Compra, @vch_UM_Venta, @vchContenido,
					@intClaveGrupo, @intClaveDepartamento, @vchInventarioMinimo, @vchInventarioMaximo, @bitProductoExento, @fltIEPS, @fltIVA, 
					@fltPrecioCompra, @ftl_MargenUtilidad_1, @flt_PrecioVenta_1, @ftl_MargenUtilidad_2, @flt_PrecioVenta_2, @ftl_MargenUtilidad_3, 
					@flt_PrecioVenta_3, @vch_Clave_Unidad_Medida, @vch_Clave_ProdServicio, 1)
			---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
		end

		else
		begin
			select 2 as [respuesta] -- EL GRUPO YA EXISTE
		end
	end

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO
	begin
		update Tss_Producto
		set vchClaveProducto = @vchClaveProducto, vchNombre = @vchNombre, vchLocalizacion = @vchLocalizacion, bitArticuloConDecimal = @bitArticuloConDecimal, vch_UM_Compra = @vch_UM_Compra, 
		    vch_UM_Venta = @vch_UM_Venta, vchContenido = @vchContenido, intClaveGrupo = @intClaveGrupo, intClaveDepartamento = @intClaveDepartamento,
			vchInventarioMinimo = @vchInventarioMinimo, vchInventarioMaximo = @vchInventarioMaximo, bitProductoExento = @bitProductoExento, fltIEPS = @fltIEPS, 
			fltIVA = @fltIVA, fltPrecioCompra = @fltPrecioCompra, ftl_MargenUtilidad_1 = @ftl_MargenUtilidad_1, flt_PrecioVenta_1 = @flt_PrecioVenta_1, 
			ftl_MargenUtilidad_2 = @ftl_MargenUtilidad_2, flt_PrecioVenta_2 = @flt_PrecioVenta_2, ftl_MargenUtilidad_3 = @ftl_MargenUtilidad_3, 
			flt_PrecioVenta_3 = @flt_PrecioVenta_3, vch_Clave_Unidad_Medida = @vch_Clave_Unidad_Medida, vch_Clave_ProdServicio = @vch_Clave_ProdServicio
		where PK_Id_Producto = @PK_Id_Producto
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO 
	begin
		update Tss_Producto
		set bActivo = 1
		where PK_Id_Producto = @PK_Id_Producto
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- CARGAR TODOS LOS REGISTROS
	begin
		select PK_Id_Producto as Id, vchClaveProducto as Clave, vchNombre as Producto, vchLocalizacion as Localizacion, bitArticuloConDecimal as Tiene_Decimal, vch_UM_Compra as UM_Compra, 
		    vch_UM_Venta as UM_Venta, vchContenido as Contenido, intClaveGrupo as Clave_Grupo, intClaveDepartamento as Clave_Departamento, vchInventarioMinimo as Inventario_Minimo,
			vchInventarioMaximo as Inventario_Maximo, bitProductoExento as Producto_Excento, fltIEPS as IEPS, fltIVA as IVA, 
			fltPrecioCompra as Precio_Compra, ftl_MargenUtilidad_1 as Margen_Utilidad_1, flt_PrecioVenta_1 as Precio_Venta_1, ftl_MargenUtilidad_2 as Margen_Utilidad_2, flt_PrecioVenta_2 as Precio_Venta_2, 
			ftl_MargenUtilidad_3 as Margen_Utilidad_3, flt_PrecioVenta_3 as Precio_Venta_3, vch_Clave_Unidad_Medida as Clave_Unidad_Medida, vch_Clave_ProdServicio as Clave_Prod_Servicio
		from Tss_Producto
		where bActivo = 1
	end

	if (@intAccion = 5) -- FILTRAR LOS REGISTROS
	begin
		select PK_Id_Producto as Id, vchClaveProducto as Clave, vchNombre as Producto, vchLocalizacion as Localizacion, bitArticuloConDecimal as Tiene_Decimal, vch_UM_Compra as UM_Compra, 
		    vch_UM_Venta as UM_Venta, vchContenido as Contenido, intClaveGrupo as Clave_Grupo, intClaveDepartamento as Clave_Departamento, vchInventarioMinimo as Inventario_Minimo,
			vchInventarioMaximo as Inventario_Maximo, bitProductoExento as Producto_Excento, fltIEPS as IEPS, fltIVA as IVA, 
			fltPrecioCompra as Precio_Compra, ftl_MargenUtilidad_1 as Margen_Utilidad_1, flt_PrecioVenta_1 as Precio_Venta_1, ftl_MargenUtilidad_2 as Margen_Utilidad_2, flt_PrecioVenta_2 as Precio_Venta_2, 
			ftl_MargenUtilidad_3 as Margen_Utilidad_3, flt_PrecioVenta_3 as Precio_Venta_3, vch_Clave_Unidad_Medida as Clave_Unidad_Medida, vch_Clave_ProdServicio as Clave_Prod_Servicio
		from Tss_Producto
		where bActivo = 1 and vchNombre LIKE '%' + @vchNombre + '%'
	end

	if (@intAccion = 6) -- FILTRAR LOS REGISTROS POR CLAVE
	begin
		select PK_Id_Producto as Id, vchClaveProducto as Clave, vchNombre as Producto, '' as UM, vchLocalizacion as Localizacion, bitArticuloConDecimal as Tiene_Decimal, vch_UM_Compra as UM_Compra, 
		    vch_UM_Venta as UM_Venta, vchContenido as Contenido, intClaveGrupo as Clave_Grupo, intClaveDepartamento as Clave_Departamento, vchInventarioMinimo as Inventario_Minimo,
			vchInventarioMaximo as Inventario_Maximo, bitProductoExento as Producto_Excento, fltIEPS as IEPS, fltIVA as IVA, 
			fltPrecioCompra as Precio_Compra, ftl_MargenUtilidad_1 as Margen_Utilidad_1, flt_PrecioVenta_1 as Precio_Venta_1, ftl_MargenUtilidad_2 as Margen_Utilidad_2, flt_PrecioVenta_2 as Precio_Venta_2, 
			ftl_MargenUtilidad_3 as Margen_Utilidad_3, flt_PrecioVenta_3 as Precio_Venta_3, vch_Clave_Unidad_Medida as Clave_Unidad_Medida, vch_Clave_ProdServicio as Clave_Prod_Servicio
		from Tss_Producto
		where bActivo = 1 and vchClaveProducto = @vchClaveProducto
	end

	if (@intAccion = 7) -- REGISTRO MASIVO
	begin
		insert into [Tss_Inventario].[dbo].[Tss_Producto] (vchClaveProducto, vchNombre, vch_UM_Venta, flt_PrecioVenta_1, flt_PrecioVenta_2, flt_PrecioVenta_3)
		values (@vchClaveProducto, @vchNombre, @vch_UM_Venta, @flt_PrecioVenta_1, @flt_PrecioVenta_2, @flt_PrecioVenta_3)
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 8) -- BUSCAR PRODUCTO POR CLAVE DE 
	begin
		select PK_Id_Producto as Id, vchClaveProducto as Clave, vchNombre as Producto, vchLocalizacion as Localizacion, bitArticuloConDecimal as Tiene_Decimal, vch_UM_Compra as UM_Compra, 
		    vch_UM_Venta as UM_Venta, vchContenido as Contenido, intClaveGrupo as Clave_Grupo, intClaveDepartamento as Clave_Departamento, vchInventarioMinimo as Inventario_Minimo,
			vchInventarioMaximo as Inventario_Maximo, bitProductoExento as Producto_Excento, fltIEPS as IEPS, fltIVA as IVA, 
			fltPrecioCompra as Precio_Compra, ftl_MargenUtilidad_1 as Margen_Utilidad_1, flt_PrecioVenta_1 as Precio_Venta_1, ftl_MargenUtilidad_2 as Margen_Utilidad_2, flt_PrecioVenta_2 as Precio_Venta_2, 
			ftl_MargenUtilidad_3 as Margen_Utilidad_3, flt_PrecioVenta_3 as Precio_Venta_3, vch_Clave_Unidad_Medida as Clave_Unidad_Medida, vch_Clave_ProdServicio as Clave_Prod_Servicio
		from Tss_Producto
		where bActivo = 1 and vchClaveProducto = @vchClaveProducto
	end

	if (@intAccion = 9) -- CARGAR TODOS LOS REGISTROS PARA OPCIÓN DE GENERAR PEDIDO
	begin
		select vchClaveProducto as Clave, vchNombre as Producto
		from Tss_Producto
		where bActivo = 1
	end
end
GO

/****** Object: sp_Tss_Proveedores ******/


CREATE procedure sp_Tss_Proveedores
	@PK_Id_Proveedor INT, 
	@vchNombre_Proveedor VARCHAR(150), 
	@vchCalle_Proveedor VARCHAR(150), 
	@vchNoExt_Proveedor VARCHAR(25), 
	@vchNoInt_Proveedor VARCHAR(25),
	@vchColonia_Proveedor VARCHAR(150), 
	@vchCp_Proveedor VARCHAR(25),
	@vchCiudad_Proveedor VARCHAR(150), 
	@vchEstado_Proveedor VARCHAR(150), 
	@vchPais_Proveedor VARCHAR(150), 
	@vchEmail_Proveedor VARCHAR(150),
	@vchTelefono_Proveedor VARCHAR(25), 
	@vchCelular_Proveedor VARCHAR(25), 
	@vchRfc_Proveedor VARCHAR(50), 
	@vchNoDeCuenta_Proveeddor VARCHAR(50),
	@intAccion INT
as
begin
	if (@intAccion = 1) -- NUEVO REGISTRO
	begin
		if not exists (select * from Tss_Proveedores where vchRfc_Proveedor = @vchRfc_Proveedor)
		begin
			insert into Tss_Proveedores (vchNombre_Proveedor, vchCalle_Proveedor, vchNoExt_Proveedor, vchNoInt_Proveedor, vchColonia_Proveedor, 
										 vchCp_Proveedor, vchCiudad_Proveedor, vchEstado_Proveedor, vchPais_Proveedor, vchEmail_Proveedor,
										 vchTelefono_Proveedor, vchCelular_Proveedor, vchRfc_Proveedor, vchNoDeCuenta_Proveeddor, bActivo)

			values (@vchNombre_Proveedor, @vchCalle_Proveedor, @vchNoExt_Proveedor, @vchNoInt_Proveedor, @vchColonia_Proveedor, 
					@vchCp_Proveedor, @vchCiudad_Proveedor, @vchEstado_Proveedor, @vchPais_Proveedor, @vchEmail_Proveedor,
					@vchTelefono_Proveedor, @vchCelular_Proveedor, @vchRfc_Proveedor, @vchNoDeCuenta_Proveeddor, 1)
			---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
		end

		else
		begin
			SELECT 2 AS [respuesta] -- EXISTE EL REGISTRO
		end
	end

	if (@intAccion = 2) -- ACTUALIZAR REGISTRO
	begin
		update Tss_Proveedores
		set vchNombre_Proveedor = @vchNombre_Proveedor, vchCalle_Proveedor = @vchCalle_Proveedor, vchNoExt_Proveedor = @vchNoExt_Proveedor, vchNoInt_Proveedor = @vchNoInt_Proveedor, 
		    vchColonia_Proveedor = @vchColonia_Proveedor, vchCp_Proveedor = @vchCp_Proveedor, vchCiudad_Proveedor = @vchCiudad_Proveedor, vchEstado_Proveedor = @vchEstado_Proveedor, 
			vchPais_Proveedor = @vchPais_Proveedor, vchEmail_Proveedor = @vchEmail_Proveedor, vchTelefono_Proveedor = @vchTelefono_Proveedor, vchCelular_Proveedor = @vchCelular_Proveedor, 
			vchRfc_Proveedor = @vchRfc_Proveedor, vchNoDeCuenta_Proveeddor = @vchNoDeCuenta_Proveeddor
		where PK_Id_Proveedor = @PK_Id_Proveedor
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 3) -- ELIMINAR REGISTRO
	begin
		update Tss_Proveedores
		set bActivo = 0
		where PK_Id_Proveedor = @PK_Id_Proveedor
		---
			IF (@@ERROR = 0)					
				SELECT 0 AS [respuesta]	-- CORRECTO		
			ELSE
				SELECT 1 AS [respuesta] -- INCORRECTO
	end	

	if (@intAccion = 4) -- BUSCAR REGISTRO
	begin
		select PK_Id_Proveedor as Id_Proveedor, 
		vchNombre_Proveedor as Nombre, 
		vchCalle_Proveedor as Cale, 
		vchNoExt_Proveedor as [No Ext], 
		vchNoInt_Proveedor as [No Int],
		vchColonia_Proveedor as Colonia, 
		vchCp_Proveedor as [Codigo Postal],
		vchCiudad_Proveedor as Ciudad, 
		vchEstado_Proveedor as Estado, 
		vchPais_Proveedor as Pais, 
		vchEmail_Proveedor as Email,
		vchTelefono_Proveedor as Telefono, 
		vchCelular_Proveedor as Celular, 
		vchRfc_Proveedor as RFC, 
		vchNoDeCuenta_Proveeddor as [No de cuenta]	
		from Tss_Proveedores
		where bActivo = 1 
	end

	if (@intAccion = 5) -- BUSCAR REGISTRO
	begin
		select PK_Id_Proveedor as Id_Proveedor, 
		vchNombre_Proveedor as Nombre, 
		vchCalle_Proveedor as Cale, 
		vchNoExt_Proveedor as [No Ext], 
		vchNoInt_Proveedor as [No Int],
		vchColonia_Proveedor as Colonia, 
		vchCp_Proveedor as [Codigo Postal],
		vchCiudad_Proveedor as Ciudad, 
		vchEstado_Proveedor as Estado, 
		vchPais_Proveedor as Pais, 
		vchEmail_Proveedor as Email,
		vchTelefono_Proveedor as Telefono, 
		vchCelular_Proveedor as Celular, 
		vchRfc_Proveedor as RFC, 
		vchNoDeCuenta_Proveeddor as [No de cuenta]	
		from Tss_Proveedores
		where bActivo = 1 and vchNombre_Proveedor like '%'+@vchNombre_Proveedor+'%'
	end

	if (@intAccion = 6) -- BUSCAR REGISTRO POR CLAVE
	begin
		select PK_Id_Proveedor as Id_Proveedor, 
		vchNombre_Proveedor as Nombre, 
		vchCalle_Proveedor as Cale, 
		vchNoExt_Proveedor as [No Ext], 
		vchNoInt_Proveedor as [No Int],
		vchColonia_Proveedor as Colonia, 
		vchCp_Proveedor as [Codigo Postal],
		vchCiudad_Proveedor as Ciudad, 
		vchEstado_Proveedor as Estado, 
		vchPais_Proveedor as Pais, 
		vchEmail_Proveedor as Email,
		vchTelefono_Proveedor as Telefono, 
		vchCelular_Proveedor as Celular, 
		vchRfc_Proveedor as RFC, 
		vchNoDeCuenta_Proveeddor as [No de cuenta]	
		from Tss_Proveedores
		where bActivo = 1 and PK_Id_Proveedor = @PK_Id_Proveedor
	end
end
GO

/****** Object: sp_Tss_Registro_Pago_Cliente ******/
CREATE procedure sp_Tss_Registro_Pago_Cliente

	-- REGISTRO PAGO CLIENTE
	@PK_Id_Registro_Pago_Cliente INT, 
	@FK_Id_Cliente INT, 
	@FK_Id_Nota_Remision INT, 
	@flt_Saldo_Anterior FLOAT, 
	@flt_Interes FLOAT, 
	@flt_Saldo_Favor FLOAT, 
	@flt_Pago_Aplicar FLOAT,
	@flt_Saldo_Nuevo FLOAT,
	@dtp_Fecha_Timbrado DATETIME,

	-- REGISTRO PAGO CLIENTE DETALLE
	@PK_Id_Registro_Pago_Cliente_Detalle INT,
	@FK_Id_Registro_Pago_Cliente INT,
	@FK_Id_Forma_Pago INT,
	@flt_Importe_Pago FLOAT, 
	@flt_Total_Pago FLOAT, 
	@flt_Cambio_Pago FLOAT, 

	@intAccion INT
as
begin
	if (@intAccion = 1) -- OBTENER EL ULTIMO PAGO DEL CLIENTE
	begin
		Declare @UltimoID INT, @Id INT
		select @UltimoID = MAX(PK_Id_Registro_Pago_Cliente) from Tss_Registro_Pago_Cliente where FK_Id_Cliente = @FK_Id_Cliente and FK_Id_Nota_Remision = @FK_Id_Nota_Remision

		if (@UltimoID is null)
		begin
			set @Id = 0
			SELECT @Id AS No_Nota_Remision
		end
		
		else
		begin
			SELECT @UltimoID AS No_Nota_Remision
		end
	end 

	if (@intAccion = 2) -- CONSULTA REGISTRO PAGO CLIENTE
	begin
		select PK_Id_Registro_Pago_Cliente as Id_Registro_Pago, FK_Id_Cliente as Id_Cliente, FK_Id_Nota_Remision as Id_Nota_Remision, flt_Saldo_Anterior as Salgo_Anterior,
		flt_Interes as Interes, flt_Saldo_Favor as Saldo_Favor, flt_Pago_Aplicar as Pago_Aplicar, flt_Saldo_Nuevo as Saldo_Nuevo, dtp_Fecha_Timbrado as Fecha_Timbrado
		from Tss_Registro_Pago_Cliente
		where bActivo = 1 and FK_Id_Cliente = @FK_Id_Cliente and FK_Id_Nota_Remision = @FK_Id_Nota_Remision
	end

	if (@intAccion = 3) -- REGISTRO PAGO CLIENTE
	begin
		insert into Tss_Registro_Pago_Cliente (FK_Id_Cliente, FK_Id_Nota_Remision, flt_Saldo_Anterior, flt_Interes, flt_Saldo_Favor, flt_Pago_Aplicar, flt_Saldo_Nuevo, dtp_Fecha_Timbrado, bActivo)
		values (@FK_Id_Cliente, @FK_Id_Nota_Remision, @flt_Saldo_Anterior, @flt_Interes, @flt_Saldo_Favor, @flt_Pago_Aplicar, @flt_Saldo_Nuevo, @dtp_Fecha_Timbrado, 1)
		---
		IF (@@ERROR = 0)
		begin
			SELECT 0 AS [respuesta]	-- CORRECTO		
			select IDENT_CURRENT('Tss_Registro_Pago_Cliente') as Id
		end
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 4) -- REGISTRO PAGO CLIENTE DETALLE
	begin
		insert into Tss_Registro_Pago_Cliente_Detalle (FK_Id_Registro_Pago_Cliente, FK_Id_Forma_Pago, flt_Importe_Pago, flt_Total_Pago, flt_Cambio_Pago, bActivo)
		values (@FK_Id_Registro_Pago_Cliente, @FK_Id_Forma_Pago, @flt_Importe_Pago, @flt_Total_Pago, @flt_Cambio_Pago, 1)
		---
		IF (@@ERROR = 0)
			SELECT 0 AS [respuesta]	-- CORRECTO		
		ELSE
			SELECT 1 AS [respuesta] -- INCORRECTO
	end

	if (@intAccion = 5) -- VALIDAMOS QUE LA NOTA DE REMISIÓN A CANCELAR NO TENGA PAGO REGISTRADO
	begin
		if exists (select * from Tss_Registro_Pago_Cliente where FK_Id_Nota_Remision = @FK_Id_Nota_Remision)
			SELECT 1 AS [respuesta]	-- EXISTE PAGO	
		else
			SELECT 0 AS [respuesta]	-- NO EXISTE PAGO	
	end
end
GO

/****** Object: sp_Tss_Unidad_Medida ******/
create procedure sp_Tss_Unidad_Medida
as
begin
	select * from Tss_Unidad_Medida
end
GO

/****** Object: spADDValidacionesUsuario ******/
---------------------------------------------------
create procedure spADDValidacionesUsuario
	@id int,
	@FkUsuario int,
	@intCajVentas int,
	@intCanVenta int,
	@intSoloCanVenta int,
	@intDesArticulo int,
	@intSoloDesArticulo int,
	@intCantVenta int,
	@intSoloCantVenta int,
	@intNoModPre int,
	@intSoloNoModPre int,
	@intPrecioVen int,
	@intSoloPrecioVen int,
	@intOtoDesc int,
	@intSoloOtoDesc int,
	@intModDatCred int,
	@intSoloModDatCred int,
	@intParMoneda int,
	@intSoloParMoneda int,
	@intCajon int
AS
	if not exists(SELECT * FROM ValidacionesUsuarios WHERE Fk_Usuario = @FkUsuario)
		BEGIN
			insert into ValidacionesUsuarios([Fk_Usuario], [intCajeroVentas], [intCancelaVenta], [intSoloCancelaVenta], 
						[intDescripArticulo], [intSoloDescripArticulo], [intCantidadVenta], [intSoloCantidadVenta], 
						[intNoModPrecio], [intSoloNoModPrecio], [intPrecioVenta], [intSoloPrecioVenta], [intOtorgaDesc], 
						[intSoloOtorgaDesc], [intModDatosCred], [intSoloModDatosCred], [intParidadMoneda], [intSoloParidadMoneda],
						[intAbreCajon])
			VALUES(@FkUsuario, @intCajVentas, @intCanVenta, @intSoloCanVenta, @intDesArticulo, @intSoloDesArticulo,
					@intCantVenta, @intSoloCantVenta, @intNoModPre, @intSoloNoModPre, @intPrecioVen, @intSoloPrecioVen,
					@intOtoDesc, @intSoloOtoDesc, @intModDatCred, @intSoloModDatCred, @intParMoneda, @intSoloParMoneda,
					@intCajon)
		END
	ELSE
		BEGIN	
			UPDATE ValidacionesUsuarios SET [intCajeroVentas] = @intCajVentas, 
						[intCancelaVenta] = @intCanVenta, 
						[intSoloCancelaVenta] = @intSoloCanVenta, 
						[intDescripArticulo] = @intDesArticulo, 
						[intSoloDescripArticulo] = @intSoloDesArticulo, 
						[intCantidadVenta] = @intCantVenta, 
						[intSoloCantidadVenta] = @intSoloCantVenta, 
						[intNoModPrecio] = @intNoModPre, 
						[intSoloNoModPrecio] = @intSoloNoModPre, 
						[intPrecioVenta] = @intPrecioVen, 
						[intSoloPrecioVenta] = @intSoloPrecioVen, 
						[intOtorgaDesc] = @intOtoDesc, 
						[intSoloOtorgaDesc] = @intSoloOtoDesc, 
						[intModDatosCred] = @intModDatCred, 
						[intSoloModDatosCred] = @intSoloModDatCred, 
						[intParidadMoneda] = @intParMoneda, 
						[intSoloParidadMoneda] = @intSoloParMoneda,
						[intAbreCajon] = @intCajon
			WHERE Fk_Usuario = @FkUsuario
		END
	SELECT @@ERROR	respuesta

GO

/****** Object: spDelValidacionesUsuarios ******/
--------------------------------------------------------------------------------------------
Create procedure spDelValidacionesUsuarios
	@id int
AS
	
	IF exists(SELECT * FROM ValidacionesUsuarios WHERE PK_ValidacionUsuario = @id)
		BEGIN
			DELETE FROM ValidacionesUsuarios WHERE PK_ValidacionUsuario = @id	
		END
			
	select @@error as respuesta

GO

/****** Object: spObtenerBoletaPago ******/



--[dbo].[spObtenerBoletaPago] 9



CREATE procedure [dbo].[spObtenerBoletaPago]
	@idPagos int
AS
	DECLARE @vchFolio varchar(5), @vchFolioNC varchar(5)

	SET @vchFolio = 'RP'
	SET @vchFolioNC = 'NR'

	select PC.PK_Id_Registro_Pago_Cliente ID
		, @vchFolio + right (REPLICATE('0',10) + cast(PC.PK_Id_Registro_Pago_Cliente as varchar),(10 - len(@vchFolio))) FOLIO
		, convert(varchar(10),PC.dtp_Fecha_Timbrado ,103) as FECHA
		, convert(varchar,PC.dtp_Fecha_Timbrado ,108) as HORA
		--Datos de la cuenta
		, @vchFolioNC + right (REPLICATE('0',8) + cast(PC.FK_Id_Nota_Remision as varchar),(10 - len(@vchFolioNC))) Documento 
		, PC.flt_Saldo_Favor as ADEUDO
		, convert(varchar(10),GP.dtp_FechaVenta ,103) as FECHADO_CUMENTO
		, convert(varchar(10),GP.dtp_FechaVencimientoCredito ,103) as VENCIMIENTO
		, NR.vchEstatus_Nota_Remision as ESTADO
		--Estado de cuenta
		, PC.flt_Saldo_Anterior as Saldo_anterior
		, PC.flt_Interes as INTERES
		, PC.flt_Saldo_Favor as Saldo_Favor
		, PC.flt_Pago_Aplicar as Aplicado
		, PC.flt_Saldo_Nuevo as Saldo_Nuevo
		, V.vchUsuario CAJERO
	FROM Tss_Generar_Pedido GP
		INNER JOIN Tss_Nota_Remision NR ON GP.PK_Id_Genera_Pedido = NR.FK_Id_No_Pedido
		INNER JOIN Tss_Registro_Pago_Cliente PC ON NR.PK_Id_Nota_Remision = PC.FK_Id_Nota_Remision
		INNER JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios V ON GP.FK_Id_Usuario = V.PK_PermisoUsuario
	WHERE PC.PK_Id_Registro_Pago_Cliente = @idPagos

	--Datos de pago aplicado
	SELECT convert(varchar(10),GETDATE() ,103) FECHA
		, PCD.flt_Importe_Pago IMPORTE
		, dbo.fn_montoALetra(PCD.flt_Importe_Pago)	AS	Letra	
	FROM Tss_Registro_Pago_Cliente PC 
		INNER JOIN Tss_Registro_Pago_Cliente_Detalle PCD ON PC.PK_Id_Registro_Pago_Cliente = PCD.FK_Id_Registro_Pago_Cliente
	WHERE PC.PK_Id_Registro_Pago_Cliente = @idPagos
	

GO

/****** Object: spObtenerBoletaPedido ******/

-- [dbo].[spObtenerBoletaPedido] 22



CREATE procedure [dbo].[spObtenerBoletaPedido]
	@idPedido int
AS
	DECLARE @SALDO NUMERIC(20,2)
	SET @SALDO  = 0
	

	SELECT GP.PK_Id_Genera_Pedido ID
		, GP.[vchFolio] + right (REPLICATE('0',10) + cast(GP.PK_Id_Genera_Pedido as varchar),(10 - len(GP.[vchFolio]))) FOLIO
		, convert(varchar(10),GP.[dtp_FechaVenta] ,103) as FECHA
		,convert(varchar,GP.[dtp_FechaVenta] ,108) as HORA
		, FP.vchDescripcion CONDICION
		,V.vchUsuario CAJERO
		, GP.vchComentario as Comentario
	FROM Tss_Generar_Pedido GP
		LEFT JOIN Tss_Forma_Pago FP ON GP.FK_Forma_Pago = FP.PK_Id_Forma_Pago
		LEFT JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios V ON GP.FK_Id_Usuario = V.PK_PermisoUsuario
	WHERE GP.PK_Id_Genera_Pedido = @idPedido

	SELECT @SALDO = SUM(PD.fltImporte)
	FROM [Tss_Generar_Pedido_Detalle] PD
	LEFT JOIN Tss_Generar_Pedido GP ON PD.FK_Id_Generar_Pedido = GP.PK_Id_Genera_Pedido
	WHERE PD.FK_Id_Generar_Pedido = @idPedido
	
	SELECT GP.vchFolio as Folio, GP.PK_Id_Genera_Pedido as Id_Pedido, 
	GP.FK_Id_Usuario as Id_Usuario, 
	Usuario.vchUsuario as Usuario, 
	GP.dtp_FechaVenta as Fecha_Venta, 
	GP.FK_Id_Cliente as Id_Cliente,
	Cliente.vchNombre as Nombre_Cliente, 
	vchCalle + ', # ' + Cliente.vchNoExterior + ' - ' + Cliente.vchNoInterior as Domicilio_Cliente,
	Cliente.vchColonia as Colonia_Cliente, 
	Cliente.vchCiudad as Ciudad_Cliente, 
	Cliente.vchCodigoPostal as Cp_Cliente, 
	Cliente.vchMunicipio as Municipio_Cliente, 
	Cliente.vchEstado as Estado_Cliente, 
	Cliente.vchPais as Pais_Cliente, 
	Cliente.vchEmail as Correo_Cliente, 
	Cliente.vchTelefono as Telefono_Cliente, 
	Cliente.vchRFC as RFC_Cliente, 
	Cliente.vchLimiteCredito as Limite_Credito_Cliente, 
	Cliente.intDiasCredito as Dias_Credito_Cliente,
	Cliente.vchNoCuenta as No_Cuenta_Cliente
		, P.vchClaveProducto AS CLAVE_PRODUCTO 
		, CONVERT(VARCHAR, sum(PD.fltCantidad))  + ' '+ PD.vchUmVenta  AS CANTIDAD
		, P.vchNombre AS DESCRIPCION
		, PD.vchComentarioProducto as COMENTARIO_PRODUCTO
		, PD.fltPrecioVenta AS PRECIO
		, PD.dcDescuento AS DESCUENTO
		, (sum(PD.fltCantidad) * PD.fltPrecioVenta) AS IMPORTE
		,dbo.fn_montoALetra(@SALDO)	AS	Letra				
	FROM Tss_Generar_Pedido_Detalle PD
	LEFT JOIN Tss_Generar_Pedido GP ON PD.FK_Id_Generar_Pedido = GP.PK_Id_Genera_Pedido
	LEFT JOIN Tss_Producto p ON PD.FK_Id_Clave_Producto = P.vchClaveProducto
	inner join [ELYON_dbPermisosV].[dbo].[Permisos_Usuarios] Usuario on Usuario.PK_PermisoUsuario = GP.FK_Id_Usuario
	inner join Tss_Cliente Cliente on Cliente.PK_Id_Cliente = GP.FK_Id_Cliente
	WHERE PD.FK_Id_Generar_Pedido = @idPedido
	group by P.vchClaveProducto, P.vchNombre, PD.fltPrecioVenta, PD.dcDescuento, PD.fltImporte, GP.PK_Id_Genera_Pedido, GP.FK_Id_Usuario, Usuario.vchUsuario,
	GP.dtp_FechaVenta, GP.FK_Id_Cliente, Cliente.vchNombre, Cliente.vchCalle, Cliente.vchNoExterior, Cliente.vchNoInterior,	Cliente.vchColonia, 
	Cliente.vchCiudad, Cliente.vchCodigoPostal, Cliente.vchMunicipio, Cliente.vchEstado, Cliente.vchPais, Cliente.vchEmail, Cliente.vchTelefono, 
	Cliente.vchRFC, Cliente.vchLimiteCredito, Cliente.intDiasCredito, Cliente.vchNoCuenta, GP.vchFolio, PD.vchUmVenta, PD.vchComentarioProducto
	
	select vchRazonSocial as Razon_Social, vchRFC as RFC, vchCalle + ' #' + vchNoExt + ' - ' + vchNoInt as Domicilio, 
	vchColonia as Colonia,  vchCodigoPostal as CP, vchTelefono as Telefono
	from [dbo].[Tss_Datos_Del_Contribuyente]




		

GO

/****** Object: spSEL_Cancelar_Nota_Remision ******/
create procedure spSEL_Cancelar_Nota_Remision
AS
	SELECT N.PK_Id_Cancelar_Nota_Remisio ID
		, N.FK_Id_Nota_Remision NoNotaRemision
		, N.dtp_Fecha FECHA
		, U.vchUsuario USUARIO 
	FROM Tss_Cancelar_Nota_Remision N
	INNER JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios U ON N.FK_Id_Cajero = U.PK_PermisoUsuario	

GO

/****** Object: spSEL_ConsultaAccesosUsuarios ******/
---------------------------------------------------------------------------------------------
--spSEL_ConsultaAccesosUsuarios 2
create procedure spSEL_ConsultaAccesosUsuarios
	@idUsuario int
AS
	DECLARE @id int, @NombreMenu varchar(200), @IdBoton int, @NombreBoton varchar(20), @DescripcionBoton varchar(100),
			@IdBoton1 int, @NombreBoton1 varchar(20), @DescripcionBoton1 varchar(100)
	DECLARE @Menus table(ID int, NombreMenu varchar(200), IdBoton int, NombreBoton varchar(20), DescripcionBoton varchar(100))
	
	SEt @id = 0		
	DECLARE curB CURSOR FOR
		SELECT M.PK_Menu, M.NombreProceso
		FROM [dbo].[MenusUsuarios] MU
			INNER JOIN [dbo].[Menus] M ON MU.FK_Menu = M.PK_Menu	
		WHERE MU.FK_PermisoUsuario = @idUsuario
		ORDER by M.PK_Menu
	OPEN curB
		FETCH NEXT FROM curB INTO @id, @NombreMenu
		WHILE @@fetch_status = 0
			BEGIN
				DECLARE curBm CURSOR FOR
					SELECT BM.PK_BotonMenu, BM.vchIDBoton,  BM.vchDescripcion				     
					FROM [dbo].[Permisos_UsuariosBotones] UB
						INNER JOIN [dbo].[Botones_menus] BM on UB.FK_BotonMenu = BM.PK_BotonMenu
					WHERE UB.FK_PermisoUsuario = @idUsuario
						AND BM.Fk_Menus = @id
				OPEN curBm
					FETCH NEXT FROM curBm INTO @IdBoton1, @NombreBoton1, @DescripcionBoton1
					WHILE @@fetch_status = 0
						BEGIN
							if not exists(SELECT * FROM @Menus WHERE ID = @id and IdBoton = @IdBoton1)
								BEGIN
									insert @Menus(ID, NombreMenu, IdBoton, NombreBoton, DescripcionBoton)
									VALUES(@id, @NombreMenu, @IdBoton1, @NombreBoton1, @DescripcionBoton1)
								END
							ELSE
								BEGIN
									UPDATE @Menus SET IdBoton = @IdBoton
													, NombreBoton = @NombreBoton
													, DescripcionBoton = @DescripcionBoton
									 WHERE ID = @id and IdBoton = @IdBoton1
								END
							FETCH NEXT FROM curBm INTO @IdBoton1, @NombreBoton1, @DescripcionBoton1
						END	  
				CLOSE curBm
				DEALLOCATE curBm

				FETCH NEXT FROM curB INTO @id, @NombreMenu
			END	  
	CLOSE curB
	DEALLOCATE curB

	SELECT * FROM @Menus
	ORDER BY ID

GO

/****** Object: spSEL_Devoluciones ******/
CREATE procedure spSEL_Devoluciones
	@Id_Cliente int
AS
	SELECT N.PK_Id_Nota_Remision
		, N.FK_Id_No_Pedido No_Pedido
		, N.dtp_Fecha_Nota_Remision FechaNotaRemision
		, U.vchUsuario USUARIO
		, N.vchEstatus_Nota_Remision ESTATUS
		, N.bActivo ACTIVO
	FROM Tss_Nota_Remision N
		INNER JOIN [dbo].[Tss_Generar_Pedido] P ON N.Fk_id_No_Pedido = P.PK_Id_Genera_Pedido
		INNER JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios U ON P.FK_Id_Usuario = U.PK_PermisoUsuario
	WHERE vchEstatus_Nota_Remision = 'Cancelado'
	AND P.FK_Id_Cliente = @Id_Cliente

GO

/****** Object: spSEL_EstadosNotasRemision ******/
CREATE procedure [dbo].[spSEL_EstadosNotasRemision]
	@Id_Cliente int
AS
	SELECT N.fk_id_no_Pedido ID
		, N.dtp_fecha_nota_Remision FECHA_REMISION
		, P.dtp_FechaVenta FECHA_VENTA
		, N.fk_id_Cajero IDCAJERO
		, U.vchUsuario USUARIO
		, N.vchEstatus_Nota_Remision ESTADO
	FROM [dbo].[Tss_Nota_Remision] N
		INNER JOIN [dbo].[Tss_Generar_Pedido] P ON N.Fk_id_No_Pedido = P.PK_Id_Genera_Pedido
		INNER JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios U ON P.FK_Id_Usuario = U.PK_PermisoUsuario
	WHERE N.vchEstatus_Nota_Remision <> 'Cancelado'
	AND P.FK_Id_Cliente = @Id_Cliente

GO

/****** Object: spSEL_Generar_Pedido ******/
create procedure spSEL_Generar_Pedido
AS
	SELECT P.PK_Id_Genera_Pedido ID
		, P.vchFolio FOLIO
		, P.FK_Id_Cliente CLIENTE
		, C.vchNombre NOMBRE
		, P.dtp_FechaVenta FECHA
		, CASE P.bActivo 
			WHEN 0 THEN 'INACTIVO'
			WHEN 1 THEN 'ACTIVO'
		 END [ESTADO_PEDIDO]
	FROM Tss_Generar_Pedido P--Pedido
		INNER JOIN [dbo].[Tss_Cliente] C ON P.FK_Id_Cliente = C.PK_Id_Cliente

GO

/****** Object: spSEL_Nota_Remision ******/
CREATE procedure spSEL_Nota_Remision	
AS	
	SELECT N.PK_Id_Nota_Remision ID
		, N.FK_Id_No_Pedido IDPEDIDO
		, N.dtp_Fecha_Nota_Remision FECHA
		, N.vchEstatus_Nota_Remision ESTADO
		, U.vchUsuario USUARIO
	FROM Tss_Nota_Remision N -- Nota de remision todas	
	INNER JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios U ON N.FK_Id_Cajero = U.PK_PermisoUsuario		

GO

/****** Object: spSEL_Pago_Cliente ******/
CREATE procedure spSEL_Pago_Cliente	
AS	
	SELECT P.PK_Id_Registro_Pago_Cliente ID
		, P.FK_Id_Cliente IDCLIENTE
		, C.vchNombre NOMBRE 
		, P.FK_Id_Nota_Remision IDNOTA
		, flt_Saldo_Anterior SALDO_ANTERIOR
		, flt_Saldo_Nuevo SALDO_NUEVO
		, dtp_Fecha_Timbrado FECHATIMBRADO
	FROM Tss_Registro_Pago_Cliente  P -- pagos
	INNER JOIN [dbo].[Tss_Cliente] C ON P.FK_Id_Cliente = C.PK_Id_Cliente

GO

/****** Object: spSEL_Tss_CatalogoClientes ******/
CREATE procedure spSEL_Tss_CatalogoClientes	
AS
	SELECT PK_Id_Cliente as Id
		, vchNombre as Nombre		
		, CASE bActivo
			WHEN 0 THEN 'INACTIVO'
			WHEN 1 THEN 'ACTIVO'
		 END ESTADO
	FROM Tss_Cliente	

GO

/****** Object: spSEL_Tss_IdClientes ******/
create procedure spSEL_Tss_IdClientes
	@Id_Cliente int
AS
	SELECT PK_Id_Cliente as Id
		, vchNombre as Nombre
		, vchCalle as Calle
		, vchNoExterior as No_Exterior
		, vchNoInterior as No_Interior
		, vchColonia as Colonia
		, vchCiudad as Ciudad
		, vchCodigoPostal as Codigo_Postal
		, vchMunicipio as Municipio
		, vchEstado as Estado
		, vchPais as Pais
		, vchEmail as Email
		, vchTelefono as Telefono
		, vchRFC as RFC
		, vchLimiteCredito as Limite_Credito
		, intDiasCredito as Dias_Credito
		, vchNoCuenta as No_Cuenta
		, bBloqueoCliente as Bloqueo_Cliente
		, vchMotivoBloqueo as Motivo_Bloqueo
		, bClienteExportacion as Exportacion
		, intCostoFactuacion as Costo_Factura
		, flDescuento as Descuento
		, vchComentarios as Comentarios
	FROM Tss_Cliente
	WHERE bActivo = 1 
		AND PK_Id_Cliente = @Id_Cliente

GO

/****** Object: spSELReporteMovimientos ******/
CREATE procedure spSELReporteMovimientos
	@vchDescripcion varchar(50),
	@intTipo int
AS
	--DECLARE @cuentatotal int, @idCliente int, @IDPedido int, @IDNotaRemision int, @IDPago int, @vchFolio varchar(30), @FechaVenta datetime,
	--		 @IDPedidoBuscar int, @idClienteBuscar int, @NombreCliente varchar(50), @RFC varchar(30), @paso int,
	--		 @IdNotaRemisionBuscar int, @Fecha_Nota_Remision datetime, @Id_CajeroNota int, @NombreCajeroNota varchar(50), @Estatus_Nota_Remision varchar(30)

	declare @ClienteID int, @Genera_PedidoID int, @Nota_Remision int, @Registro_Pago_Cliente int

	DECLARE @ReporteMovimientos Table(ID int, idCliente int, NombreCliente varchar(50), RFC varchar(30), IDPedido int, Folio varchar(30), FechaVentaPedido datetime,
		IDNotaRemision int, FechaNotaRemision datetime, IDCajeroNota int, NombreCajeroNota varchar(50), EstatusNotas varchar(30),
		IDCancelar int, FechaCancelar datetime, IDCajeroCancela int, NombreCajeroCancela varchar(50),
		IDPago int, SaldoAnterior decimal(20,2), SaldoNuevo decimal(20,2), FechaTimbrado datetime)	

	SET @ClienteID = 0
	if ( @vchDescripcion = 'No. Cliente')
		BEGIN
			SET @ClienteID = @intTipo
		END

	SET @Genera_PedidoID = 0
	if (@vchDescripcion = 'No. Pedido')
		BEGIN
			SET @Genera_PedidoID = @intTipo
		END

	SET @Nota_Remision = 0
	if (@vchDescripcion = 'No. Nota Remision')
		BEGIN
			SET @Nota_Remision = @intTipo
		END

	SET @Registro_Pago_Cliente = 0
	if (@vchDescripcion = 'No. Pago')
		BEGIN
			SET @Registro_Pago_Cliente = @intTipo
		END

	print 'Cliente ->' + cast(@ClienteID as varchar)
	print 'Pedido ->' + cast(@Genera_PedidoID as varchar)
	print 'Nota Remision ->' + cast(@Nota_Remision as varchar)
	print 'No. Pago ->' + cast(@Registro_Pago_Cliente as varchar)

	insert @ReporteMovimientos		
	SELECT  RowNum = ROW_NUMBER() OVER(ORDER BY C.PK_Id_Cliente) 
				,C.PK_Id_Cliente, C.vchNombre, C.vchRFC 		
				,P.PK_Id_Genera_Pedido, P.vchFolio,  P.dtp_FechaVenta
				,N.PK_Id_Nota_Remision, N.dtp_Fecha_Nota_Remision, N.FK_Id_Cajero, U.vchUsuario, N.vchEstatus_Nota_Remision 
				,R.PK_Id_Cancelar_Nota_Remisio, R.dtp_Fecha, R.FK_Id_Cajero, V.vchUsuario
				,PC.PK_Id_Registro_Pago_Cliente, PC.flt_Saldo_Anterior, PC.flt_Saldo_Nuevo, PC.dtp_Fecha_Timbrado  
			FROM Tss_Cliente C
			  INNER JOIN Tss_Generar_Pedido P ON C.PK_Id_Cliente = P.FK_Id_Cliente
			  INNER JOIN Tss_Nota_Remision N ON P.PK_Id_Genera_Pedido = N.FK_Id_No_Pedido
			  INNER JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios U ON N.FK_Id_Cajero = U.PK_PermisoUsuario
			  LEFT JOIN Tss_Cancelar_Nota_Remision R ON N.PK_Id_Nota_Remision = R.FK_Id_Nota_Remision
			  LEFT JOIN [ELYON_dbPermisosV].dbo.Permisos_Usuarios V ON R.FK_Id_Cajero = V.PK_PermisoUsuario
			  LEFT JOIN Tss_Registro_Pago_Cliente PC ON C.PK_Id_Cliente = PC.FK_Id_Cliente
			   AND N.PK_Id_Nota_Remision = PC.FK_Id_Nota_Remision			    
			WHERE C.PK_Id_Cliente =  CASE WHEN @ClienteID = 0 THEN
											C.PK_Id_Cliente
										 ELSE
											@ClienteID
									END
				AND P.PK_Id_Genera_Pedido = CASE WHEN @Genera_PedidoID = 0 THEN
													P.PK_Id_Genera_Pedido
												ELSE
													@Genera_PedidoID
												END
													
				AND N.PK_Id_Nota_Remision = CASE WHEN @Nota_Remision = 0 THEN
													N.PK_Id_Nota_Remision
												ELSE
													@Nota_Remision
												END
				--AND PC.PK_Id_Registro_Pago_Cliente = CASE WHEN @Registro_Pago_Cliente = 0 THEN
				--									PC.PK_Id_Registro_Pago_Cliente
				--								ELSE
				--									@Registro_Pago_Cliente
				--								END
									

	SELECT 
			ISNULL(ID ,0) ID
			, ISNULL(idCliente,0) idCliente
			, NombreCliente
			, RFC 
			, ISNULL(IDPedido,0) IDPedido
			, Folio 
			, ISNULL(FechaVentaPedido,'') FechaVentaPedido
			, ISNULL(IDNotaRemision,0) IDNotaRemision
			, ISNULL(FechaNotaRemision , '') FechaNotaRemision
			, ISNULL(IDCajeroNota,0) IDCajeroNota
			, NombreCajeroNota
			, EstatusNotas
			, ISNULL(IDCancelar,0) IDCancelar
			, ISNULL(FechaCancelar,'') FechaCancelar
			, ISNULL(IDCajeroCancela,0) IDCajeroCancela
			, NombreCajeroCancela
			, ISNULL(IDPago,0) IDPago
			, ISNULL(SaldoAnterior,0) SaldoAnterior
			, ISNULL(SaldoNuevo,0) SaldoNuevo 
			, ISNULL(FechaTimbrado,'')FechaTimbrado
	FROM @ReporteMovimientos
	

GO

