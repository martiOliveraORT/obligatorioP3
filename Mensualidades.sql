USE [obligatorioP3]
GO

/****** Object:  Table [dbo].[Mensualidad]    Script Date: 25/9/2021 19:07:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mensualidad](
	[Tipo] [nvarchar](50) NOT NULL,
	[costo] [decimal](18, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[ciSocio] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[descuento] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Mensualidad] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC,
	[ciSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


