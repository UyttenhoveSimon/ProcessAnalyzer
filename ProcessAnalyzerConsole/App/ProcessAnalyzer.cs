using System.Linq;

namespace ProcessAnalyzerConsole.App
{
    internal class ProcessAnalyzer : BaseAnalyzer
    {
        internal string ResultsAverage()
        {
            string averages = string.Empty;
            if (_samples.Count < 1)
            {
                return averages;
            }

            averages += _samples.Average(s => s.CPUUsage) + "\t";
            averages += _samples.Average(s => s.MemoryUsage) + "\t";
            averages += _samples.Average(s => s.HandlesNumber) + "\t";

            return averages;
        }
    }
}