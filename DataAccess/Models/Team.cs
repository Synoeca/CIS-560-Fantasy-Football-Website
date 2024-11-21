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
        public string? SchoolName { get; set; }
        public string? TeamName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public Team (int team, string? school, string? name, string? city, string? state)
        {
            this.TeamID = team;
            this.SchoolName = school;
            this.TeamName = name;
            this.City = city;
            this.State = state;
        }
        public Team ()
        {

        }
    }
}
