using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Model
{
    internal class DefenceStrategyNode
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public DefenceStrategyNode Left { get; set; }
        public DefenceStrategyNode Right { get; set; }

        public bool InRange(int severity)
        {
            return severity >= MinSeverity && severity <= MaxSeverity;
        }

        public override string ToString() =>
            $"MinSeverity {MinSeverity}," +
            $" MaxSeverity {MaxSeverity}," +
            $" Defenses {string.Join(",", Defenses)}," +
            $" Left {Left}," +
            $" Right{Right}";
        
    }
}
