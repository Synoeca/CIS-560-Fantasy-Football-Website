USE CIS560;

INSERT INTO Football.Seasons (SeasonID, GameID, TeamID, [Year], Wins, Loses)
VALUES
    -- 2024 Season Records
    (1, 1, 1, 2024, 6, 1),    -- K-State
    (2, 8, 2, 2024, 5, 2),    -- Oklahoma
    (3, 8, 3, 2024, 4, 3),    -- Texas Tech
    (4, 9, 4, 2024, 3, 4),    -- Baylor
    (5, 9, 5, 2024, 4, 3),    -- Iowa State
    (6, 10, 6, 2024, 2, 5),   -- Kansas
    (7, 10, 7, 2024, 5, 2),   -- Oklahoma State
    (8, 7, 8, 2024, 3, 4),    -- TCU
    
    -- 2023 Season Records
    (9, 1, 1, 2023, 10, 4),   -- K-State
    (10, 8, 2, 2023, 10, 3),  -- Oklahoma
    (11, 8, 3, 2023, 7, 6),   -- Texas Tech
    (12, 9, 4, 2023, 6, 7),   -- Baylor
    (13, 9, 5, 2023, 7, 6),   -- Iowa State
    (14, 10, 6, 2023, 9, 4),  -- Kansas
    (15, 10, 7, 2023, 7, 6),  -- Oklahoma State
    (16, 7, 8, 2023, 5, 7);   -- TCU
GO