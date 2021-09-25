USE [obligatorioP3]
GO

/****** Object:  Table [dbo].[Socios]    Script Date: 25/9/2021 19:07:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Socios](
	[cedula] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[fechaNac] [date] NOT NULL,
	[fechaIng] [date] NOT NULL,
 CONSTRAINT [PK_Socios] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


