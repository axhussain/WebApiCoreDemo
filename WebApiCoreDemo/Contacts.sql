USE [WebAPI]
GO

/****** Object:  Table [dbo].[Contacts]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[City] [nvarchar](100) NULL,
	[County] [nvarchar](100) NULL,
	[Postcode] [nvarchar](10) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Email] [nvarchar](200) NULL,
	[Web] [nvarchar](1000) NULL,
	CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO
