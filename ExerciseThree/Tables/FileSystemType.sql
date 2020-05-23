CREATE TABLE [dbo].[FileSystemType]
(
	[Id]	INT NOT NULL,
	[Name]	VARCHAR(10) NOT NULL,
	CONSTRAINT PK_FileSystemType_Id PRIMARY KEY(Id),
	CONSTRAINT UQ_FileSystemType_Name UNIQUE([Name])
)
