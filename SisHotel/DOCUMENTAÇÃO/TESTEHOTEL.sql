
CREATE DATABASE SisHotelDb 
GO

USE [SisHotelDb]
GO

/****** Object:  Table [dbo].[hotel]    Script Date: 15/06/2021 17:38:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[hotel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](max) NOT NULL,
	[TipoComodidade] [varchar](20) NOT NULL,
	[avaliacao] [int] NOT NULL,
	[Logradouro] [varchar](60) NOT NULL,
    [Numero] [int] NOT NULL,
    [Complemento] [varchar](45),
    [Estado] [varchar](45) NOT NULL,
    [cidade] [varchar](75) NOT NULL,
	[ativo] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[hotel] ADD  CONSTRAINT [DF_hotel_avaliacao]  DEFAULT ((3)) FOR [avaliacao]
GO

ALTER TABLE [dbo].[hotel] ADD  CONSTRAINT [DF_hotel_ativo]  DEFAULT ((1)) FOR [ativo]
GO


------------------------------------------------------

GO

CREATE PROCEDURE HotelIncluir(
@Nome varchar(50),
@Descricao varchar(MAX),
@TipoComodidade varchar(20),
@avaliacao  int,
@Logradouro varchar(60),
@Numero int,
@Complemento varchar(45),
@Estado varchar(45),
@cidade varchar(75)
)
AS
INSERT INTO hotel(
Nome, 
Descricao, 
TipoComodidade, 
avaliacao, 
Logradouro,
Numero,
Complemento,
Estado,
cidade)
VALUES(
@Nome, 
@Descricao, 
@TipoComodidade, 
@avaliacao, 
@Logradouro ,
@Numero,
@Complemento,
@Estado,
@cidade)

------------------------------------------------------

GO

CREATE PROCEDURE HotelListar
AS
SELECT [id]
      ,[Nome]
      ,[Descricao]
      ,[TipoComodidade]
      ,[avaliacao]
      ,[ativo] 
	  ,[Logradouro] 
	  ,[Numero]
	  ,[Complemento]
	  ,[Estado]
	  [cidade]
	  FROM hotel
	  WHERE ativo <> 0
------------------------------------------------------

GO

CREATE PROCEDURE HotelListarPorId
@id int

AS
SELECT [id]
      ,[Nome]
      ,[Descricao]
      ,[TipoComodidade]
      ,[avaliacao] 
	  ,[Logradouro] 
	  ,[Numero]
	  ,[Complemento]
	  ,[Estado]
	  ,[cidade]
      ,[ativo] 
	  FROM hotel 
	  WHERE id = @id
------------------------------------------------------

GO

CREATE PROCEDURE HotelListaPorNome
@Nome varchar(50)

AS
SELECT [id]
      ,[Nome]
      ,[Descricao]
	  ,[TipoComodidade]
      ,[avaliacao] 
	  ,[Logradouro] 
	  ,[Numero]
	  ,[Complemento]
	  ,[Estado]
	  ,[cidade]
      ,[ativo] 
	  FROM hotel 
	  WHERE Nome LIKE('%'+@Nome+'%') 
	  OR 
	  Descricao LIKE('%'+@Nome+'%') 
------------------------------------------------------

GO

CREATE PROCEDURE HotelDeletar
@id int
AS
UPDATE hotel SET ativo = 0 WHERE id = @id
------------------------------------------------------

GO

CREATE PROCEDURE HotelAtualizar
@id int ,
@Nome varchar(50),
@Descricao varchar(MAX),
@TipoComodidade varchar(20),
@avaliacao int,
@Logradouro varchar(60),
@Numero int,
@Complemento varchar(45),
@Estado varchar(45),
@cidade varchar(75)

AS
UPDATE hotel SET 
Nome=@Nome,
Descricao=@Descricao,
TipoComodidade=TipoComodidade,
avaliacao=@avaliacao, 
Logradouro =@Logradouro, 
Numero=@Numero, 
Complemento=@Complemento,
Estado=@Estado, 
cidade=@cidade 
WHERE id = @id