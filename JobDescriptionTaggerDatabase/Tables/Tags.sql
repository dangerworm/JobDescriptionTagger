CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1, 1) NOT NULL
		CONSTRAINT PK_Tags_TagId PRIMARY KEY,
	[TagName] [varchar](255) NOT NULL,
	[WindowSize] [int] NOT NULL,
	[Ignore] [bit] NOT NULL
		CONSTRAINT DF_Tags_Ignore DEFAULT(0)
)

GO
