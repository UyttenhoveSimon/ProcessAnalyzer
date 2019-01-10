using System.Collections.Generic;

namespace ProcessAnalyzerConsole.App
{
    internal abstract class BaseAnalyzer
    {
        protected List<UsageSample> _samples;

        internal BaseAnalyzer()
        {
        }

        internal BaseAnalyzer(List<UsageSample> samples)
        {
            _samples = samples;
        }
    }
}