IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'Football'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [Football] AUTHORIZATION [dbo]');
END;
