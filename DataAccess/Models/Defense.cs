using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Defense
    {
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public int Interceptions { get; set; }
        public int Tackles { get; set; }
        public int Sacks { get; set; }
        public int ForcedFumbles { get; set; }
    }
}
