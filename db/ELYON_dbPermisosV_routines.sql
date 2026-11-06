/****** Object: AlmacenaMenus ******/
CREATE procedure [dbo].[AlmacenaMenus]
  @Aplicacion int,
  @NombreProceso varchar(60),
  @Siglas char(30),
  @Mensaje varchar(80),
  @NivelProceso int,
  @Navegacion int,
  @TipoProceso int,
  @Estatus smallint,
  @Padre int = 0,
  @MenuKey int,
  @vcPrograma varchar(100),
  @vchProgEsc varchar(100),
  @vcImagen varchar(100),
  @chrTipo char(1),
  @intArma int,
  @bSeguridad bit = false,
  @bSeguridadADM bit = false

AS   
	DECLARE @Regresa int

  if not exists (SELECT * FROM Menus WHERE FK_Aplicacion = @Aplicacion And PK_Menu = @MenuKey)  
    BEGIN
      if @Padre = ''
        begin
          set @Padre = null
        end

      insert into Menus(FK_Aplicacion,NombreProceso,SiglasProceso,MensajeProceso,NivelProceso,
                        NivelNavegacion,FK_TipoProceso,EstatusProceso,idpadre, FormaWeb, FormaEscritorio,
						Ruta, tipo, ArmaMenu, SeguridadPlantel, Administrador)
        values(@Aplicacion,@NombreProceso,@Siglas,@Mensaje,@NivelProceso,@Navegacion,@TipoProceso,
               @Estatus,@Padre,@vcPrograma, @vchProgEsc, @vcImagen, @chrTipo, @intArma, @bSeguridad, @bSeguridadADM);
      SET @Regresa = 1
    END
  ELSE
    BEGIN
      if @Padre = ''
        begin
          set @Padre = null
        end

		Update Menus set       NombreProceso = @NombreProceso,
                               SiglasProceso = @Siglas,
                               MensajeProceso = @Mensaje,
                               NivelProceso = @NivelProceso,
                               NivelNavegacion = @Navegacion,
                               FK_TipoProceso = @TipoProceso,
                               EstatusProceso = @Estatus,
                               idpadre = @Padre,
							   FormaWeb = @vcPrograma,
							   FormaEscritorio = @vchProgEsc,
							   Ruta = @vcImagen, 
							   tipo = @chrTipo,
							   ArmaMenu = @intArma,
							   SeguridadPlantel = @bSeguridad,
							   Administrador = @bSeguridadADM
        Where FK_Aplicacion = @Aplicacion          
          And PK_Menu = @MenuKey;
      SET @Regresa = 2
    END 
	SELECT @Regresa as 'Respuesta'
GO

/****** Object: EliminaMenuUsuario ******/
CREATE procedure [dbo].[EliminaMenuUsuario]
  @Usuario integer,
  @Menu integer,
  @intApp int
AS
  Declare @existe int, @MenuUsuario int, @res int
  
  set @existe = 0
  set @res = 0

  Select @MenuUsuario = MU.PK_MenuUsuario 
  from MenusUsuarios MU
  INNER JOIN menus M
	ON MU.FK_Menu = M.PK_Menu
  Where MU.FK_Menu = @Menu
      And MU.FK_PermisoUsuario = @Usuario
      AND M.FK_Aplicacion = @intApp

  Select @Existe = count(*)
    From Permiso_Menu_Usuarios
    Where FK_MenuUsuario = @MenuUsuario
  
  If @Existe = 1    
    BEGIN      
      DELETE FROM Permiso_Menu_Usuarios
        Where FK_MenuUsuario = @MenuUsuario 
		SET @res = 1
    END

  SELECT @Existe = count(*)
    from MenusUsuarios MU
	INNER JOIN menus M
		ON MU.FK_Menu = M.PK_Menu
    Where MU.FK_Menu = @Menu
      And MU.FK_PermisoUsuario = @Usuario
      AND M.FK_Aplicacion = @intApp

  if @Existe = 1 
    Begin
      Delete from MenusUsuarios
		Where FK_Menu = @Menu
		And FK_PermisoUsuario = @Usuario 
	  SET @res = 2          
    end  
  SELECT @res 'Respuesta'  

GO

/****** Object: getMenusPermisos ******/
CREATE procedure [dbo].[getMenusPermisos]
	@MenuUsuario int, 
	@Seguridad int
	--@Regresa int output
AS	
	DECLARE @Existe int, @Regresa int
		
	set @Existe = 0	  
	Select @Existe = count(*)
		From Permiso_Menu_Usuarios
		Where FK_MenuUsuario = @MenuUsuario
  
	If @Existe = 0
		begin      
			insert into Permiso_Menu_Usuarios(FK_MenuUsuario,FK_NivelesSeguridad)
			values(@MenuUsuario, @Seguridad)
			set @Regresa = 1
		END
	ELSE
		BEGIN
			set @Regresa = 0
			Update Permiso_Menu_Usuarios set FK_NivelesSeguridad = @Seguridad
				Where FK_MenuUsuario = @MenuUsuario 
		END

	select @Regresa


GO

/****** Object: getUsuarioMenus ******/
CREATE procedure [dbo].[getUsuarioMenus]
	@Menukey int, 
	@Usuario int,	
	@intApp int
	--@idMenuUsuKey int output,	
	--@Regresa int output
	
AS
	DECLARE @InsertedRows AS TABLE (Id int)
	DECLARE @Existe int
	DECLARE @idMenuUsuKey int, @Regresa int
				
	set @Existe = 0
	select @Existe = count(*), @idMenuUsuKey = PK_MenuUsuario
		from MenusUsuarios MU
		INNER JOIN menus M
				ON MU.FK_Menu = M.PK_Menu
		Where MU.FK_Menu = @Menukey
			And MU.FK_PermisoUsuario = @Usuario
			AND M.FK_Aplicacion = @intApp
	group by PK_MenuUsuario
  
	if @Existe = 0
		begin
			insert into MenusUsuarios(FK_Menu,FK_PermisoUsuario,bitEstatus)
			--output Inserted.PK_MenuUsuario into @InsertedRows
			values(@Menukey, @Usuario, 1)
			
			set	@idMenuUsuKey = @@IDENTITY
				
			--select @idMenuUsuKey = Id from @InsertedRows
			--delete from @InsertedRows
			set @Regresa = 1     
		end
	else
		begin
			set @Regresa = 0
		end

select @idMenuUsuKey, @Regresa

GO

/****** Object: pAlmacenaNivelSeguridad ******/
CREATE Procedure [dbo].[pAlmacenaNivelSeguridad]
	@NvSeg int,
	@CveNivel int,
	@DescNivel varchar(50),
	@Estado char(1)
AS
	DECLARE @Regresa int		
	if exists (SELECT * FROM NivelesSeguridad WHERE PK_NivelSeguridad = @NvSeg)
	  BEGIN
		UPDATE NivelesSeguridad set	Nivel = @CveNivel,
									DescripcionNivel = @DescNivel,
									Estatus = @Estado
		WHERE PK_NivelSeguridad = @NvSeg
		SET @Regresa = 2
	  END
	else
	  BEGIN
		INSERT INTO NivelesSeguridad(Nivel,DescripcionNivel,Estatus)
		VALUES(@CveNivel,@DescNivel,@Estado)
		SET @Regresa = 1
	  END
	 
	 SELECT @Regresa as 'Respuesta'

GO

/****** Object: pAlmacenaProceso ******/
CREATE procedure [dbo].[pAlmacenaProceso]
	@idTipProc int,
	@CveTipo varchar(10),
	@DescTipo varchar(40)
AS
	DECLARE @res int
	if exists (select * from TipoProceso where PK_TipoProceso = @idTipProc)
		begin
			UPDATE TipoProceso set	ClaveTipoProceso = @CveTipo,
									DescripcionTipoProceso = @DescTipo
				where PK_TipoProceso = @idTipProc
			SET @res = 2
		end
	else
		begin
			INSERT into TipoProceso(ClaveTipoProceso,DescripcionTipoProceso)
				Values(@CveTipo,@DescTipo)
			SET @res = 1
		end
	SELECT @res 'Respuesta'

GO

/****** Object: pEliminaAvisos ******/
create Procedure [dbo].[pEliminaAvisos]
	@IdAviso int
AS		
	DECLARE @Regresa int
	SET @Regresa = 0

	if exists (SELECT * FROM [dbo].[AvisosImg] WHERE PK_AvisoImg = @IdAviso)
	  BEGIN
		DELETE FROM [dbo].[AvisosImg]
		WHERE PK_AvisoImg = @IdAviso
		SET @Regresa = 1
	  END

	SELECT @Regresa as 'Respuesta'
GO

/****** Object: pEliminaMenus ******/
CREATE procedure [dbo].[pEliminaMenus]
	@idMenu int
AS
	DECLARE @Regresa int
	SET @Regresa = 0
	if exists(SELECT * FROM menus WHERE PK_Menu = @idMenu)
	  BEGIN
		DELETE FROM menus WHERE PK_Menu = @idMenu
		SET @Regresa = 1
	  END

	  SELECT @Regresa as 'Respuesta'

GO

/****** Object: pEliminaNivelSeguridad ******/
CREATE Procedure [dbo].[pEliminaNivelSeguridad]
	@NvSeg int
AS		
	DECLARE @Regresa int
	SET @Regresa = 0

	if exists (SELECT * FROM NivelesSeguridad WHERE PK_NivelSeguridad = @NvSeg)
	  BEGIN
		DELETE FROM NivelesSeguridad 
		WHERE PK_NivelSeguridad = @NvSeg
		SET @Regresa = 1
	  END

	SELECT @Regresa as 'Respuesta'

GO

/****** Object: pEliminaProceso ******/
CREATE procedure [dbo].[pEliminaProceso]
	@idTipProc int
AS
	DECLARE @res int
	if exists (select * from TipoProceso where PK_TipoProceso = @idTipProc)
		begin
			Delete from TipoProceso 
				where PK_TipoProceso = @idTipProc
			SET @res = 1
		end	
	ELSE
		BEGIN
			SET @res = 0
		END
	SELECT @res 'Respuesta'

GO

/****** Object: pNivelSeguridad ******/
CREATE Procedure [dbo].[pNivelSeguridad]
AS
	SELECT * FROM NivelesSeguridad

GO

/****** Object: pObtenerMenuHijosUsuario ******/
CREATE procedure [pObtenerMenuHijosUsuario] 
	@vchUsuario VARCHAR(50),	
	@intTipo int,
	@intPadre int,
	@idApp int
AS
	if (@intTipo = 1) --WEB
		BEGIN			
			SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, FK_TipoProceso, Ruta
			FROM dbo.Menus as men
						inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
			WHERE men.EstatusProceso = 1
			  AND men.Fk_aplicacion = @idApp 
			  AND mu.FK_PermisoUsuario = @vchUsuario
			  AND (men.idPadre = @intPadre and men.PK_Menu <> @intPadre)							
			  AND (men.FormaWeb is not null and men.FormaWeb <> '')
					order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion			
		END

	if (@intTipo = 0) --Escritorio
		BEGIN  			
			SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, FK_TipoProceso, Ruta
			FROM dbo.Menus as men
			inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
			WHERE men.EstatusProceso = 1 
			  AND men.Fk_aplicacion = @idApp
			  AND (men.idPadre = @intPadre and men.PK_Menu <> @intPadre)
			  AND mu.FK_PermisoUsuario = @vchUsuario							
			  AND (men.FormaEscritorio is not null and men.FormaEscritorio <> '')
					order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion
				
		END
GO

/****** Object: pObtenerMenuUsuarios ******/
CREATE procedure [dbo].[pObtenerMenuUsuarios] 
	@vchUsuario VARCHAR(50),
	@intTipo int,
	@ArmMenus int,
	@idApp int
