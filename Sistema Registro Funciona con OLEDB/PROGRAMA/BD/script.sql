USE [master]
GO
/****** Object:  Database [Registro2]    Script Date: 13/05/2014 14:36:49 ******/
CREATE DATABASE [Registro2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Registro2', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Registro2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Registro2_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Registro2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Registro2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Registro2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Registro2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Registro2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Registro2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Registro2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Registro2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Registro2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Registro2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Registro2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Registro2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Registro2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Registro2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Registro2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Registro2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Registro2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Registro2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Registro2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Registro2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Registro2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Registro2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Registro2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Registro2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Registro2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Registro2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Registro2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Registro2] SET  MULTI_USER 
GO
ALTER DATABASE [Registro2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Registro2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Registro2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Registro2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Registro2]
GO
/****** Object:  StoredProcedure [dbo].[Pro_Codigos_Buscar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|749|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Codigos_Buscar]
	@Codigo varchar(30)	
AS
BEGIN
	
	SET NOCOUNT ON;

	Declare @aux int
	If (@Codigo not in (Select Codigo from Pendientes Union Select Codigo from Historico))
	Begin
		Set @aux = 1
	END
	Else
		Set @aux = 0
	 
	
	Select @aux    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Completo_Listar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|728|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Completo_Listar]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	Select Codigo AS 'Codigo', Apellidos AS 'Apellidos', Nombres AS 'Nombres', Fecha AS 'Fecha Ingreso', 'NO' AS Entregado, NULL AS 'Fecha Egreso'
	from Pendientes
	Union 
	Select H.Codigo, P.Apellidos, P.Nombres, H.Fecha, 'SI', H.Fecha_Entrega
	from Historico H 
	inner join Personas P
    on H.Matricula = P.DNI
    order by 'Entregado' ASC
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Entregar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|686|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Entregar]
	@Codigo varchar(50),
	@Matricula int, 
	@Fecha smalldatetime,
	@Direccion varchar(150),
	@Localidad varchar(100),
	@Provincia tinyint,
	@Telefono bigint
AS
BEGIN	
	SET NOCOUNT ON;

	Begin Tran T1
	
	if(@Matricula not in (Select DNI from Personas))
		Begin
			Insert Personas (DNI, Nombres, Apellidos, Direccion, Telefono, Localidad, Id_provincia)
			values (@Matricula, (Select Nombres from Pendientes where Codigo = @Codigo), (Select Apellidos from Pendientes where Codigo = @Codigo), @Direccion, @Telefono,@Localidad,@Provincia)
		End
	Else
		Begin
			Update Personas set Localidad = @Localidad, Id_provincia = @Provincia, Telefono = @Telefono, Direccion = @Direccion
			where DNI = @Matricula
		End	
	if @@ERROR <> 0
	Rollback Tran T1
	Insert Historico (Id_Tramite, Matricula, Fecha_Entrega, Codigo, Fecha, Id_Tipo)
	values ((Select Id_Tramite from Pendientes where Codigo = @Codigo), @Matricula, @Fecha, @Codigo, (Select Fecha from Pendientes where Codigo = @Codigo), (Select Id_Tipo from Pendientes where Codigo = @Codigo))
	if @@ERROR <> 0
	Rollback Tran T1
	Delete Pendientes where Codigo = @Codigo
	if @@ERROR <> 0
	Rollback Tran T1
    Commit Tran T1
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Historico_Buscar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|647|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Historico_Buscar]
	@Codigo varchar(50) = '',
	@Matricula int = '', 
	@Nombres varchar(50) = '',
	@Apellidos varchar(50) = '',
	@Id_Tipo tinyint = '', 
	@Localidad varchar(100) = '',
	@Id_provincia tinyint = '',
	@Fecha smalldatetime = '01/01/1900 12:00:00',
	@Fecha_Entrega smalldatetime = '01/01/1900 12:00:00'
AS
BEGIN
	SET NOCOUNT ON;

    Select H.Codigo, H.Matricula, P.Nombres, P.Apellidos, T.Tipo, H.Fecha, H.Fecha_Entrega, P.Direccion, P.Localidad, PH.Provincias, P.Telefono
	from Historico H
		inner join Personas P
		on H.Matricula = P.DNI
		inner join Tipos T
		on H.Id_Tipo = T.Id_Tipo 
		inner join Provincias PH
		on PH.Id_provincia = P.Id_provincia   
	where 
		((@Codigo = '') OR (@Codigo <> '' AND H.Codigo = @Codigo)) AND
		((@Matricula = '') OR (@Matricula <> '' AND H.Matricula = @Matricula)) AND
		((@Nombres = '') OR (@Nombres <> '' AND P.Nombres LIKE '%' + @Nombres + '%')) AND
		((@Apellidos = '') OR (@Apellidos <> '' AND P.Apellidos LIKE '%' + @Apellidos + '%')) AND
		((@Id_Tipo = 0) OR (@Id_Tipo <> 0 AND H.Id_Tipo = @Id_Tipo)) AND
		((@Localidad = '') OR (@Localidad <> '' AND P.Localidad LIKE '%' + @Localidad + '%')) AND
		((@Id_provincia = 0) OR (@Id_provincia <> 0 AND P.Id_provincia = @Id_provincia)) AND
		((@Fecha = '01/01/1900 12:00:00') OR (@Fecha <> '01/01/1900 12:00:00' AND H.Fecha = @Fecha)) AND
		((@Fecha_Entrega = '01/01/1900 12:00:00') OR (@Fecha_Entrega <> '01/01/1900 12:00:00' AND H.Fecha_Entrega = @Fecha_Entrega))
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Historico_Cancelar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|607|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Historico_Cancelar]
	@Codigo varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

	Begin Tran t1
	Set Identity_Insert Pendientes ON
	Insert into Pendientes (Id_Tramite, Codigo, Nombres, Apellidos, Fecha, Id_Tipo)
	Select H.Id_tramite, H.Codigo, P.Nombres, P.Apellidos, H.Fecha, H.Id_tipo
	from Historico H 
	inner join Personas P
	on H.Matricula = P.DNI
	where H.Codigo = @Codigo
	Set Identity_Insert Pendientes OFF		
	if(@@ERROR <> 0)
	Rollback tran t1
	
	Declare @aux int
	Set @aux = (Select Matricula from Historico where Codigo = @Codigo)
	
	Delete from Historico where Codigo = @Codigo	
	if(@@ERROR <> 0)
	Rollback tran t1	
	
	if (Select (COUNT(*)) from Historico H where Matricula = @aux) < '1'
	Begin
		Delete from Personas where DNI = (Select Matricula from Historico where Codigo = @Codigo)
	End	    
	if(@@ERROR <> 0)
	Rollback tran t1	
	Commit Tran t1
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Historico_Listar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|586|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Historico_Listar]
AS
BEGIN
	SET NOCOUNT ON;

	Select H.Codigo, H.Matricula, P.Nombres, P.Apellidos, H.Fecha, T.Tipo, H.Fecha_Entrega, P.Direccion, P.Localidad, R.Provincias, P.Telefono
	from Historico H
	inner join Personas P
	on H.Matricula = P.DNI
	inner join Tipos T
	on H.Id_Tipo = T.Id_Tipo    	
	inner join Provincias R
	on P.Id_provincia = R.Id_provincia
	order by Apellidos
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Historico_Modificar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|538|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Historico_Modificar]
	@Codigo varchar(50)	= '',
	@Matricula int = '',
	@Fecha smalldatetime = NULL
AS
BEGIN
	
	SET NOCOUNT ON;

    if(@Matricula <> '')
    Begin
		Begin Tran t1
			Declare @Aux int
			Set @Aux = (Select Matricula from Historico where Codigo = @Codigo)				
			Declare @Aux2 int
			Set @Aux2 = '-1'
			Insert Personas (DNI, Apellidos, Nombres, Direccion, Localidad, Id_provincia, Telefono)
			values (@Aux2, 'a', 'a', 'a', 'a', '1', '1');	
			Update Historico Set Matricula = @Aux2
			Where Matricula = @Aux
			If(@Matricula Not in (Select DNI from Personas))
			Begin
				Update Personas	    
				SET DNI = @Matricula
				where DNI = @Aux
			End
			UPDATE Historico
			SET  Matricula = @Matricula
			WHERE Matricula = @Aux2
			Delete Personas
			where DNI = @Aux2			
			if(@@ERROR <> 0)
			Rollback Tran t1
		Commit Tran t1
	End
	if(@Fecha Is Not Null)
	Begin
		UPDATE Historico
		SET  Fecha_Entrega = @Fecha	
		WHERE Codigo = @CODIGO 
	End
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Pendiente_Buscar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|511|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Pendiente_Buscar]
	@Codigo varchar(30) = '',
	@Nombres varchar(50) = '',
	@Apellidos varchar(50) = '',
	@Id_Tipo tinyint = '', 
	@Fecha smalldatetime = '01/01/1900 12:00:00'	
AS
BEGIN
	SET NOCOUNT ON;

    Select P.Codigo, P.Nombres, P.Apellidos, P.Fecha, T.Tipo
	from Pendientes P
		inner join Tipos T
		on P.Id_Tipo = T.Id_Tipo     
	where 
		((@Codigo = '') OR (@Codigo <> '' AND P.Codigo = @Codigo)) AND		
		((@Nombres = '') OR (@Nombres <> '' AND P.Nombres LIKE '%' + @Nombres + '%')) AND
		((@Apellidos = '') OR (@Apellidos <> '' AND P.Apellidos LIKE '%' + @Apellidos + '%')) AND
		((@Id_Tipo = 0) OR (@Id_Tipo <> 0 AND P.Id_Tipo = @Id_Tipo)) AND
		((@Fecha = '01/01/1900 12:00:00') OR (@Fecha <> '01/01/1900 12:00:00' AND P.Fecha = @Fecha))		
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Pendiente_Carga]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|493|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Pendiente_Carga]
	@Codigo varchar(30), 
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Fecha smalldatetime,
	@Id_Tipo tinyint
AS
BEGIN
	SET NOCOUNT ON;
    Insert Pendientes (Codigo, Nombres, Apellidos, Fecha, Id_Tipo)
    values (@Codigo, @Nombres, @Apellidos, @Fecha, @Id_Tipo)
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Pendiente_Listar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|476|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Pendiente_Listar]
AS
BEGIN
	SET NOCOUNT ON;
	
	Select P.Codigo, P.Nombres, P.Apellidos, P.Fecha, T.Tipo
	from Pendientes P
	inner join Tipos T
	on P.Id_Tipo = T.Id_Tipo 
	order by P.Apellidos 
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Pendiente_Modificar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|455|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Pendiente_Modificar]
	@Codigo varchar(50)	,
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Id_tipo int,
	@Fecha smalldatetime
AS
BEGIN

		UPDATE Pendientes 
		SET NOMBRES = @Nombres, APELLIDOS = @Apellidos, FECHA = @Fecha, Id_Tipo = @Id_tipo
		WHERE CODIGO = @CODIGO

   
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Personas_Buscar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|423|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Personas_Buscar]
	@DNI int = '', 
	@Nombres varchar(50) = '',
	@Apellidos varchar(50) = '',
	@Direccion varchar(150) = '',
	@Telefono bigint = '',
	@Localidad varchar(100) = '',
	@Id_provincia tinyint = ''
AS
BEGIN
	
	SET NOCOUNT ON;

    Select P.DNI, P.Nombres, P.Apellidos, P.Direccion, P.Localidad, PR.Provincias, P.Telefono
		from Personas P 
		inner join Provincias PR
		on P.Id_provincia = PR.Id_provincia
    where
		((@DNI = '') OR (@DNI <> '' AND P.DNI = @DNI)) AND		
		((@Nombres = '') OR (@Nombres <> '' AND P.Nombres LIKE '%' + @Nombres + '%')) AND
		((@Apellidos = '') OR (@Apellidos <> '' AND P.Apellidos LIKE '%' + @Apellidos + '%')) AND
		((@Direccion = '') OR (@Direccion <> '' AND P.Direccion = @Direccion)) AND
		((@Telefono = '') OR (@Telefono <> '' AND P.Telefono = @Telefono)) AND
		((@Localidad = '') OR (@Localidad <> '' AND P.Localidad = @Localidad)) AND
		((@Id_provincia = 0) OR (@Id_provincia <> 0 AND P.Id_provincia = @Id_provincia))
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Personas_Listar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|406|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Personas_Listar]
AS
BEGIN
	SET NOCOUNT ON;

	Select P.DNI, P.Apellidos, P.Nombres, P.Direccion, P.Localidad, PR.Provincias, P.Telefono
	from Personas P 
	inner join Provincias PR
	on P.Id_provincia = PR.Id_provincia
	order by Apellidos  
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Personas_Modificar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|377|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Personas_Modificar]
	@DNI int,
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Direccion varchar(150),
	@Localidad varchar(100),
	@Id_Provincia tinyint,
	@Telefono bigint	
AS
BEGIN
	
	SET NOCOUNT ON;
	Update Personas 
	Set 
	Nombres = @Nombres, 
	Apellidos = @Apellidos, 
	Direccion = @Direccion, 
	Localidad = @Localidad, 
	Id_provincia = @Id_Provincia, 
	Telefono = @Telefono
	Where DNI = @DNI
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Provincias_Buscar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|292|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Provincias_Buscar]
	@nombre varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	Select Id_provincia 
	from Provincias
	where Provincias = @nombre
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Provincias_Listar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|276|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Provincias_Listar]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    Select Id_provincia, Provincias 
    from Provincias
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Bajas]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|258|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Bajas]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	
	Select Id_Tipo, Tipo
		from Tipos
		where Habilitado = '0'
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Buscar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|235|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Buscar]
	@Tipo varchar(30)
AS
BEGIN
	
	SET NOCOUNT ON;

    Declare @aux int
	If (@Tipo not in (Select Tipo from Tipos))
	Begin
		Set @aux = 1
	END
	Else
		Set @aux = 0
		
	Select @aux
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Buscar_2]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|217|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
Create PROCEDURE [dbo].[Pro_Tipos_Buscar_2]
	@nombre varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	Select Id_Tipo 
	from Tipos
	where Tipo = @nombre
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Carga]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|200|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Carga]
	@Tipo varchar(30)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	insert Tipos (Tipo) 
	values (@Tipo)
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Deshab]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|185|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Deshab]
	@Id_tipo tinyint
AS
BEGIN	
	SET NOCOUNT ON;

    Update Tipos set Habilitado = '0'
    where Id_Tipo = @Id_tipo    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Listar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|167|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Listar]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	Select Id_Tipo, Tipo 
	from Tipos
	where Habilitado = '1'
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Modificar]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|150|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Modificar]
	@Tipo varchar(30),
	@Id_tipo tinyint
AS
BEGIN
	
	SET NOCOUNT ON;

	Update Tipos set Tipo = @Tipo
	where Id_Tipo = @Id_tipo    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Rehab]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|135|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Rehab]
	@Id_tipo tinyint
AS
BEGIN	
	SET NOCOUNT ON;

    Update Tipos set Habilitado = '1'
    where Id_Tipo = @Id_tipo    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Tipos_Todo]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|118|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Tipos_Todo]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	Select Id_Tipo, Tipo
	from Tipos
    
END

GO
/****** Object:  StoredProcedure [dbo].[Pro_Usuarios_Logueo]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: REGISTRO2.sql|99|0|C:\Users\Notebook\Dropbox\Fede\Sistema\Sistema Registro ORIGINAL\PROGRAMA\BD\REGISTRO2.sql
CREATE PROCEDURE [dbo].[Pro_Usuarios_Logueo] 
	@Usuario varchar(30),
	@Password char(32)
AS
BEGIN	
	SET NOCOUNT ON;

	Declare @aux int = '0';
	If @Password = (Select Password from Usuarios where Usuario = @Usuario)
	Set @aux = '1'
	
    Select @aux
END

GO
/****** Object:  Table [dbo].[Historico]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Historico](
	[Id_Tramite] [int] NOT NULL,
	[Matricula] [int] NOT NULL,
	[Fecha_Entrega] [smalldatetime] NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Id_Tipo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Historico] PRIMARY KEY CLUSTERED 
(
	[Id_Tramite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pendientes]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pendientes](
	[Id_Tramite] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Id_Tipo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Pendientes] PRIMARY KEY CLUSTERED 
(
	[Id_Tramite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personas](
	[DNI] [int] NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Telefono] [bigint] NULL,
	[Localidad] [varchar](100) NULL,
	[Id_provincia] [tinyint] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincias](
	[Id_provincia] [tinyint] IDENTITY(1,1) NOT NULL,
	[Provincias] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[Id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos](
	[Id_Tipo] [tinyint] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/05/2014 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Password] [char](32) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Tipos] ADD  DEFAULT ('1') FOR [Habilitado]
GO
ALTER TABLE [dbo].[Historico]  WITH CHECK ADD  CONSTRAINT [FK_DNI] FOREIGN KEY([Matricula])
REFERENCES [dbo].[Personas] ([DNI])
GO
ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [FK_DNI]
GO
ALTER TABLE [dbo].[Historico]  WITH CHECK ADD  CONSTRAINT [FK_IdTipo_Historico] FOREIGN KEY([Id_Tipo])
REFERENCES [dbo].[Tipos] ([Id_Tipo])
GO
ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [FK_IdTipo_Historico]
GO
ALTER TABLE [dbo].[Pendientes]  WITH CHECK ADD  CONSTRAINT [FK_Id_Tipo] FOREIGN KEY([Id_Tipo])
REFERENCES [dbo].[Tipos] ([Id_Tipo])
GO
ALTER TABLE [dbo].[Pendientes] CHECK CONSTRAINT [FK_Id_Tipo]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Personas] FOREIGN KEY([DNI])
REFERENCES [dbo].[Personas] ([DNI])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Personas]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Provincias] FOREIGN KEY([Id_provincia])
REFERENCES [dbo].[Provincias] ([Id_provincia])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Provincias]
GO
ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD  CONSTRAINT [FK_Provincias_Provincias] FOREIGN KEY([Id_provincia])
REFERENCES [dbo].[Provincias] ([Id_provincia])
GO
ALTER TABLE [dbo].[Provincias] CHECK CONSTRAINT [FK_Provincias_Provincias]
GO
ALTER TABLE [dbo].[Historico]  WITH CHECK ADD  CONSTRAINT [CK_Fecha_Historico] CHECK  (([Fecha_Entrega]>=[Fecha]))
GO
ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [CK_Fecha_Historico]
GO
USE [master]
GO
ALTER DATABASE [Registro2] SET  READ_WRITE 
GO
