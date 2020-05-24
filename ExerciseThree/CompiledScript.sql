CREATE TABLE [dbo].[FileSystemType]
(
	[Id]	INT NOT NULL,
	[Name]	VARCHAR(10) NOT NULL,
	CONSTRAINT PK_FileSystemType_Id PRIMARY KEY(Id),
	CONSTRAINT UQ_FileSystemType_Name UNIQUE([Name])
)
GO

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
GO

INSERT INTO [dbo].[FileSystemType] VALUES
(1, 'Directory'),
(2, 'Folder'),
(3, 'File')
GO


SET IDENTITY_INSERT [dbo].[FileSystem] ON 
GO
INSERT INTO [FileSystem] ([Id], [Name], [FileSystemTypeId], [ParentId], [IsReadOnly], [Size]) VALUES (1, 'C:\', 1, NULL, 0, 250000000)
GO
INSERT INTO [FileSystem] ([Id], [Name], [FileSystemTypeId], [ParentId], [IsReadOnly]) VALUES 
(2, 'Folder A', 2, 1, 0),
(3, 'Folder B', 2, 1, 0),
(4, 'Folder C', 2, 1, 0),
(5, 'Folder D', 2, 1, 0),
(6, 'Folder E', 2, 1, 0)
GO
INSERT INTO [FileSystem] ([Id], [Name], [FileSystemTypeId], [ParentId], [IsReadOnly]) VALUES 
(7, 'Folder AA', 2, 2, 0),
(8, 'Folder AB', 2, 2, 0),
(9, 'Folder AC', 2, 2, 0),
(10, 'Folder BA', 2, 3, 0),
(11, 'Folder CA', 2, 3, 0)
GO
INSERT INTO [FileSystem] ([Id], [Name], [FileSystemTypeId], [ParentId], [Size]) VALUES 
(12, 'Item AA1.txt', 3, 7, 100),
(13, 'Item AA2.txt', 3, 7, 100),
(14, 'Item AA3.txt', 3, 7, 100),
(15, 'Item AB1.txt', 3, 8, 100),
(16, 'Item AB2.txt', 3, 8, 100),
(17, 'Item AC1.txt', 3, 9, 100),
(18, 'Item BA1.txt', 3, 10, 100),
(19, 'Item BA2.txt', 3, 10, 100),
(20, 'Item BA3.txt', 3, 10, 100),
(21, 'Item CA1.txt', 3, 11, 100),
(22, 'Item CA2.txt', 3, 11, 100),
(23, 'Item D1.txt', 3, 5, 100),
(24, 'Item D2.txt', 3, 5, 100),
(25, 'Item E1.txt', 3, 6, 100)
GO

SET IDENTITY_INSERT [dbo].[FileSystem] OFF 
GO

CREATE PROCEDURE [dbo].[usp_FileSearch]
	@criteria	VARCHAR(255)
AS
BEGIN
	WITH CTE AS
	(
		SELECT 
			[Id]
			, [ParentId]
			, [Name]
			, [FileSystemTypeId]
			, [IsReadOnly]
			, [CreatedDate]
			, [Size]
			, CAST([Name] AS VARCHAR(MAX)) AS [Path]
		FROM FileSystem
		WHERE [ParentId] IS NULL
	UNION ALL
		SELECT 
			C.Id
			, C.[ParentId]
			, C.[Name]
			, C.[FileSystemTypeId]
			, C.[IsReadOnly]
			, C.[CreatedDate]
			, C.[Size]
			, CAST(CTE.[Path] + '\' + C.[Name] AS VARCHAR(MAX))
		FROM FileSystem C INNER JOIN CTE ON C.[ParentId] = CTE.Id
	)

	SELECT 
		* 
	FROM CTE 
	WHERE		@criteria IS NULL 
				OR [Path] LIKE '%' + @criteria + '%' 
	ORDER BY	LEN([Path]) ASC
END
GO