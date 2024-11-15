using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public class SpecialTeamsQueries
    {
        public const string GetAllSpecialTeams = "SELECT * FROM Football.SpecialTeams";

        public static readonly string GetSpecialTeamsStatsByPlayerId = "SELECT * FROM Football.SpecialTeams WHERE PlayerID = @PlayerID";

        // Add more queries for other CRUD operations (INSERT, UPDATE, DELETE)
    }
}
