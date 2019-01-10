using ProcessAnalyzerConsole.App;
using System.Collections.Generic;
using Xunit;

namespace ProcessAnalyzerConsole.Tests
{
    public class Test_LeakAnalyzer
    {
        [Fact]
        public void Test_LeakAnalyzerWithLeak()
        {
            List<UsageSample> samples = new List<UsageSample>();
            samples.Add(new UsageSample(0, 10, 0));
            samples.Add(new UsageSample(0, 10, 0));
            samples.Add(new UsageSample(0, 50, 0));

            LeakAnalyzer lAn = new LeakAnalyzer(samples);
            Assert.True(lAn.CheckLeak(20));
        }

        [Fact]
        public void Test_LeakAnalyzerWithoutLeak()
        {
            List<UsageSample> samples = new List<UsageSample>();
            samples.Add(new UsageSample(0, 10, 0));
            samples.Add(new UsageSample(0, 10, 0));
            samples.Add(new UsageSample(0, 10, 0));

            LeakAnalyzer lAn = new LeakAnalyzer(samples);
            Assert.False(lAn.CheckLeak(20));
        }

        [Fact]
        public void Test_LeakAnalyzerWithoutSamples()
        {
            LeakAnalyzer lAn = new LeakAnalyzer();
            Assert.False(lAn.CheckLeak(0));
        }
    }
}