using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public class DBQueries
    {
        public static readonly string CheckDB = """                       
                SELECT COUNT(*) 
                FROM sys.databases 
                WHERE name = 'Team13'
            """;

        public static readonly string CheckSchema = """
                        SELECT COUNT(*) 
                        FROM sys.schemas 
                        WHERE name = 'Football'
            """;

        public static readonly string CheckTable = """
                       SELECT COUNT(*) 
                       FROM sys.tables t 
                       JOIN sys.schemas s ON t.schema_id = s.schema_id 
                       WHERE s.name = 'Football' AND t.name = 'Team'
           """;

        public static readonly string CheckData = "SELECT COUNT(*) FROM Football.Team";
    }
}
