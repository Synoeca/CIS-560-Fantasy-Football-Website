USE Team13;
GO

IF SCHEMA_ID(N'Football') IS NULL
   EXEC(N'CREATE SCHEMA Football;');
GO

-- Team Table
IF OBJECT_ID(N'Football.Team', 'U') IS NULL
	CREATE TABLE Football.Team (
		TeamID INT NOT NULL PRIMARY KEY,
		SchoolName NVARCHAR(255) NOT NULL UNIQUE,
		TeamName VARCHAR(255) NOT NULL,
		City VARCHAR(255) NOT NULL,
		[State] VARCHAR(50) NOT NULL
	);
GO

-- Game Table
IF OBJECT_ID(N'Football.Game', 'U') IS NULL
	CREATE TABLE Football.Game (
		GameID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
		HomeTeam INT NOT NULL,
		AwayTeam INT NOT NULL,
		[Date] DATE NOT NULL,
		[Week] INT NOT NULL,
		HomeTeamScore INT NOT NULL,
		AwayTeamScore INT NOT NULL,
		CONSTRAINT FK_Game_HomeTeam FOREIGN KEY (HomeTeam)
			REFERENCES Football.Team(TeamID),
		CONSTRAINT FK_Game_AwayTeam FOREIGN KEY (AwayTeam)
			REFERENCES Football.Team(TeamID)
	);
GO

-- Seasons Table
IF OBJECT_ID(N'Football.Seasons', 'U') IS NULL
	CREATE TABLE Football.Seasons (
		SeasonID INT NOT NULL PRIMARY KEY,
		GameID INT NOT NULL, -- FORIEGN KEY
		TeamID INT NOT NULL,
		[Year] INT NOT NULL,
		Wins INT NOT NULL,
		Loses INT NOT NULL,
		CONSTRAINT FK_Seasons_Game FOREIGN KEY (GameID)
			REFERENCES Football.Game(GameID),
		CONSTRAINT FK_Seasons_Team FOREIGN KEY (TeamID)
			REFERENCES Football.Team(TeamID)
	);
GO

-- Player Table
IF OBJECT_ID(N'Football.Player', 'U') IS NULL
	CREATE TABLE Football.Player (
		PlayerID INT PRIMARY KEY IDENTITY(1,1),
		[Name] NVARCHAR(50) NOT NULL,
		TeamID INT NOT NULL,
		GameID INT,
		Class NVARCHAR(50) NOT NULL,
		HealthStatus NVARCHAR(50) NOT NULL,
		BenchStatus NVARCHAR(50) NOT NULL,
		CONSTRAINT FK_Player_Team FOREIGN KEY (TeamID)
			REFERENCES Football.Team(TeamID),
		CONSTRAINT FK_Player_Game FOREIGN KEY (GameID)
			REFERENCES Football.Game(GameID)
	);
GO

-- Position Table
IF OBJECT_ID(N'Football.Position', 'U') IS NULL
	CREATE TABLE Football.Position (
		PositionID INT NOT NULL PRIMARY KEY,
		PositionName NVARCHAR(50) NOT NULL UNIQUE
	);
GO

-- FantasyTeam Table
IF OBJECT_ID(N'Football.FantasyTeam', 'U') IS NULL
	CREATE TABLE Football.FantasyTeam (
		FantasyTeamID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
		FantasyTeamName NVARCHAR(255) NOT NULL UNIQUE,
		Wins INT NOT NULL,
		Losses INT NOT NULL
	);
GO

-- SpecialTeams Table
IF OBJECT_ID(N'Football.SpecialTeams', 'U') IS NULL
		CREATE TABLE Football.SpecialTeams (
		PlayerID INT NOT NULL,
		GameID INT NOT NULL,
		FieldGoalsMade INT NOT NULL,
		FieldGoalsAttempted INT NOT NULL,
		ExtraPointsMade INT,
		ExtraPointsAttempted INT,
		ReturnYards INT NOT NULL,
		ReturnAttempts INT NOT NULL,
		CONSTRAINT PK_SpecialTeams PRIMARY KEY (PlayerID, GameID),  -- Composite primary key
		CONSTRAINT FK_SpecialTeams_Game FOREIGN KEY (GameID)
			REFERENCES Football.Game(GameID),
		CONSTRAINT FK_SpecialTeams_Player FOREIGN KEY (PlayerID)
			REFERENCES Football.Player(PlayerID)
	);
GO

-- Defense Table
IF OBJECT_ID(N'Football.Defense', 'U') IS NULL
	CREATE TABLE Football.Defense (
		PlayerID INT NOT NULL,
		GameID INT NOT NULL,
		Interceptions INT NOT NULL,
		Tackles INT,
		Sacks INT NOT NULL,
		ForcedFumbles INT NOT NULL,
		CONSTRAINT PK_Defense PRIMARY KEY (PlayerID, GameID),  -- Composite primary key
		CONSTRAINT FK_Defense_Game FOREIGN KEY (GameID)
			REFERENCES Football.Game(GameID),
		CONSTRAINT FK_Defense_Player FOREIGN KEY (PlayerID)
			REFERENCES Football.Player(PlayerID)
);
GO

-- Offense Table
IF OBJECT_ID(N'Football.Offense', 'U') IS NULL
	CREATE TABLE Football.Offense (
		PlayerID INT NOT NULL,
		GameID INT NOT NULL,
		PassingYards INT NOT NULL,
		PassingAttempts INT NOT NULL,
		RushingYards INT NOT NULL,
		Carries INT NOT NULL,
		ReceivingYards INT NOT NULL,
		Receptions INT NOT NULL,
		Touchdowns INT NOT NULL,
		CONSTRAINT PK_Offense PRIMARY KEY (PlayerID, GameID),  -- Composite primary key
		CONSTRAINT FK_Offense_Game FOREIGN KEY (GameID)
			REFERENCES Football.Game(GameID),
		CONSTRAINT FK_Offense_Player FOREIGN KEY (PlayerID)
			REFERENCES Football.Player(PlayerID)
);
GO

-- FantasyTeamPlayer Table
IF OBJECT_ID(N'Football.FantasyTeamPlayer', 'U') IS NULL
	CREATE TABLE Football.FantasyTeamPlayer (
		PlayerID INT NOT NULL PRIMARY KEY,
		FantasyTeamID INT NOT NULL,
		PositionID INT NOT NULL,
		CONSTRAINT FK_FantasyTeam FOREIGN KEY (FantasyTeamID)
			REFERENCES Football.FantasyTeam(FantasyTeamID),
		CONSTRAINT FK_Position FOREIGN KEY (PositionID)
			REFERENCES Football.Position(PositionID)
	);
GO