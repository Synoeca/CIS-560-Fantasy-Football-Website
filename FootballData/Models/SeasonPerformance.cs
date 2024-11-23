using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SeasonPerformance
    {
        public int Season { get; set; }
        public string SchoolName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal WinningPercentage { get; set; }
    }
}
