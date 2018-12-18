USE [loja]
GO

ALTER TABLE [dbo].[Produto] DROP CONSTRAINT [FK_Produto_Categoria]
GO

/****** Object:  Table [dbo].[Produto]    Script Date: 18/12/2018 14:40:32 ******/
DROP TABLE [dbo].[Produto]
GO

/****** Object:  Table [dbo].[Produto]    Script Date: 18/12/2018 14:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produto](
	[Id] [int] NOT NULL,
	[IdCategoria] [int] NULL,
	[Nome] [varchar](50) NULL,
	[Valor] [int] NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO

ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_Categoria]
GO