AS
	DECLARE @_PK_Menu int, @_NombreProceso varchar(25), @_NivelProceso int, @_idPadre int , @_EstatusProceso int, 
			@_NivelNavegacion int, @_FK_TipoProceso int, @_ruta varchar(200), @_ArmaMenu int, @bAdmin bit, @tp char(1),
			@MenuVisible int, @Seguridad bit

	----------------------------------------------------------------
	-- Verifica que exista la tabla temporal y si existe la Elimina
	----------------------------------------------------------------
	IF exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[#MnuTmp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
		begin
			drop table [dbo].[#MnuTmp]     
		END 

	---------------------------
	--Genera Tabla Temporal
	---------------------------	
	CREATE table #MnuTmp(PK_Menu int, NombreProceso varchar(25), NivelProceso int, idPadre int , EstatusProceso int, 
						NivelNavegacion int, FK_TipoProceso int, Ruta varchar(200), tipo varchar(5))

    SEt @MenuVisible = 0
	SELECT @bAdmin = bitAdmn
		,@Seguridad = SeguridadAdmin
	FROM Permisos_Usuarios
	WHERE PK_PermisoUsuario = @vchUsuario

	if (@intTipo = 1) --WEB
		BEGIN	
			DECLARE cur1 cursor for		
			SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, 
				   FK_TipoProceso, Ruta, ArmaMenu, tipo
			FROM dbo.Menus as men
						inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
			WHERE men.EstatusProceso = 1
			  AND men.Fk_Aplicacion = @idApp 
			  AND mu.FK_PermisoUsuario = @vchUsuario							
			  AND (men.FormaWeb is not null and men.FormaWeb <> '')
					order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion
			OPEN cur1
			FETCH NEXT FROM cur1 INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
						@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
			WHILE @@fetch_status = 0
			BEGIN 
				if @ArmMenus = 0
				begin
					iF (@_ArmaMenu = 0) or (@_ArmaMenu = 2)
					begin
						insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
													@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
					end
						
				end 
				if @ArmMenus = 1
				begin
					iF (@_ArmaMenu = 1) or (@_ArmaMenu = 2)
					begin
						insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
													@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
					end
				end
			FETCH NEXT FROM cur1 INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
						@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
			END
			CLOSE cur1
			DEALLOCATE cur1		
		END

	if (@intTipo = 0) --Escritorio
		BEGIN  				
			if (@bAdmin = 1) 
			BEGIN	
				if (@Seguridad  = 1)
				BEGIN					
					DECLARE cur2 cursor for						
					SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso, NivelNavegacion, 
						   FK_TipoProceso, Ruta, ArmaMenu, tipo
					FROM dbo.Menus as men				
					WHERE men.EstatusProceso = 1 
						AND men.Fk_Aplicacion = @idApp									
						AND (men.FormaEscritorio is not null and men.FormaEscritorio <> '')
					order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion
					OPEN cur2
					FETCH NEXT FROM cur2 INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
								@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
					WHILE @@fetch_status = 0
					BEGIN 
						if @ArmMenus = 0
						begin
							iF (@_ArmaMenu = 0) or (@_ArmaMenu = 2)
							begin
								insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
															@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
							end
								
						end 
						if @ArmMenus = 1
						begin
							iF (@_ArmaMenu = 1) or (@_ArmaMenu = 2)
							begin
								insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
															@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
							end
						end
					FETCH NEXT FROM cur2 INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
								@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
					END
					CLOSE cur2
					DEALLOCATE cur2
				END
				ELSE
				BEGIN					
					DECLARE cur2S cursor for						
					SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso, NivelNavegacion, 
						   FK_TipoProceso, Ruta, ArmaMenu, tipo
					FROM dbo.Menus as men				
					WHERE men.EstatusProceso = 1 
						AND men.Fk_Aplicacion = @idApp	
						AND men.[Administrador] = 0								
						AND (men.FormaEscritorio is not null and men.FormaEscritorio <> '')
					order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion
					OPEN cur2S
					FETCH NEXT FROM cur2S INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
								@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
					WHILE @@fetch_status = 0
					BEGIN 
						if @ArmMenus = 0
						begin
							iF (@_ArmaMenu = 0) or (@_ArmaMenu = 2)
							begin
								insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
															@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
							end
								
						end 
						if @ArmMenus = 1
						begin
							iF (@_ArmaMenu = 1) or (@_ArmaMenu = 2)
							begin
								insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
															@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
							end
						end
					FETCH NEXT FROM cur2S INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
								@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
					END
					CLOSE cur2S
					DEALLOCATE cur2S
				END
			END
			ELSE
			BEGIN
			print 'Entre por aqui Usuario'
				DECLARE cur2 cursor for						
				SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, 
					   FK_TipoProceso, Ruta, ArmaMenu, tipo
				FROM dbo.Menus as men
				inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
				WHERE men.EstatusProceso = 1 
					AND men.Fk_Aplicacion = @idApp				
					AND mu.FK_PermisoUsuario = @vchUsuario							
					AND (men.FormaEscritorio is not null and men.FormaEscritorio <> '')
					
				order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion
				OPEN cur2
				FETCH NEXT FROM cur2 INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
							@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
				WHILE @@fetch_status = 0
				BEGIN 			
					if @ArmMenus = 0 --Menu Botones
					begin						
						iF (@_ArmaMenu = 0) or (@_ArmaMenu = 2)
						begin
							insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
														@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
						end
						
					end 
					if @ArmMenus = 1 --Menu Parte de Arriba
					begin
						--IF exists(SELECT * FROM UsuarioMenuVisible  as mv WHERE mv.Fk_PermisoUsuario = @vchUsuario							
						--				AND mv.Fk_Aplicacion = @idApp AND mv.fk_menu = @_PK_Menu)
						--BEGIN
						--	SELECT @MenuVisible = bvisible FROM UsuarioMenuVisible  WHERE Fk_PermisoUsuario = @vchUsuario							
						--				AND Fk_Aplicacion = @idApp AND fk_menu = @_PK_Menu

							--if (@MenuVisible = 1)
							--BEGIN
								iF (@_ArmaMenu = 1) or (@_ArmaMenu = 2)
								begin
									insert into #MnuTmp select @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
														@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @tp
								end
							--END
						--END											
					end
				FETCH NEXT FROM cur2 INTO @_PK_Menu, @_NombreProceso, @_NivelProceso, @_idPadre, @_EstatusProceso, 
							@_NivelNavegacion , @_FK_TipoProceso , @_ruta, @_ArmaMenu, @tp
				END
				CLOSE cur2
				DEALLOCATE cur2
			END
		END
	
	SELECT PK_Menu, NombreProceso, NivelProceso, idPadre, EstatusProceso, 
						NivelNavegacion, FK_TipoProceso, ruta, tipo
	from #MnuTmp order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion

GO

/****** Object: pSelecionaMenu ******/
CREATE procedure [dbo].[pSelecionaMenu] 
 @Menu int
AS
  Select mnu.Nombreproceso, mnu.mensajeproceso, mnu.siglasproceso, mnu.NivelProceso, mnu.NivelNavegacion,
         tp.PK_TipoProceso, mnu.EstatusProceso,mnu.idpadre, mnu.FormaWeb, mnu.FormaEscritorio, mnu.PK_Menu,
		 mnu.Ruta, mnu.tipo, mnu.ArmaMenu, mnu.SeguridadPlantel, mnu.Administrador
    From Menus as mnu
		left outer join TipoProceso as tp on mnu.FK_TipoProceso = tp.PK_TipoProceso
    Where PK_Menu = @Menu



GO

/****** Object: pSelecionaMenuNombre ******/
CREATE procedure [dbo].[pSelecionaMenuNombre]
 @MenuNombre varchar(60),
 @Aplicaccion int
AS
  Select mnu.Nombreproceso, mnu.mensajeproceso, mnu.siglasproceso, mnu.NivelProceso, mnu.NivelNavegacion,
         tp.PK_TipoProceso, mnu.EstatusProceso,mnu.idpadre, mnu.FormaWeb, mnu.FormaEscritorio, mnu.PK_Menu
    From Menus as mnu
		left outer join TipoProceso as tp on tp.PK_TipoProceso = mnu.FK_TipoProceso
    Where NombreProceso = @MenuNombre and mnu.FK_Aplicacion =  @Aplicaccion

GO

/****** Object: pSelEstadoMenu ******/
CREATE procedure [dbo].[pSelEstadoMenu]
	@NombreItem varchar(50),
	@App int
AS
	DECLARE @Nivel int
	set @Nivel = 1
	
	SELECT @Nivel = EstatusProceso
		FROM Menus
	  WHERE PK_Menu = @NombreItem	
	    AND FK_Aplicacion = @App

	Select @Nivel as 'Estatus' 
GO

/****** Object: pSelNivelSeguridad ******/
CREATE Procedure [dbo].[pSelNivelSeguridad]
	@NvSeg int
AS
	SELECT * FROM NivelesSeguridad
	WHERE PK_NivelSeguridad = @NvSeg

GO

/****** Object: pSelPermisosUsuarios ******/
CREATE procedure [dbo].[pSelPermisosUsuarios]
  @Usuario int,
  @NombreItem varchar(50),  
  @intNivel int output,
  @App int
AS
  DECLARE @MenuUsuario int, @Existe int, @Menu int, @niv int, @bAdmin bit 

  set @niv = 0


  SELECT @bAdmin = bitAdmn FROM Permisos_Usuarios
	WHERE PK_PermisoUsuario = @Usuario

	SELECT @Menu = PK_Menu FROM menus
	WHERE PK_Menu = @NombreItem	
	  AND  FK_Aplicacion = @App
   
  Select @MenuUsuario = PK_MenuUsuario from MenusUsuarios
    Where FK_Menu = @Menu
      And FK_PermisoUsuario = @Usuario
	  ANd bitEstatus = 1

	IF (@bAdmin = 1)
	BEGIN
		set @intNivel = 3
	END 
	ELSE
	BEGIN
		SET @Existe = 0  
		Select @Existe = count(*)
		  From Permiso_Menu_Usuarios
		  Where FK_MenuUsuario = @MenuUsuario
		
		IF @Existe > 0
		  BEGIN  
				SELECT @niv = nvs.nivel
					FROM Permiso_Menu_Usuarios as pu 
						inner join NivelesSeguridad as nvs on pu.FK_NivelesSeguridad = nvs.PK_NivelSeguridad
					WHERE pu.FK_MenuUsuario = @MenuUsuario
						AND nvs.Estatus = 1

				set @intNivel = @niv
		  END
		ELSE
		  BEGIN
		    SET @niv = 0
		    set @intNivel = @niv
		  END
	END
 SELECT @intNivel as 'Nivel'

GO

/****** Object: pSelProcesos ******/
CREATE procedure [dbo].[pSelProcesos]
AS
	SELECT PK_TipoProceso, ClaveTipoProceso,DescripcionTipoProceso, ClaveTipoProceso +'-' +DescripcionTipoProceso as 'Descripcion'
		FROM TipoProceso
	Order by ClaveTipoProceso

GO

/****** Object: pSelTipoMenus ******/
CREATE Procedure [dbo].[pSelTipoMenus] 
	@Tipo int
	,@IdApp int
AS
	if (@Tipo = 1)
		begin
			SELECT cast(m.PK_Menu as varchar(10)) as PK_Menus, m.NombreProceso, m.SiglasProceso, m.MensajeProceso,
				   cast(m.NivelProceso as varchar(10)) as NivelProceso, cast(m.NivelNavegacion as varchar(10)) as NivelNavegacion, 
				   cast(m.idpadre as varchar(10)) as idpadre, cast(m.FK_TipoProceso as varchar(10)) as Proceso
				FROM Menus as m	 
				 Where 
					--m.EstatusProceso = 1 AND
				    FK_Aplicacion = @IdApp     
			order by FK_TipoProceso,NivelProceso,idpadre,NivelNavegacion
		END
	else
		BEGIN
				SELECT cast(m.PK_Menu as varchar(10)) as PK_Menus, m.NombreProceso, m.SiglasProceso, m.MensajeProceso,
				   cast(m.NivelProceso as varchar(10)) as NivelProceso, cast(m.NivelNavegacion as varchar(10)) as NivelNavegacion, 
				   cast(m.idpadre as varchar(10)) as idpadre, cast(m.FK_TipoProceso as varchar(10)) as Proceso
				FROM Menus as m	       
					where 
						--m.EstatusProceso = 1 AND
					   FK_Aplicacion = @IdApp    
			order by FK_TipoProceso,NivelProceso,idpadre,NivelNavegacion
		END

GO

/****** Object: pselTipoProcesos ******/
CREATE procedure [dbo].[pselTipoProcesos]
	@idTpro int
AS
	SELECT PK_TipoProceso, ClaveTipoProceso,DescripcionTipoProceso, ClaveTipoProceso +'-' +DescripcionTipoProceso as 'Descripcion'
		FROM TipoProceso
		WHERE PK_TipoProceso = @idTpro


GO

/****** Object: pTipoProceso ******/
CREATE procedure [dbo].[pTipoProceso]
AS
	select * from TipoProceso
	Order by ClaveTipoProceso

GO

/****** Object: sp_MenuPorUsuario ******/
CREATE PROCEDURE [dbo].[sp_MenuPorUsuario] 
 @nomina varchar (20) =null
,@APP	int		= null
--,@tipoapp int = null --1 web o 0 escritorio	
,@jsonOutput NVARCHAR(MAX) OUTPUT	
AS
BEGIN
set @jsonOutput = (
	
select 
	   pu.[PK_PermisoUsuario]
      ,pu.[vchUsuario]
      ,pu.[vchUsuarioSistema]
      ,pu.[No_Nomina]
      ,pu.[vchCorreo]     
      ,pu.[bitActivo]
      ,pu.[FK_Plantel]
      ,pu.[bitVerificacion]
      ,pu.[intAutenticacion]
      ,pu.[bitLoggeado]
      ,pu.[dttFechaCreacion]  
      ,pu.[bitAdmn]
      ,pu.[dtFechaNacimiento]
		
		 ,(SELECT 		
			M.*
			
			,(SELECT ME.* 
				,(
					SELECT BM.* 
					FROM Botones_menus AS BM
					INNER JOIN Permisos_UsuariosBotones AS PUS ON BM.PK_BotonMenu = PUS.FK_BotonMenu
					WHERE BM.Fk_Menus =  ME.PK_Menu
						AND PUS.FK_PermisoUsuario = pu.PK_PermisoUsuario
				 	FOR JSON PATH, INCLUDE_NULL_VALUES) AS 'Buttons'
				FROM Menus AS ME
				INNER JOIN MenusUsuarios AS MUS ON MUS.FK_Menu = ME.PK_Menu
				WHERE ME.FK_Aplicacion = @APP
				AND MUS.FK_PermisoUsuario =  pu.[PK_PermisoUsuario]
				AND ME.tipo = 'P'
				AND ME.idPadre = M.PK_Menu
				FOR JSON PATH, INCLUDE_NULL_VALUES) AS 'MenuHijo'

			 FROM MenusUsuarios  as MU
		INNER JOIN Menus AS M			ON MU.FK_Menu = M.PK_Menu
		WHERE MU.FK_PermisoUsuario = PU.PK_PermisoUsuario
		AND M.FK_Aplicacion = @APP
		AND M.PK_Menu = M.idPadre
		AND M.tipo ='M'
		FOR JSON PATH, INCLUDE_NULL_VALUES) AS  'MenuPadre'		
		from  dbo.Permisos_Usuarios as PU		
		where pu.No_Nomina = @nomina
		
	for json path, WITHOUT_ARRAY_WRAPPER --, root('PERSONA')
)
--SELECT * FROM [ELYON_dbPermisos].dbo.MenusUsuarios
		
END
GO

/****** Object: spAddAplicaciones ******/
create procedure [dbo].[spAddAplicaciones]
	@idApp int,
	@vchNombre varchar(100),
	@vchNomLargo varchar(max),
	@estado bit
AS
	if not Exists(SELECT * FROM Aplicaciones Where PK_Aplicacion = @idApp)
	BEGIN
		INSERT Aplicaciones select @vchNombre, @vchNomLargo, @estado
	END
	ELSE
	BEGIN
		UPDATE Aplicaciones SET  NombreAplicacion = @vchNombre, 
								 NombreLargoAplicacion = @vchNomLargo, 
								 Estatus= @estado
		WHERE PK_Aplicacion = @idApp
	END 
	select @@error as respuesta
GO

/****** Object: spADDBitacoraUsoAplicaciones ******/


create procedure [dbo].[spADDBitacoraUsoAplicaciones]
	@intUsuarios int,
	@intMenu int,
	@intApp int
AS
	INSERT BitacoraUsoAplicaciones select @intUsuarios,@intMenu, @intApp,getdate()
	select @@error as respuesta
GO

/****** Object: spADDBotonesMenu ******/
create procedure [dbo].[spADDBotonesMenu]
	@IdMenus int,
	@vchIDBoton varchar(100),
	@vchDescripcion varchar(500),
	@bEstatus bit
AS
	IF not exists(SELECT * FROM Botones_menus WHERE Fk_Menus = @IdMenus AND vchIDBoton =  @vchIDBoton)
	BEGIN
		INSERT Botones_menus SELECT @IdMenus, @vchIDBoton, @vchDescripcion, @bEstatus
	END
	ELSE
	BEGIN
		UPDATE Botones_menus SET vchIDBoton =  @vchIDBoton,
								vchDescripcion = @vchDescripcion,
								EstatusBoton = @bEstatus
		WHERE Fk_Menus = @IdMenus AND vchIDBoton =  @vchIDBoton
	END

	SELECT @@error AS 'Respuesta'
GO

/****** Object: spAddBotonesUsuarios ******/
create procedure [dbo].[spAddBotonesUsuarios]
	@Usuario int,	
	@menu int,	
	@asigna bit
AS
	IF EXISTS(SELECT * FROM Permisos_UsuariosBotones WHERE FK_PermisoUsuario = @Usuario 
						AND FK_BotonMenu = @menu)
	BEGIN
		IF (@asigna = 0)
		BEGIN
			DELETE FROM Permisos_UsuariosBotones
			WHERE FK_PermisoUsuario = @Usuario				
				AND FK_BotonMenu = @menu
		END					
	END
	ELSE
	BEGIN	
		IF (@asigna = 1)
		BEGIN		
			INSERT Permisos_UsuariosBotones SELECT @menu, @Usuario
		END
	END
	
	select @@error as respuesta
GO

/****** Object: SpADDCargaAvisosImg ******/
CREATE procedure [dbo].[SpADDCargaAvisosImg]
	@idOrden int,
	@img text,
	@est int,
	@idav int
AS
	DECLARE @res int

	IF (@idav = 0)
	BEGIN
		IF (@idOrden = 1)
		BEGIN
			UPDATE AvisosImg set Orden = (Orden + 1)
			Where estatus = 1		
		END
		ELSE
		BEGIN
			UPDATE AvisosImg set Orden = (Orden + 1)
			Where estatus = 1		
			AND Orden >= @idOrden
		END

		insert AvisosImg SELECT @idOrden, @img, @est
		SET @res = 1
	END
	ELSE
	BEGIN
		UPDATE AvisosImg SET Orden = @idOrden,
							 estatus = @est,
							 imagen = @img
		WHERE PK_AvisoImg = @idav
		SET @res = 2
	END
	
	SELECT @res 'Respuesta'
GO

/****** Object: spAddImagenUsuario ******/
CREATE procedure [dbo].[spAddImagenUsuario]
  @vchUsuo int,
  @vchImagen text
AS
	DECLARE @res int
	SEt @res = 0

	IF exists(Select * from Permisos_Usuarios WHERE PK_PermisoUsuario = @vchUsuo)
	BEGIN
		UPDATE Permisos_Usuarios SET Imagen = @vchImagen
		WHERE PK_PermisoUsuario = @vchUsuo

		SEt @res = 1
	END
	SELECT @res as 'Respuesta'
GO

/****** Object: spAddMenusGrupo ******/
CREATE procedure [dbo].[spAddMenusGrupo]
	@usuarioPadre int,
	@usuarioHijo int,
	@intApp int	
AS
	DECLARE @InsertedRows AS TABLE (Id int)
	DECLARE @mnulnk int, @idMenuUsuKey int, @Existe int, @Seguridad int, @res int,
	        @App int, @Plantel varchar(5), @mnuBoton int

	set @res = 0
	--Realizar un Foreach de los registros que existan en la Tabla 
		DECLARE cur1 CURSOR FOR
			SELECT MU.FK_Menu
			FROM MenusUsuarios 	MU
			INNER JOIN menus M
				ON MU.FK_Menu = M.PK_Menu		
			WHERE MU.FK_PermisoUsuario = @usuarioPadre
			  AND M.FK_Aplicacion = @intApp

		OPEN cur1
		FETCH NEXT FROM cur1 INTO @mnulnk
		WHILE @@fetch_status = 0
			BEGIN 					
				--Inserta en tabla Telefonos
				--------------------------------
				if not exists (select * from MenusUsuarios where FK_PermisoUsuario = @usuarioHijo and FK_Menu = @mnulnk)
					begin
						insert into MenusUsuarios(FK_Menu,FK_PermisoUsuario,bitEstatus)
						values(@mnulnk, @usuarioHijo, 1)
						
						--output Inserted.PK_MenuUsuario into @InsertedRows
						SET @idMenuUsuKey = @@IDENTITY
					
						--select @idMenuUsuKey = Id from @InsertedRows
						--delete from @InsertedRows
						SET @res = 1

						DECLARE cur2 CURSOR FOR
							select FK_NivelesSeguridad  from Permiso_Menu_Usuarios 			
								Where FK_MenuUsuario = @mnulnk

						OPEN cur2
						FETCH NEXT FROM cur2 INTO @Seguridad
						WHILE @@fetch_status = 0
							BEGIN 			
								set @Existe = 0	  
								if exists(Select * From Permiso_Menu_Usuarios Where FK_MenuUsuario = @mnulnk)  
									begin      
										insert into Permiso_Menu_Usuarios(FK_MenuUsuario,FK_NivelesSeguridad)
										values(@idMenuUsuKey, @Seguridad)
										
										SET @res = 2					
									END																
								FETCH NEXT FROM cur2 INTO @Seguridad
							END	  
						CLOSE cur2
						DEALLOCATE cur2					
					END	
				ELSE
					BEGIN
						SET @res = 1
					END								
				FETCH NEXT FROM cur1 INTO @mnulnk
			END	  
		CLOSE cur1
		DEALLOCATE cur1
		print 'Respuesta 1 Menus->' + cast(@res as varchar)
		-------------------------------------------------------------------------
		--Copia Plantels del Usuario
		-------------------------------------------------------------------------
		--DECLARE cur3 CURSOR FOR
		--	select FK_Aplicacion, Fk_menu, Fk_Plantel  from UsuariosPlanteles 			
		--		Where Fk_usuario = @usuarioPadre

		--OPEN cur3
		--FETCH NEXT FROM cur3 INTO @App, @mnulnk, @Plantel
		--WHILE @@fetch_status = 0
		--	BEGIN 			
		--		set @Existe = 0	  
		--		if not exists(Select * From UsuariosPlanteles Where Fk_usuario = @usuarioHijo and Fk_Plantel = @Plantel and FK_Aplicacion = @App
		--						and Fk_menu =  @mnulnk)  
		--		begin      
		--				insert into UsuariosPlanteles(Fk_usuario, FK_Aplicacion, Fk_menu, Fk_Plantel)
		--				values(@usuarioHijo, @App, @mnulnk, @Plantel)
						
		--				SET @res = 2					
		--		END	
		--		ELSE
		--		BEGIN
		--			SET @res = 1
		--		END																
		--		FETCH NEXT FROM cur3 INTO @App, @mnulnk, @Plantel
		--	END	  
		--CLOSE cur3
		--DEALLOCATE cur3

		print 'Respuesta 2 Planteles->' + cast(@res as varchar)
		-------------------------------------------------------------------------
		--Copia Botones del Usuarios
		-------------------------------------------------------------------------
		DECLARE curB CURSOR FOR
			select FK_BotonMenu  from Permisos_UsuariosBotones 			
				Where FK_PermisoUsuario = @usuarioPadre

		OPEN curB
		FETCH NEXT FROM curB INTO @mnuBoton
		WHILE @@fetch_status = 0
			BEGIN 			
				set @Existe = 0	  
				if not exists(Select * From Permisos_UsuariosBotones Where FK_PermisoUsuario = @usuarioHijo and FK_BotonMenu = @mnuBoton)  
					begin      
						insert into Permisos_UsuariosBotones(FK_BotonMenu, FK_PermisoUsuario)
						values(@mnuBoton, @usuarioHijo)
						
						SET @res = 2					
					END
				ELSE
					BEGIN
						SET @res = 1
					END																	
				FETCH NEXT FROM curB INTO @mnuBoton
			END	  
		CLOSE curB
		DEALLOCATE curB
		print 'Respuesta 3 Botones->' + cast(@res as varchar)
	SELECT @res 'Respuesta'

	
GO

/****** Object: spAddMenuUsuario ******/

--spAddMenuUsuario 2,3,3,1
CREATE procedure [dbo].[spAddMenuUsuario]
  @Usuario int,
  @Menu int,
  @Seguridad int,  
  @intApp int
AS  
	DECLARE @InsertedRows AS TABLE (Id int)
	Declare @nivel1 int, @nivel2 int, @nivel3 int, @nivel4 int, @nivel5 int,
			@idMenuUsuKey int, @MenuUsuario int, @res int
	Declare @existe int, @regresa int, @regresa1 int

	 ----------------------------------------------------------------
  -- Verifica que exista la tabla temporal y si existe la Elimina
  ----------------------------------------------------------------
   IF exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[#Ttmp_Addmenu]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
    begin
      drop table [dbo].[#Ttmp_Addmenu]     
    END 
	IF exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[#Ttmp_Addmenu1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
    begin
      drop table [dbo].[#Ttmp_Addmenu1]     
    END
	---------------------------
	--Genera Tabla Temporal
	---------------------------	
	CREATE table #Ttmp_Addmenu(Cuantos int, menukey int)
	CREATE table #Ttmp_Addmenu1(Cuantos int)
			
	set @nivel1 = 0
	set @nivel2 = 0
	set @nivel3 = 0
	set @nivel4 = 0
	set @nivel5 = 0
	set @res = 0

	
	select @nivel1 =idpadre 
	from menus
	where PK_menu = @Menu
		
	set @MenuUsuario = 0
	set @regresa = 0
	
	insert #Ttmp_Addmenu(cuantos,menukey)
	exec getUsuarioMenus @Menu, @Usuario, @intApp --, @MenuUsuario output, @regresa output 	

	select @regresa = cuantos, @MenuUsuario = menukey
	from #Ttmp_Addmenu
	print 'regresa getUsuarioMenus 0->:' + cast(@regresa as varchar) 
	print 'regresa @MenuUsuario 0->:' + cast(@MenuUsuario as varchar) 
	set @regresa1 = 0
		
	insert #Ttmp_Addmenu1(cuantos)
	exec getMenusPermisos @MenuUsuario, @Seguridad--, @regresa1 output
	select @regresa1 = cuantos from #Ttmp_Addmenu1
	print 'regresa getMenusPermisos 0->:' + cast(@regresa1 as varchar)

	if (@nivel1	<> 0)
	begin
		
		select @nivel2 = idpadre 
			from menus
			where PK_Menu = @nivel1
				
		set @MenuUsuario = 0
		set @regresa = 0
		
		truncate table #Ttmp_Addmenu
		insert #Ttmp_Addmenu(cuantos,menukey)
		exec getUsuarioMenus @nivel1, @Usuario, @intApp--, @MenuUsuario output, @regresa output  --1 =Inserta, 0 = nada
		select @regresa = cuantos, @MenuUsuario = menukey
		from #Ttmp_Addmenu		
		print 'regresa getUsuarioMenus 1->:' + cast(@regresa as varchar)
		set @regresa1 = 0

		truncate table #Ttmp_Addmenu1
		insert #Ttmp_Addmenu1(cuantos)
		exec getMenusPermisos @MenuUsuario, @Seguridad--, @regresa1 output  -- 0 = Modifica , 1 =Inserta
		select @regresa1 = cuantos from #Ttmp_Addmenu1
		print 'regresa getMenusPermisos 1->:' + cast(@regresa1 as varchar)
		set @res = 1     
	end

	if (@nivel1 <> @nivel2)
		begin		
			if (@nivel2 <> 0)
			begin
				
				select @nivel3 = idpadre 
					from menus
					where PK_Menu = @nivel2
			
				set @MenuUsuario = 0
				set @regresa = 0
				
				truncate table #Ttmp_Addmenu
				insert #Ttmp_Addmenu(cuantos,menukey)
				exec getUsuarioMenus @nivel2, @Usuario, @intApp --, @MenuUsuario output, @regresa output  --1 =Inserta, 0 = nada
				select @regresa = cuantos, @MenuUsuario = menukey
				from #Ttmp_Addmenu				
				print 'regresa getUsuarioMenus 2->:' + cast(@regresa as varchar)
				set @regresa1 = 0

				truncate table #Ttmp_Addmenu1
				insert #Ttmp_Addmenu1(cuantos)
				exec getMenusPermisos @MenuUsuario, @Seguridad--, @regresa1 output -- 0 = Modifica , 1 =Inserta
				select @regresa1 = cuantos from #Ttmp_Addmenu1
				set @res = 2	
				print 'regresa getMenusPermisos 2->:' + cast(@regresa1 as varchar)	
				print 'regresa @res ->:' + cast(@res as varchar)									
			end
			
			if (@nivel2 <> @nivel3)
				begin					
					if (@nivel3 <> 0)
						begin
							
							select @nivel4 = idpadre
								from menus
								where PK_Menu = @nivel3
							
							set @MenuUsuario = 0
							set @regresa = 0
							
							truncate table #Ttmp_Addmenu
							insert #Ttmp_Addmenu(cuantos,menukey)
							exec getUsuarioMenus @nivel3, @Usuario, @intApp--, @MenuUsuario output, @regresa output 
							select @regresa = cuantos, @MenuUsuario = menukey
							from #Ttmp_Addmenu 
							print 'regresa getUsuarioMenus 3->:' + cast(@regresa as varchar)
							set @regresa1 = 0
							
							truncate table #Ttmp_Addmenu1
							insert #Ttmp_Addmenu1(cuantos)
							exec getMenusPermisos @MenuUsuario, @Seguridad--, @regresa1 output
							select @regresa1 = cuantos from #Ttmp_Addmenu1
							print 'regresa getMenusPermisos 3->:' + cast(@regresa1 as varchar)
							set @res = 3						
						end

					if (@nivel3 <> @nivel4)
						begin							
							if (@nivel4 <> 0)
								begin
									
									select @nivel5 = idpadre
										from menus
										where PK_Menu = @nivel4
									
									set @MenuUsuario = 0
									set @regresa = 0
									
									truncate table #Ttmp_Addmenu
									insert #Ttmp_Addmenu(cuantos,menukey)
									exec getUsuarioMenus @nivel4, @Usuario, @intApp--, @MenuUsuario output, @regresa output 
									select @regresa = cuantos, @MenuUsuario = menukey
									from #Ttmp_Addmenu
									print 'regresa getUsuarioMenus 4->:' + cast(@regresa as varchar) 
									set @regresa1 = 0
									
									truncate table #Ttmp_Addmenu1
									insert #Ttmp_Addmenu1(cuantos)
									exec getMenusPermisos @MenuUsuario, @Seguridad--, @regresa1 output
									select @regresa1 = cuantos from #Ttmp_Addmenu1
									print 'regresa getMenusPermisos 4->:' + cast(@regresa1 as varchar)
									set @res = 4
								end
						end
				end
				
		end	
	SELECT @res 'Respuesta'	


GO

/****** Object: spAddNotificacion ******/
CREATE procedure [dbo].[spAddNotificacion]
	@usuario int = 0, --En todos manda un cero= 0
	@App int,
    @Mnj varchar(200),
	@Fec datetime,
	@Ldo int,
	@Br int,
	@Tipo int   -- en un usuario mande un cero, para todos 1
AS
	DECLARE @perso int, @intapp int

   --Agrega solo a usuario en especifico
   if (@tipo = 0)
		BEGIN
			insert into Notificaciones(FK_PermisoUsuario, FK_Aplicacion, Mensaje, Fecha, Leido, Borrar)
				values(@usuario, @App, @Mnj, @Fec, @Ldo, @Br)
		END
	--Agrega a todos los Usuarios Conectados en ese Momento
	if (@tipo = 1) 
		BEGIN
			DECLARE cur1 CURSOR FOR
				SELECT FK_PermisoUsuario, FK_Aplicacion from UsuariosLogeados
				WHERE convert(char(10),dtFecha,103) = convert(char(10),@Fec,103)
				  AND bEstado = 1
			OPEN cur1
			FETCH NEXT FROM cur1 INTO @perso, @intapp
			WHILE @@fetch_status = 0
				BEGIN 
					insert into Notificaciones(FK_PermisoUsuario, FK_Aplicacion, Mensaje, Fecha, Leido, Borrar)
						values(@perso, @intapp, @Mnj, @Fec, @Ldo, @Br)
					FETCH NEXT FROM cur1 INTO @perso, @intapp
				END
			CLOSE cur1
			DEALLOCATE cur1
		END
		select @@error as respuesta

GO

/****** Object: spAddUsuario ******/
CREATE PROC [dbo].[spAddUsuario]
       @vchUsuo varchar(50),
       @vchUsuSis varchar(50),
       @vchnomina varchar(10),
       @vchEmail varchar(50),
       @bActivo bit,
       @idPlantel varchar(5),
       @dttFechaNac date,
       @idapp int,
       @bAdmin bit,
       @vchImagen text,
	   @ListaApps varchar(max),
	   @vchNombre varchar(50),
	   @vchPaterno varchar(50),
	   @vchMaterno varchar(50),
	   @vchClaveDepto varchar(5),
	   @vchDescDepto varchar(100),
	   @vchDescPuesto varchar(200)
AS

       DECLARE @res int, @idUsuario int
	   DECLARE @vchNomFenix varchar(20)


	   select @vchNomFenix = REPLICATE('0', 10- LEN( @vchNomina)) + @vchNomina


       IF not exists(Select * from Permisos_Usuarios WHERE No_nomina = @vchNomFenix
                           AND vchUsuario = @vchUsuo)
       BEGIN
             INSERT into Permisos_Usuarios([vchUsuario],[vchUsuarioSistema],[No_nomina],
                                                      [vchCorreo],[vchContraseña],[bitActivo],[FK_Plantel],[bitVerificacion],
                                                      [intAutenticacion],[bitLoggeado],[dttFechaCreacion],[Imagen],[bitAdmn],
													  dtFechaNacimiento,[vchNombre],[vchPaterno],[vchMaterno],[vchClaveDepto],
													  [vchDescDepto],[vchDescPuesto])
             VALUES(@vchUsuo, @vchUsuSis, @vchNomFenix, @vchEmail,'0', @bActivo, @idPlantel, 'false', 1, 
               'true', getdate(),@vchImagen, @bAdmin, @dttFechaNac,@vchNombre, @vchPaterno, @vchMaterno, @vchClaveDepto, @vchDescDepto, @vchDescPuesto)

             SET @idUsuario = @@identity
----------------------------------------------------------------inserta las aplicaciones--------------------------------

             insert AplicacionesUsuarios 
			--SELECT @idapp, @idUsuario
			SELECT value, @idUsuario
			FROM OPENJSON(@ListaApps) 
			where value not in(
								SELECT FK_Aplicacion from AplicacionesUsuarios as AU
									INNER JOIN OPENJSON(@ListaApps) AS APPS
										 ON AU.FK_Aplicacion= APPS.value
								where AU.FK_PermisoUsuario = @idUsuario )

--select  * from AplicacionesUsuarios
--FOR JSON AUTO
--ALTER DATABASE ELYON_dbPermisos SET COMPATIBILITY_LEVEL = 130
--SELECT compatibility_level FROM sys.databases WHERE name = 'ELYON_dbPermisos';  
			
				

             SET @res = 1
       END    
       ELSE
       BEGIN
             select @idUsuario = PK_PermisoUsuario from Permisos_Usuarios WHERE No_nomina = @vchNomFenix
                                                                                              AND vchUsuario = @vchUsuo 
             if     not exists (select * from AplicacionesUsuarios 
                                        where FK_Aplicacion = @idapp and FK_PermisoUsuario = @idUsuario)
                    begin
       
                           insert AplicacionesUsuarios --SELECT @idapp, @idUsuario
									SELECT value, @idUsuario
									FROM OPENJSON(@ListaApps) 
									where value not in(
												SELECT FK_Aplicacion from AplicacionesUsuarios as AU
												INNER JOIN OPENJSON(@ListaApps) AS APPS
												 ON AU.FK_Aplicacion= APPS.value
												where AU.FK_PermisoUsuario = @idUsuario )

                           SET @res = 1

                    end
                    else
                    begin
                           SET @res = 0
                    end
       END
       
       SELECT @res 'Respuesta'
GO

/****** Object: spADDValidacionesUsuario ******/
CREATE procedure spADDValidacionesUsuario
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

/****** Object: spBuscarPersonas ******/
CREATE procedure [dbo].[spBuscarPersonas]
	@Nombres varchar(100),		
	@IdApp int
AS
	Declare @rut varchar(200)	
	
	if @Nombres = ''
	BEGIN
		set @Nombres = null
	END
		
	IF (@Nombres is null)
	BEGIN
		SELECT U.Pk_PermisoUsuario as UsuarioID
			, U.vchUsuario as 'USUARIO'
			, U.vchNombre as 'Nombres'
			, U.vchPaterno as 'Paterno'
			, U.vchMaterno as 'Materno'
			--, U.vchNombre as 'Nombres'
			--, U.vchPaterno as 'Paterno'
			--, U.vchMaterno as 'Materno'
			, U.BitActivo as 'Estatus'
			, U.Imagen as 'imagen' 
			 ,U.bitAdmn	AS	[ADMIN]
		FROM [Permisos_Usuarios] as U 
			INNER JOIN AplicacionesUsuarios AU
				ON U.PK_PermisoUsuario = AU.FK_PermisoUsuario
			--LEFT JOIN persona P
			--	ON U.No_nomina = P.Matricula
			--LEFT JOIN [morpheus].sagu.dbo.persona P
			--	ON U.No_Nomina = P.Matricula collate Modern_Spanish_CI_AS						
		WHERE AU.FK_Aplicacion = @IdApp
		    AND U.BitActivo in (1)	
			
	END
	ELSE
	BEGIN
		SELECT U.Pk_PermisoUsuario as UsuarioID
			, U.vchUsuario as 'USUARIO'
			, U.vchNombre as 'Nombres'
			, U.vchPaterno as 'Paterno'
			, U.vchMaterno as 'Materno'
			--, U.vchNombre as 'Nombres'
			--, U.vchPaterno as 'Paterno'
			--, U.vchMaterno as 'Materno'
			, U.BitActivo as 'Estatus'
			, U.Imagen as 'imagen' 
			, U.bitAdmn	AS	[ADMIN]
		FROM [Permisos_Usuarios] as U 
			INNER JOIN AplicacionesUsuarios AU
				ON U.PK_PermisoUsuario = AU.FK_PermisoUsuario
			--LEFT JOIN persona P
			--	ON U.No_nomina = P.Matricula
			--LEFT JOIN [morpheus].sagu.dbo.persona P
			--	ON U.No_Nomina = P.Matricula collate Modern_Spanish_CI_AS 
		WHERE  U.BitActivo in (1)
		  AND (U.vchNombre like ('%' + @Nombres + '%') or 
				U.vchPaterno like ('%' +  @Nombres + '%') or
				U.vchMaterno like ('%' +  @Nombres + '%'))
		  AND AU.FK_Aplicacion = @IdApp				
	END 


	
GO

/****** Object: spCargaAppsSeleccion ******/
create procedure [dbo].[spCargaAppsSeleccion] 
	@Usuario int
as	
	----------------------------------------------------------------
	-- Verifica que exista la tabla temporal y si existe la Elimina
	----------------------------------------------------------------
	IF OBJECT_ID( N'tempdb..#TmpCargaAppActivas') IS NOT NULL		
    begin
      drop table [dbo].[#TmpCargaAppActivas]     
    END 
	
	SELECT * into #TmpCargaAppActivas 	
	FROM (SELECT [PK_Aplicacion]
      ,[NombreAplicacion]
	  ,[NombreLargoAplicacion]
      ,cast(0 as bit) as [Estatus]	
	FROM [dbo].[Aplicaciones]
	WHERE [Estatus] = 1
	) AS TMP

	update #TmpCargaAppActivas SET [Estatus] = 1
	where [PK_Aplicacion] in (select FK_Aplicacion from [dbo].[AplicacionesUsuarios] AS CD
				where  CD.FK_PermisoUsuario = @Usuario)		

	SELECT [PK_Aplicacion] AS ID 
      ,[NombreAplicacion]	AS [Nombre]
	  ,[NombreLargoAplicacion] AS [NombreLargo]
      ,[Estatus]	 
	from #TmpCargaAppActivas	
	ORDER BY ID
	FOR JSON AUTO--,  WITHOUT_ARRAY_WRAPPER
GO

/****** Object: spCargaAvisos ******/
create procedure spCargaAvisos
AS
	SELECT 
	PK_AvisoImg
	,Orden
	,CASE Estatus
		WHEN 1 THEN 'Activa'
		WHEN 0 THEN 'Inactiva'
	END Estatus
	FROM AvisosImg
	

GO

/****** Object: spCargaAvisosImg ******/
create procedure spCargaAvisosImg
AS
	SELECT * FROM AvisosImg
	WHERE estatus = 1
	order by orden

GO

/****** Object: SpCargaBotonesmenus ******/
create procedure [dbo].[SpCargaBotonesmenus]
	@IdMenu int
AS
	SELECT PK_BotonMenu as ID
		--, Fk_Menus AS IDMenu
		, vchIDBoton AS IDBoton
		, vchDescripcion  AS DESCRIPCION
		, EstatusBoton AS ESTATUS 
	FROM Botones_menus
	WHERE Fk_Menus = @IdMenu
GO

/****** Object: spCargaBotonesUsuarioMenu ******/
create procedure [dbo].[spCargaBotonesUsuarioMenu]	
	@Usuario int,
	@IdMenu int
as	
	----------------------------------------------------------------
	-- Verifica que exista la tabla temporal y si existe la Elimina
	----------------------------------------------------------------
	IF OBJECT_ID( N'tempdb..#TmpCargaBotonesMenuUsuario') IS NOT NULL		
    begin
      drop table [dbo].[#TmpCargaBotonesMenuUsuario]     
    END 
	
	SELECT * into #TmpCargaBotonesMenuUsuario 	
	FROM (SELECT PK_BotonMenu as ID		
		, vchIDBoton as IDBOTON
		, vchDescripcion as Descripcion
		, cast(0 as bit) AS Seleccion	
	FROM Botones_menus
	WHERE EstatusBoton = 1
		AND Fk_Menus = @IdMenu
	) AS TMP

	update #TmpCargaBotonesMenuUsuario SET Seleccion = 1
	where ID in (select FK_BotonMenu from Permisos_UsuariosBotones AS CD
				where  CD.FK_PermisoUsuario = @Usuario)		
	select ID
			, IDBOTON
			, Descripcion as Descripcion
			, CAST(Seleccion as bit) as Seleccion 
	from #TmpCargaBotonesMenuUsuario	
	ORDER BY ID
GO

/****** Object: spCargarApps ******/
--------------------------------------------------------------------
CREATE procedure [dbo].[spCargarApps]
as

SELECT  [PK_Aplicacion] AS ID 
      ,[NombreAplicacion]	AS [Nombre]
	  ,[NombreLargoAplicacion] AS [NombreLargo]
      ,[Estatus]
  FROM [Aplicaciones]
FOR JSON AUTO--,  WITHOUT_ARRAY_WRAPPER
GO

/****** Object: spDatosEmail ******/
create procedure [dbo].[spDatosEmail]
@App	int

as

select --PK_ElyonParametro ID
		--, FK_Aplicacion APP
		 vchUsuarioEnvia [USUARIO_ENVIA]
		, vchContraseñaEnvia [CONTRASEÑA]
		, vchServerMail [SERVIDOR_SALIDA]
		, vchPuertoMail [PUERTO]
		--, vchRutaImagenAlumno [RUTA_IMAGEN]
		--, bEstatus [ESTATUS]
		--, FK_ParametroConvenio [ID_CONVENIO]
		--, Folio 
	FROM Elyon_Parametros	
	where FK_Aplicacion = 1
	for json path

GO

/****** Object: spDELAplicaciones ******/
create procedure [dbo].[spDELAplicaciones]
	@idApp int
AS
	if Exists(SELECT * FROM Aplicaciones Where PK_Aplicacion = @idApp)
	BEGIN
		DELETE  FROM Aplicaciones WHERE PK_Aplicacion = @idApp
	END
	select @@error as respuesta
GO

/****** Object: SpDELBotonesmenus ******/
create procedure [dbo].[SpDELBotonesmenus]
	@IdMenu int
AS
	IF EXISTS(SELECT * FROM Botones_menus WHERE PK_BotonMenu = @IdMenu)
	BEGIN
		DELETE FROM Botones_menus
		WHERE PK_BotonMenu = @IdMenu
	END

	SELECT @@error AS 'Respuesta'
GO

/****** Object: spDelValidacionesUsuarios ******/
Create procedure spDelValidacionesUsuarios
	@id int
AS
	
	IF exists(SELECT * FROM ValidacionesUsuarios WHERE PK_ValidacionUsuario = @id)
		BEGIN
			DELETE FROM ValidacionesUsuarios WHERE PK_ValidacionUsuario = @id	
		END
			
	select @@error as respuesta

GO

/****** Object: spjsonNivelSeguridad ******/
create Procedure [dbo].[spjsonNivelSeguridad]
AS
	SELECT * FROM NivelesSeguridad
	for json auto

GO

/****** Object: spModificaContraseña ******/
create PROC spModificaContraseña 
	 @vchUsuario	VARCHAR(50)	
	,@vchContraseña text	
	,@pVez int
AS
	DECLARE @res int 

	IF (@pVez = 1)
	BEGIN
		--Esta opcion es para reiniciar pero se debe cambiar al entrar
		if exists (SELECT * FROM Permisos_Usuarios WHERE vchUsuario	= @vchUsuario)
		BEGIN
			UPDATE Permisos_Usuarios SET vchContraseña = @vchContraseña,
										 bitVerificacion = 'false'									 
			WHERE vchUsuario	= @vchUsuario
				
			SET @res = 1
		END
	END
	
	--Esta opcion es para cambiar Clave
	IF (@pVez = 2)
	BEGIN
		if exists (SELECT * FROM Permisos_Usuarios WHERE vchUsuario	= @vchUsuario)
		BEGIN
			UPDATE Permisos_Usuarios SET vchContraseña = @vchContraseña,
									 bitVerificacion = 'true'
			WHERE vchUsuario	= @vchUsuario
				
			SET @res = 2
		END
	END
	SELECT @res 'Respuesta'

GO

/****** Object: spModUsuario ******/
create PROCEDURE [dbo].[spModUsuario]
       @vchUsuo varchar(50),
       @vchUsuSis varchar(50),      
       @vchEmail varchar(50),
       @bActivo bit,      
       @bAdmin bit       
AS
	IF exists(Select * from Permisos_Usuarios WHERE vchUsuario = @vchUsuo)
       BEGIN
			UPDATE Permisos_Usuarios set [vchUsuarioSistema] = @vchUsuSis,
										 [vchCorreo] = @vchEmail,
                                         [bitActivo] = @bActivo,
										 [bitAdmn] = @bAdmin													  
			WHERE vchUsuario = @vchUsuo
	   END
	   select @@ERROR as 'Respuesta'
GO

/****** Object: SpModValidaUsuarioLogeado ******/
create procedure [dbo].[SpModValidaUsuarioLogeado]
	@Usuario int,
	@App int,
	@Estado int
AS

	--Cierra todas las sessiones Anteriores al dia de Hoy que esten abiertas
	UPDATE UsuariosLogeados SET bEstado = 0
	WHERE FK_PermisoUsuario = @Usuario AND FK_Aplicacion = @App 
	  and convert(char(10),dtFecha,103) < convert(char(10),getdate(),103)
	  and bEstado = 1

	IF NOT EXISTS (SELECT * FROM  UsuariosLogeados
				WHERE FK_PermisoUsuario = @Usuario AND FK_Aplicacion = @App 
					and convert(char(10),dtFecha,103) = convert(char(10),getdate(),103))
	BEGIN
		INSERT UsuariosLogeados select @Usuario, @App, getdate(), @Estado		
	END
	ELSE
	BEGIN
		UPDATE UsuariosLogeados SET bEstado = @Estado
		WHERE FK_PermisoUsuario = @Usuario AND FK_Aplicacion = @App
		  and convert(char(10),dtFecha,103) = convert(char(10),getdate(),103)
	END
	select @@error as respuesta

GO

/****** Object: spObtenerMenuAccesos ******/
CREATE procedure [dbo].[spObtenerMenuAccesos]	
	@intTipo int,	
	@idApp int,
	@idusuario int
AS
	DECLARE @IDSeguridad int

	SELECT @IDSeguridad = [SeguridadAdmin] FROM [dbo].[Permisos_Usuarios]
	WHERE [PK_PermisoUsuario] = @idusuario

	if (@intTipo = 1) --WEB
		BEGIN					
			SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, 
				   FK_TipoProceso, Ruta, ArmaMenu, tipo
			FROM dbo.Menus as men
						--inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
			WHERE men.EstatusProceso = 1
			  AND men.Fk_Aplicacion = @idApp 			 							
			  AND (men.FormaWeb is not null and men.FormaWeb <> '')
			order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion			
		END

	if (@intTipo = 0) --Escritorio
		BEGIN  			
			IF (@IDSeguridad = 1)
			BEGIN
				SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, 
					   FK_TipoProceso, Ruta, ArmaMenu, tipo
				FROM dbo.Menus as men
				--inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
				WHERE men.EstatusProceso = 1 
					AND men.Fk_Aplicacion = @idApp															
					AND (men.FormaEscritorio is not null and men.FormaEscritorio <> '')					
				order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion
			END
			ELSE
			BEGIN	
				SELECT PK_Menu, rtrim(NombreProceso) as NombreProceso, NivelProceso, idPadre, EstatusProceso,NivelNavegacion, 
					   FK_TipoProceso, Ruta, ArmaMenu, tipo
				FROM dbo.Menus as men
				--inner join MenusUsuarios as Mu on men.PK_menu = mu.FK_Menu
				WHERE men.EstatusProceso = 1 
					AND men.Fk_Aplicacion = @idApp															
					AND (men.FormaEscritorio is not null and men.FormaEscritorio <> '')
					AND men.[Administrador] = 0
				order by FK_TipoProceso, NivelProceso,idpadre,NivelNavegacion			
			END
		END		


GO

/****** Object: spObtieneApps ******/

create procedure [dbo].[spObtieneApps]

as

SELECT  [PK_Aplicacion] AS ID 
      ,[NombreAplicacion]	AS [Nombre]
	  ,[NombreLargoAplicacion] AS [NombreLargo]
      ,[Estatus]
  FROM [Aplicaciones]
WHERE Estatus = 1
FOR JSON AUTO--,  WITHOUT_ARRAY_WRAPPER
GO

/****** Object: spObtieneAvisoKey ******/
create procedure spObtieneAvisoKey 
	@idAviso int
AS
	SELECT *
	FROM AvisosImg
	WHERE Pk_Avisoimg = @idAviso

GO

/****** Object: spObtieneClaveNivelSeguridad ******/
CREATE Procedure [dbo].[spObtieneClaveNivelSeguridad]
	@Cve int
AS
	SELECT count(*) FROM NivelesSeguridad
		where Nivel = @Cve

GO

/****** Object: spObtieneMensajeProceso ******/
CREATE procedure [dbo].[spObtieneMensajeProceso]
	@Prog varchar(100)
AS
	Select MensajeProceso, siglasproceso from menus
		where FormaEscritorio = @Prog

GO

/****** Object: spObtienePanteles ******/
create procedure spObtienePanteles
AS
	SELECT * FROM Planteles

GO

/****** Object: spObtienePantelesSAGU ******/
create procedure [dbo].[spObtienePantelesSAGU]
AS
	Select PK_Plantel AS  ID
		, vchNombre AS DESCRIPCION
	FROM [dbo].[Planteles]
	WHERE bitActivo = 1

GO

/****** Object: spObtieneParametros ******/
create procedure spObtieneParametros
AS
	select * from Elyon_Parametros	

GO

/****** Object: spObtieneTipoProceso ******/
CREATE procedure [dbo].[spObtieneTipoProceso]
	@cve char(3)
AS
	select count(*) from TipoProceso
	where ClaveTipoProceso = @cve

GO

/****** Object: spObtieneTotalAvisos ******/
create procedure spObtieneTotalAvisos
AS
	SELECT count(*) + 1
	FROM AvisosImg
	WHERE estatus = 1

GO

/****** Object: spr_ObtenerUsuario ******/
CREATE PROC [dbo].[spr_ObtenerUsuario]
	@vchUsuario			VARCHAR(50)
	,@IdApp int
AS
	SELECT 
			 U.vchNombre				AS	[Nombre]
			,U.vchPaterno				AS	[Apellido Paterno]
			,U.vchMaterno				AS	[Apellido Materno]
			,U.vchCorreo				AS	[Correo]
			,U.vchContraseña			AS	[Contraseña]
			,U.bitActivo				AS	[Activo]
			,U.bitVerificacion			AS	[Verifcado]
			,U.vchUsuarioSistema		AS	[Usuario Sistema]
			,U.vchUsuario				AS  [Usuario]	
			,U.dtFechaNacimiento        AS  [FechaNacimiento]		
			,U.No_Nomina				AS  [NOMINA]
			,U.PK_PermisoUsuario        AS  [IDUSUARIO]
			,U.vchClaveDepto				AS  [CLAVEDEPTO]
			,U.vchDescDepto				AS  [NOMBREDEPTO]
			,U.dttFechaCreacion			AS  [FECHAINICIO]
			,AU.FK_Aplicacion			AS	[IDAPP]
			,U.FK_Plantel				AS	[PLANTEL]
			,U.bitAdmn					AS	[ADMIN]
			,U.imagen                   AS  [IMAGEN]
			,U.vchDescPuesto			AS  [PUESTO]
		FROM 
			Permisos_Usuarios U
			INNER JOIN AplicacionesUsuarios AU
				ON U.PK_PermisoUsuario = AU.FK_PermisoUsuario			
		WHERE U.vchUsuario	= @vchUsuario
			AND AU.FK_Aplicacion = @IdApp		



GO

/****** Object: spr_VerificaUsuario ******/
CREATE  PROC[dbo].[spr_VerificaUsuario] --'jorge.hijar', ' ' , 1
	@vchUsuario		VARCHAR(50)
	,@vchContraseña	VARCHAR(MAX)
	,@IdApp int
AS

IF(LEN(@vchContraseña)>0)
BEGIN
	IF EXISTS(SELECT * FROM Permisos_Usuarios
				WHERE vchUsuario = @vchUsuario
					AND CAST(vchContraseña AS VARCHAR)= @vchContraseña)
	BEGIN
		SELECT cast(1 AS bit) AS Respuesta
	END
	ELSE
	BEGIN
		SELECT cast(0 AS bit) AS Respuesta
	END
END
ELSE
	BEGIN
		SELECT cast(0 AS bit) AS Respuesta
	END



GO

/****** Object: spSEL_ConsultaAccesosUsuarios ******/
CREATE procedure spSEL_ConsultaAccesosUsuarios
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

/****** Object: spSelCargaApp ******/
create procedure [dbo].[spSelCargaApp]
AS
	SELECT [PK_Aplicacion]
      ,[NombreAplicacion]
	  ,[NombreLargoAplicacion]
      ,[Estatus]	
	FROM [Aplicaciones]
	WHERE [Estatus] = 1
GO

/****** Object: spSelCargaConexiones ******/
create procedure spSelCargaConexiones
	@idApp int
AS
	SELECT PK_conn, Tipo from ValueConn V
	INNER JOIN KeyConn K
		ON V.FK_Key = K.PK_Key
	WHERE K.FK_Aplicacion = @idApp

GO

/****** Object: spSelIDBoton ******/
create procedure [dbo].[spSelIDBoton]
	@Usuario int,	
	@IDmenu int,
	@IDboton varchar(50)	
AS

    IF exists(	SELECT BM.vchIDBoton FROM Botones_menus AS BM
					INNER JOIN Permisos_UsuariosBotones AS PB
						ON BM.PK_BotonMenu = PB.FK_BotonMenu
				WHERE BM.EstatusBoton = 1
					AND PB.FK_PermisoUsuario = @Usuario
					AND BM.Fk_Menus = @IDmenu
					AND BM.vchIDBoton = @IDboton)
	BEGIN
		SELECT CAST(1 as bit) as Total
	END
	ELSE
	BEGIN
		SELECT CAST(0 as bit) as Total
	END

GO

/****** Object: spSelMenuPadres ******/
CREATE procedure [dbo].[spSelMenuPadres]
	@App int
AS
	SELECT PK_Menu , NombreProceso
	FROM Menus Mnu
	INNER JOIN TipoProceso TP ON Mnu.FK_TipoProceso = TP.PK_TipoProceso
	WHERE TIPO = 'M'
		AND Mnu.FK_Aplicacion = @App
	order by Mnu.PK_Menu, Mnu.FK_TipoProceso

GO

/****** Object: spSelNotificacion ******/
create procedure [dbo].[spSelNotificacion]
	@usuario int,
	@App int
AS
	Select count(*) as tot from Notificaciones
	  Where FK_PermisoUsuario = @usuario
	    AND FK_Aplicacion = @App
	    AND Leido = 0 
GO

/****** Object: spSelObtieneConexion ******/
create procedure spSelObtieneConexion
	@idApp int,
	@vchTp varchar(50)
AS
	SELECT * from ValueConn V
	INNER JOIN KeyConn K
		ON V.FK_Key = K.PK_Key
	WHERE K.FK_Aplicacion = @idApp
	  AND V.Tipo = @vchTp

GO

/****** Object: spSelObtieneParametros ******/


create procedure [dbo].[spSelObtieneParametros]
	@IDpar int
AS
	select PK_ElyonParametro ID
		, FK_Aplicacion APP
		, vchUsuarioEnvia [USUARIO_ENVIA]
		, vchContraseñaEnvia [CONTRASEÑA]
		, vchServerMail [SERVIDOR_SALIDA]
		, vchPuertoMail [PUERTO]
		, vchRutaImagenAlumno [RUTA_IMAGEN]
		, bEstatus [ESTATUS]		
	FROM Elyon_Parametros
	WHERE PK_ElyonParametro = @IDpar
	AND bEstatus = 1
GO

/****** Object: spSelPkFormaMenu ******/

	create procedure [dbo].[spSelPkFormaMenu]
	@IdApp int,
	@strNombreForma varchar(200)
AS
	SET @strNombreForma = '%' + @strNombreForma

	SELECT PK_Menu from Menus
	WHERE FK_Aplicacion = @IdApp
	  AND FormaEscritorio like @strNombreForma

GO

/****** Object: spSelUsuario ******/
	CREATE PROC [dbo].[spSelUsuario] --'0000000100'
	@vchNomina varchar(20)
AS				
	
DECLARE @vchNomFenix varchar(20)

select @vchNomFenix = REPLICATE('0', 10- LEN( @vchNomina)) + @vchNomina

	select P.vchNombre			AS	[Nombre]
		, P.vchPaterno			AS	[Apellido Paterno]
		, P.vchMaterno			AS	[Apellido Materno]
		, P.dtFechaNacimiento	AS  [FechaNacimiento]
		, P.vchDepartamento 	AS  [DEPTO]
		, P.vchPuesto			AS  [PUESTO]	
	FROM [ELYON_CXC].DBO.Vendedor AS P		
	WHERE P.vchNo_Nomina = @vchNomFenix
GO

/****** Object: spSELValidacionesUsuario ******/
create procedure spSELValidacionesUsuario
	@idUsuario int
AS
	SELECT PK_ValidacionUsuario ID		
		, intCajeroVentas
		, intCancelaVenta 
		, intSoloCancelaVenta
		, intDescripArticulo
		, intSoloDescripArticulo
		, intCantidadVenta
		, intSoloCantidadVenta
		, intNoModPrecio
		, intSoloNoModPrecio
		, intPrecioVenta
		, intSoloPrecioVenta
		, intOtorgaDesc
		, intSoloOtorgaDesc
		, intModDatosCred
		, intSoloModDatosCred
		, intParidadMoneda
		, intSoloParidadMoneda
		, intAbreCajon
	FROM ValidacionesUsuarios
	WHERE Fk_Usuario = @idUsuario

GO

/****** Object: spValidaEmail ******/
CREATE procedure [dbo].[spValidaEmail]
	@vchUsu varchar(50),
	@vchMail varchar(50)
As
	SELECT
			 U.vchNombre				AS	[Nombre]
			,U.vchPaterno				AS	[Apellido Paterno]
			,U.vchMaterno				AS	[Apellido Materno]
			,U.vchCorreo				AS	[Correo]
			,U.vchContraseña			AS	[Contraseña]			
		FROM 
			Permisos_Usuarios U			
		WHERE U.vchUsuario = @vchUsu
		  AND U.vchCorreo = @vchMail

GO

/****** Object: spValidaHijos ******/
CREATE procedure [dbo].[spValidaHijos]
	@IDMenu int,
	@app int
AS
	SELECT count(*) as total FROM Menus
	WHERE (idpadre = @IDMenu AND PK_Menu <> @IDMenu)
	AND FK_Aplicacion = @app

GO

