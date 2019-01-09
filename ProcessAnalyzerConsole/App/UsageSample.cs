using System.Diagnostics;

namespace ProcessAnalyzerConsole
{
    internal class UsageSample
    {
        internal float CPUUsage { get; set; }
        internal float MemoryUsage { get; set; }
        internal int HandlesNumber { get; set; }

        internal UsageSample() { }
        internal UsageSample(float cpuUsage, float memoryUsage, int handlesNumber)
        {
            CPUUsage = cpuUsage;
            MemoryUsage = memoryUsage;
            HandlesNumber = handlesNumber;
        }
    }
}
