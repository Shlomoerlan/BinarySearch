using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Model
{
    internal class ThreatModel
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public int CalculateSeverity()
        {
            int targetValue = Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };

            return (Volume * Sophistication) + targetValue;
        }


        public override string ToString() =>
            $"ThreatType: {ThreatType}," +
            $" Volume: {Volume}," +
            $" Sophistication: {Sophistication}," +
            $" Target: {Target}," +
            $" Severity: {CalculateSeverity()}";
    }
}
