CREATE OR ALTER PROCEDURE Football.RetrieveTeamPerformance
	@SeasonID INT
AS
SELECT 
	FS.Year AS Season,
	FT.SchoolName, 
	FT.Wins, 
	FT.Losses, 
	ROUND(((FT.Wins / (FT.Wins + FT.Losses)) * 100), 2) AS WinningPercentage
FROM Football.Season FS
	INNER JOIN Football.Team FT ON FS.SeasonID = FT.SeasonID
WHERE FS.Year = @SeasonID
GROUP BY FT.SchoolName
ORDER BY FS.Year DESC