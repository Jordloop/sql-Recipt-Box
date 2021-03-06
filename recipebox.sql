USE [recipebox]
GO
/****** Object:  Table [dbo].[ingredients]    Script Date: 6/14/2017 9:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_ingredients_recipes]    Script Date: 6/14/2017 9:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_ingredients_recipes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_ingredients] [int] NULL,
	[id_recipes] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_recipes_tags]    Script Date: 6/14/2017 9:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[join_recipes_tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_recipes] [int] NULL,
	[id_tags] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[recipes]    Script Date: 6/14/2017 9:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[instructions] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tags]    Script Date: 6/14/2017 9:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
