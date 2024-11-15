using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class OffenseQueries
    {
        public static readonly string GetAllOffenses = "SELECT * FROM Football.Offense";

        public static readonly string GetOffenseStatsByPlayerId = "SELECT * FROM Football.Offense WHERE PlayerID = @PlayerID";

        // Add more queries for other CRUD operations (INSERT, UPDATE, DELETE)
    }
}
