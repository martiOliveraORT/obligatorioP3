USE [obligatorioP3]
GO

/****** Object:  Table [dbo].[Actividades]    Script Date: 25/9/2021 19:06:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Actividades](
	[nombre] [nvarchar](50) NOT NULL,
	[edadMin] [int] NOT NULL,
	[edadMax] [int] NOT NULL,
	[horario] [int] NOT NULL,
	[duracion] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


