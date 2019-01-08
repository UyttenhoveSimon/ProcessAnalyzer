using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessAnalyzerConsole
{
    internal class ProcessToAnalyze
    {
        internal string Name { get; set; }
        internal TimeSpan Duration { get; set; }
        internal TimeSpan SamplingTime { get; set; }
        internal List<UsageSample> UsageSamples { get; set; }

    }
}
