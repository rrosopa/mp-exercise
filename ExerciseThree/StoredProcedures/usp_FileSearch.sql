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
	ORDER BY	LEN([Path]) DESC
END
