CREATE TABLE [dbo].[UserTags](
	[UserId] [int] NOT NULL
		CONSTRAINT FK_UserTags_UserId FOREIGN KEY REFERENCES [dbo].[Users] ([UserId]),
	[TagId] [int] NOT NULL 
		CONSTRAINT [FK_UserTags_TagId] FOREIGN KEY REFERENCES [dbo].[Tags] ([TagId]),
	
	CONSTRAINT [PK_UserTags] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC,
		[TagId] ASC
	)
)

GO
