using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProcessAnalyzerConsole
{
    internal class ProcessToAnalyze
    {
        internal string Name { get; set; }
        internal TimeSpan Duration { get; set; }
        internal TimeSpan SamplingTime { get; set; }
        internal List<UsageSample> UsageSamples { get; set; }

        internal static ProcessToAnalyze AnalyzeInput(string command)
        {
            ProcessToAnalyze processToAnalyze = new ProcessToAnalyze();
            Regex reg = new Regex(@"");
            var matches = reg.Match(command);

            if (matches.Groups[0].Success)
            {

            }

            else if (matches.Groups[1].Success)
            {

            }

            else if (matches.Groups[2].Success)
            {

            }

            else
            {
                Console.WriteLine("Problem with the input, should be ProcessName DurationInSeconds SamplingInMilliSeconds ");
                return null;
            }

            return processToAnalyze;
        }
    }


}
