using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string SchoolName { get; set; }
        public int SeasonID { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
    }
}
