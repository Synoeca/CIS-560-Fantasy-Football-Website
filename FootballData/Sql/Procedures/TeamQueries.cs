using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class TeamQueries
    {
        public static readonly string GetAllTeams = "SELECT * FROM Football.Team";

        public static readonly string GetTeamNameById ="""
                         SELECT TeamName
                         FROM Football.Team
                         WHERE TeamID = @TeamID
           """;
    }
}
