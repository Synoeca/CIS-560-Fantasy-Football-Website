UPDATE Football.FantasyTeamPlayer
SET FantasyTeamID = 1
WHERE PlayerID IN (
    4,    -- QB (Noah Fifita)
    7,    -- RB (Quali Conley)
    23,   -- WR (Tetairoa McMillan)
    876,  -- RB (Peny Boone)
    887,  -- WR (Kobe Hudson)
    900,  -- TE (Kylan Fox)
    926,  -- PK (Colton Boomer)
    929   -- P (Michael Carter)
);

UPDATE Football.FantasyTeamPlayer
SET FantasyTeamID = 2
WHERE PlayerID IN (
    444,  -- QB (Rocco Becht)
    456,  -- RB (Abu Sama III)
    465,  -- WR (Jayden Higgins)
    595,  -- RB (Devin Neal)
    603,  -- WR (Luke Grimm)
    618,  -- TE (Jaden Hamm)
    644,  -- PK (Tabor Allen)
    647   -- P (Grayden Addison)
);

UPDATE Football.FantasyTeamPlayer
SET FantasyTeamID = 3
WHERE PlayerID IN (
    807,  -- QB (Behren Morton)
    809,  -- RB (Tahj Brooks)
    815,  -- WR (Brady Boyd)
    833,  -- TE (Jalin Conyers)
    879,  -- RB (RJ Harvey)
    887,  -- WR (Kobe Hudson)
    863,  -- PK (Reese Burkhardt)
    866   -- P (Jack Burgess)
);

SELECT 
    ft.FantasyTeamName,
    p.Name,
    pos.PositionName
FROM Football.FantasyTeam ft
JOIN Football.FantasyTeamPlayer ftp ON ft.FantasyTeamID = ftp.FantasyTeamID
JOIN Football.Player p ON ftp.PlayerID = p.PlayerID
JOIN Football.Position pos ON ftp.PositionID = pos.PositionID
ORDER BY ft.FantasyTeamID, pos.PositionID;