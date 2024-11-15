USE CIS560;

INSERT INTO Football.Game (GameID, HomeTeam, AwayTeam, [Date], HomeTeamScore, AwayTeamScore) 
VALUES 
    (1, 1, 2, '2024-09-07', 35, 28),  -- K-State vs Oklahoma
    (2, 1, 3, '2024-09-21', 42, 17),  -- K-State vs Texas Tech
    (3, 4, 1, '2024-10-05', 14, 31),  -- Baylor vs K-State
    (4, 1, 5, '2024-10-19', 28, 21),  -- K-State vs Iowa State
    (5, 6, 1, '2024-11-02', 17, 45),  -- KU vs K-State
    (6, 1, 7, '2024-11-16', 38, 24),  -- K-State vs OSU
    (7, 8, 1, '2024-11-30', 21, 35),  -- TCU vs K-State
    (8, 2, 3, '2024-09-28', 31, 28),  -- Oklahoma vs Texas Tech
    (9, 4, 5, '2024-10-12', 24, 17),  -- Baylor vs Iowa State
    (10, 6, 7, '2024-10-26', 21, 35); -- KU vs OSU
GO
