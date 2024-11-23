-- Update Offense table with matching GameIDs
INSERT INTO Football.Offense (PlayerID, GameID, PassingYards, PassingAttempts, RushingYards, Carries, ReceivingYards, Receptions, Touchdowns)
SELECT DISTINCT 
    p.PlayerID,
    g.GameID,
    CASE WHEN ftp.PositionID = 1 THEN 275 ELSE 0 END,
    CASE WHEN ftp.PositionID = 1 THEN 35 ELSE 0 END,
    CASE WHEN ftp.PositionID = 2 THEN 95 ELSE 0 END,
    CASE WHEN ftp.PositionID = 2 THEN 18 ELSE 0 END,
    CASE WHEN ftp.PositionID IN (4,5) THEN 85 ELSE 0 END,
    CASE WHEN ftp.PositionID IN (4,5) THEN 6 ELSE 0 END,
    CASE 
        WHEN ftp.PositionID = 1 THEN 2
        WHEN ftp.PositionID = 2 THEN 1
        WHEN ftp.PositionID IN (4,5) THEN 1
        ELSE 0
    END
FROM Football.Player p
JOIN Football.FantasyTeamPlayer ftp ON p.PlayerID = ftp.PlayerID
JOIN Football.Game g ON g.HomeTeam = p.TeamID OR g.AwayTeam = p.TeamID
WHERE YEAR(g.[Date]) = 2023
AND ftp.FantasyTeamID IS NOT NULL
AND ftp.PositionID IN (1,2,4,5);

-- Update SpecialTeams table with matching GameIDs
INSERT INTO Football.SpecialTeams (PlayerID, GameID, FieldGoalsMade, FieldGoalsAttempted, ExtraPointsMade, ExtraPointsAttempted)
SELECT DISTINCT
    p.PlayerID,
    g.GameID,
    2, 3, 4, 4
FROM Football.Player p
JOIN Football.FantasyTeamPlayer ftp ON p.PlayerID = ftp.PlayerID
JOIN Football.Game g ON g.HomeTeam = p.TeamID OR g.AwayTeam = p.TeamID
WHERE YEAR(g.[Date]) = 2023
AND ftp.FantasyTeamID IS NOT NULL
AND ftp.PositionID = 11;

-- Verify data
SELECT COUNT(*) 
FROM Football.Offense o
JOIN Football.Game g ON o.GameID = g.GameID
WHERE YEAR(g.[Date]) = 2023;