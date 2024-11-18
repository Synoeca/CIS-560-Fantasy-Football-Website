USE Team13;
GO

-- Insert initial fantasy teams with DraftStatus
INSERT INTO Football.FantasyTeam(FantasyTeamName, Wins, Losses, DraftStatus) 
VALUES 
    (N'Purple Pain', 0, 0, 'Not Started'),
    (N'Maul Patrol', 0, 0, 'Not Started'),
    (N'Beak Breakers', 0, 0, 'Not Started');
GO

IF NOT EXISTS (SELECT 1 FROM Football.DraftStatus)
BEGIN
    INSERT INTO Football.DraftStatus (IsDraftInProgress, CurrentRound, CurrentPosition, TotalTeams)
    VALUES (0, 0, 0, 3);
END
GO
