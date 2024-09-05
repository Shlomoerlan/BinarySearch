using ExamDataWeek1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service
{
    internal class GetAll
    {

        private const string DefenseStrategyPath = "../../../defence.json";
        private const string ThreatsPath = "../../../threats.json";
        private const string DefenseUnbalancePath = "../../../defenceUnbalance.json";
        public static async Task WriteToJsonFileAsync<T>
            (string filePath, T data, JsonSerializerOptions options = null)
        {
            options ??= new JsonSerializerOptions { WriteIndented = true };
            await using var stream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(stream, data, options);
        }
        public static T? ReadFromJsonAsync<T>
            (string filePath, JsonSerializerOptions options = null)
        {
            try
            {
                options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                T? data = JsonSerializer.Deserialize<T>(
                    File.OpenRead(filePath),
                    options
                );
                return data;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public static List<DefenceStrategyNode> GetAllDefence() =>
           ReadFromJsonAsync<List<DefenceStrategyNode>>(DefenseStrategyPath) ?? [];

        public static List<DefenceStrategyNode> GetAllDefenceUnbalance() =>
           ReadFromJsonAsync<List<DefenceStrategyNode>>(DefenseUnbalancePath) ?? [];

        public static List<ThreatModel> GetAllThreat() =>
           ReadFromJsonAsync<List<ThreatModel>>(ThreatsPath) ?? [];
    }
}
