CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL IDENTITY(1, 1)
		CONSTRAINT PK_Users_UserId PRIMARY KEY,
	[Username] [varchar](50) NULL,
)

GO
