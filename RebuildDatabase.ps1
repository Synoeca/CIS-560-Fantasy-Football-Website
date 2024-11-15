Param(
   [string] $Server = "(localdb)\MSSQLLocalDb",
   [string] $Database = "team13Db"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name SqlServer;

# Install the SQL Server Module
# Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

<#
   If on your local machine, you can drop and re-create the database.
#>
& ".\Scripts\DropDatabase.ps1" -Database $Database
& ".\Scripts\CreateDatabase.ps1" -Database $Database

<#
   If on the department's server, you don't have permissions to drop or create databases.
   In this case, maintain a script to drop all tables.
#>
#Write-Host "Dropping tables..."
#Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "FootballData\Sql\Tables\DropTables.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "FootballData\Sql\Schemas\Football.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Tables\Football.FantasyTeam.sql"

Write-Host "Stored procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.CreateCritic.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.CreateMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.CreateMovieRolePerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.CreatePerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.CreateReview.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.FetchCritic.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.FetchGenre.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.FetchMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.FetchPerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.FetchRating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.GetMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.GetPerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveCriticReviews.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveCritics.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveGenres.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveGenreSales.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveMovieReviews.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveMoviesFromProducer.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveMoviesInGenre.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveMoviesWithRating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrievePeople.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrievePeopleInMovie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrievePeopleInRole.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveProducers.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveRatings.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveRoles.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveRolesWithPerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveTopPaidInRole.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.RetrieveTopRatedMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Procedures\Movie.UpdateMovie.sql"

Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Genre.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Rating.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Role.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Producer.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Critic.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Person.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Movie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.MovieRolePerson.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MovieData\Sql\Data\Movie.Review.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive