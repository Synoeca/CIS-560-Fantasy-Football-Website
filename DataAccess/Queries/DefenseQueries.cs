using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class DefenseQueries
    {
        public static readonly string GetAllDefenses = "SELECT * FROM Football.Defense";

        public static readonly string GetDefenseStatsByPlayerId = "SELECT * FROM Football.Defense WHERE PlayerID = @PlayerID";

        // Add more queries for other CRUD operations (INSERT, UPDATE, DELETE)
    }
}
