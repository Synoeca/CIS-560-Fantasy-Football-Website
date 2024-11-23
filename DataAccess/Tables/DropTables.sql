USE Team13;
GO

IF OBJECT_ID(N'Football.FantasyTeamPlayer', 'U') IS NOT NULL
    DROP TABLE Football.FantasyTeamPlayer;
GO

IF OBJECT_ID(N'Football.Position', 'U') IS NOT NULL
    DROP TABLE Football.Position;
GO

IF OBJECT_ID(N'Football.FantasyTeam', 'U') IS NOT NULL
    DROP TABLE Football.FantasyTeam;
GO

IF OBJECT_ID(N'Football.Offense', 'U') IS NOT NULL
    DROP TABLE Football.Offense;
GO

IF OBJECT_ID(N'Football.Defense', 'U') IS NOT NULL
    DROP TABLE Football.Defense;
GO

IF OBJECT_ID(N'Football.SpecialTeams', 'U') IS NOT NULL
    DROP TABLE Football.SpecialTeams;
GO

IF OBJECT_ID(N'Football.Seasons', 'U') IS NOT NULL
    DROP TABLE Football.Seasons;
GO

IF OBJECT_ID(N'Football.Player', 'U') IS NOT NULL
    DROP TABLE Football.Player;
GO

IF OBJECT_ID(N'Football.Game', 'U') IS NOT NULL
    DROP TABLE Football.Game;
GO

IF OBJECT_ID(N'Football.Team', 'U') IS NOT NULL
    DROP TABLE Football.Team;
GO