CREATE TABLE [dbo].[Inferences](
	[InferenceId] [int] IDENTITY(1, 1) NOT NULL
		CONSTRAINT PK_Inferences_InferenceId PRIMARY KEY,
	[SourceTagId] [int] NOT NULL
		CONSTRAINT FK_Inferences_SourceTagId FOREIGN KEY REFERENCES [dbo].[Tags] (TagId),
	[TargetTagId] [int] NOT NULL
		CONSTRAINT FK_Inferences_TargetTagId FOREIGN KEY REFERENCES [dbo].[Tags] (TagId)
)

GO
