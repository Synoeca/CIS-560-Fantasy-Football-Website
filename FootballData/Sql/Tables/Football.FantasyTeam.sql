IF OBJECT_ID(N'Football.FantasyTeam') IS NULL
BEGIN
	CREATE TABLE Football.FantasyTeam
	(
		[FantasyTeamID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		[FantasyTeamName] NVARCHAR(100) NOT NULL UNIQUE,
		[PointsScored] DECIMAL(10,2) CHECK(PointsScored >= 0) NOT NULL,
		[Wins] INT NOT NULL CHECK(Wins >= 0),
		[Losses] INT NOT NULL CHECK(Losses >= 0)
	);
END