USE Team13;
GO

INSERT INTO Football.Game (HomeTeam, AwayTeam, [Date], [Week], HomeTeamScore, AwayTeamScore) 
VALUES 
 -- Arizona at Kansas State
 (9, 1, '2024-09-13', 3, 31, 7),

 -- UCF at TCU
 (12, 14, '2024-09-14', 3, 34, 35),

 -- Kansas at West Virginia
 (16, 10, '2024-09-21', 4, 32, 28),

 -- Houston at Cincinnati
 (5, 7, '2024-09-21', 4, 34, 0),

 -- Arizona State at Texas Tech
 (13, 2, '2024-09-21', 4, 30, 22),

 -- Utah at Oklahoma State
 (11, 15, '2024-09-21', 4, 19, 22),

 -- Baylor at Colorado
 (6, 3, '2024-09-21', 4, 7, 0),

 -- West Virginia at Oklahoma State
 (11, 16, '2024-10-05', 6, 14, 38),

 -- Baylor at Iowa State
 (8, 3, '2024-10-05', 6, 43, 21),

 -- Texas Tech at Arizona
 (1, 13, '2024-10-05', 6, 22, 28),

 -- Utah at Arizona State
 (2, 15, '2024-10-11', 7, 27, 19),

 -- Iowa State at West Virginia
 (16, 8, '2024-10-12', 7, 16, 28),

 -- Kansas State at Colorado
 (6, 9, '2024-10-12', 7, 28, 31),


 -- Oklahoma State at BYU
 (4, 11, '2024-10-18', 8, 38, 35),

 -- Baylor at Texas Tech
 (13, 3, '2024-10-19', 8, 35, 59),

 -- Colorado at Arizona
 (1, 6, '2024-10-19', 8, 7, 34),

 -- Kansas State at West Virginia
 (16, 9, '2024-10-19', 8, 18, 45),

 -- Oklahoma State at Baylor
 (3, 11, '2024-10-26', 9, 38, 28),

 -- West Virginia at Arizona
 (1, 16, '2024-10-26', 9, 26, 31),

 -- Utah at Houston
 (7, 15, '2024-10-26', 9, 17, 14),

 -- Kansas at Kansas State
 (9, 10, '2024-10-26', 9, 29, 27),

 -- Texas Tech at Iowa State
 (8, 13, '2024-11-02', 10, 22, 23),

 -- West Virginia at Cincinnati
 (5, 16, '2024-11-09', 11, 24, 31),

 -- Iowa State at Kansas
 (10, 8, '2024-11-09', 11, 45, 36),

 -- Colorado at Texas Tech
 (13, 6, '2024-11-09', 11, 27, 41),

 -- UCF at Arizona State
 (2, 14, '2024-11-09', 11, 35, 31),

 -- Oklahoma State at TCU
 (12, 11, '2024-11-09', 11, 38, 13),

 -- BYU at Utah
 (15, 4, '2024-11-09', 11, 21, 22),

 -- Houston at Arizona
 (1, 7, '2024-11-15', 110, 27, 3);
GO


-- Insert more 2023 Games
INSERT INTO Football.Game (HomeTeam, AwayTeam, [Date], [Week], HomeTeamScore, AwayTeamScore) 
VALUES 
-- September 2023
(1, 2, '2023-09-02', 1, 24, 21),   -- Arizona vs ASU
(3, 4, '2023-09-02', 1, 31, 28),   -- Baylor vs BYU
(5, 6, '2023-09-02', 1, 35, 24),   -- Cincinnati vs Colorado
(7, 8, '2023-09-09', 2, 28, 17),   -- Houston vs Iowa State
(9, 10, '2023-09-09', 2, 42, 35),  -- K-State vs Kansas
(11, 12, '2023-09-16', 3, 31, 24), -- OK State vs TCU
(13, 14, '2023-09-16', 3, 38, 28), -- Texas Tech vs UCF
(15, 16, '2023-09-23', 4, 27, 24), -- Utah vs West Virginia

-- October 2023
(2, 3, '2023-10-07', 6, 35, 31),   -- ASU vs Baylor
(4, 5, '2023-10-07', 6, 28, 21),   -- BYU vs Cincinnati
(6, 7, '2023-10-14', 7, 34, 27),   -- Colorado vs Houston
(8, 9, '2023-10-14', 7, 31, 28),   -- Iowa State vs K-State
(10, 11, '2023-10-21', 8, 45, 38), -- Kansas vs OK State
(12, 13, '2023-10-21', 8, 35, 31), -- TCU vs Texas Tech
(14, 15, '2023-10-28', 9, 24, 21), -- UCF vs Utah
(16, 1, '2023-10-28', 9, 28, 24),  -- West Virginia vs Arizona

-- November 2023
(2, 4, '2023-11-04', 10, 31, 27),  -- ASU vs BYU
(3, 5, '2023-11-04', 10, 35, 28),  -- Baylor vs Cincinnati
(6, 8, '2023-11-11', 11, 28, 24),  -- Colorado vs Iowa State
(7, 9, '2023-11-11', 11, 31, 28),  -- Houston vs K-State
(10, 12, '2023-11-18', 12, 42, 35),-- Kansas vs TCU
(11, 13, '2023-11-18', 12, 38, 35),-- OK State vs Texas Tech
(14, 16, '2023-11-25', 13, 31, 28),-- UCF vs West Virginia
(15, 1, '2023-11-25', 13, 27, 24); -- Utah vs Arizona

-- Add performance data for these games
INSERT INTO Football.Offense (PlayerID, GameID, PassingYards, PassingAttempts, RushingYards, Carries, ReceivingYards, Receptions, Touchdowns)
SELECT p.PlayerID, g.GameID,
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
AND ftp.PositionID IN (1,2,4,5)
AND NOT EXISTS (
    SELECT 1 FROM Football.Offense o 
    WHERE o.PlayerID = p.PlayerID AND o.GameID = g.GameID
);

INSERT INTO Football.SpecialTeams (PlayerID, GameID, FieldGoalsMade, FieldGoalsAttempted, ExtraPointsMade, ExtraPointsAttempted)
SELECT p.PlayerID, g.GameID, 
       2, 3, 4, 4
FROM Football.Player p
JOIN Football.FantasyTeamPlayer ftp ON p.PlayerID = ftp.PlayerID
JOIN Football.Game g ON g.HomeTeam = p.TeamID OR g.AwayTeam = p.TeamID
WHERE YEAR(g.[Date]) = 2023
AND ftp.FantasyTeamID IS NOT NULL
AND ftp.PositionID = 11
AND NOT EXISTS (
    SELECT 1 FROM Football.SpecialTeams st 
    WHERE st.PlayerID = p.PlayerID AND st.GameID = g.GameID
);