USE [Personas]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 13/02/2021 1:06:40 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[NumProducto] [varchar](50) NULL,
	[NombreProducto] [varchar](100) NULL,
	[Estado] [bit] NULL,
	[FechaApertura] [datetime] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


