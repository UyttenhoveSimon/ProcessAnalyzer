using System.Collections.Generic;
using System.Linq;

namespace ProcessAnalyzerConsole.App
{
    internal class LeakAnalyzer : BaseAnalyzer
    {
        internal LeakAnalyzer()
        {
        }

        internal LeakAnalyzer(List<UsageSample> samples) : base(samples)
        {
        }

        internal bool CheckLeak(int percentageLeakLimit)
        {
            if (_samples == null || _samples.Count < 1)
            {
                return false;
            }

            var memUsage = _samples.Average(s => s.MemoryUsage);

            if (_samples.Last().MemoryUsage > (memUsage * (1 + percentageLeakLimit / 100)))
            {
                return true;
            }

            return false;
        }
    }
}