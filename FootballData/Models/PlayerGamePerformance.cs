using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PlayerGamePerformance
    {
        public int PlayerID { get; set; }
        public double AveragePassingAttempts { get; set; }
        public double AverageRushingYards { get; set; }
        public double AverageCarries { get; set; }
        public double AverageReceivingYards { get; set; }
        public double AverageReceptions { get; set; }
        public double AverageTouchdowns { get; set; }
    }
}
