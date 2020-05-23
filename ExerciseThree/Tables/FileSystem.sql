CREATE TABLE [dbo].[FileSystem]
(
	[Id]					INT NOT NULL IDENTITY(1,1),
	[Name]					VARCHAR(255) NOT NULL,
	[FileSystemTypeId]		INT NOT NULL,
	[ParentId]				INT NULL,
	[IsReadOnly]			BIT NOT NULL DEFAULT 0,
	[Size]					BIGINT,
	[CreatedDate]			DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_FileSystem_Id PRIMARY KEY([Id]),
	CONSTRAINT FK_FileSystem_FileSystemTypeId FOREIGN KEY([FileSystemTypeId]) REFERENCES [dbo].[FileSystemType]([Id]),
	CONSTRAINT FK_FileSystem_ParentId FOREIGN KEY([ParentId]) REFERENCES [dbo].[FileSystem]([Id])
)
