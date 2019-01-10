using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;

namespace ProcessAnalyzerConsole.App
{
    internal class ProcessToAnalyze
    {
        internal string Name { get; set; }
        internal TimeSpan DurationSeconds { get; set; }
        internal TimeSpan SamplingTimeMilliSeconds { get; set; }
        internal TimeSpan ElapsedTimeMilliSeconds { get; set; }
        internal Timer timerAnalyzer;
        internal List<UsageSample> UsageSamples { get; set; }
        internal Process Process { get; set; }

        private static PerformanceCounter _cpuCounter;
        private static PerformanceCounter _ramCounter;

        internal ProcessToAnalyze()
        {
        }

        internal ProcessToAnalyze(string name, TimeSpan durationSeconds, TimeSpan samplingTimeMilliSeconds, Process process)
        {
            Name = name;
            DurationSeconds = durationSeconds;
            SamplingTimeMilliSeconds = samplingTimeMilliSeconds;
            Process = process;
        }

        internal void InitTimer()
        {
            timerAnalyzer = new Timer(DurationSeconds.TotalSeconds);
            timerAnalyzer.Interval = SamplingTimeMilliSeconds.TotalMilliseconds;
            timerAnalyzer.Elapsed += OnTimedSampling;
        }

        internal void OnTimedSampling(object source, ElapsedEventArgs e)
        {
            ElapsedTimeMilliSeconds += SamplingTimeMilliSeconds;
            if (ElapsedTimeMilliSeconds < DurationSeconds)
            {
                _cpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.ProcessName, true);
                _ramCounter = new PerformanceCounter("Process", "Working Set", Process.ProcessName, true);
                UsageSamples.Add(new UsageSample(_cpuCounter.NextValue(), _ramCounter.NextValue(), Process.HandleCount));
            }
            else
            {
                timerAnalyzer.Stop();
                Console.WriteLine("Timer of the process " + Name + " has finished");
            }
        }

        internal static ProcessToAnalyze AnalyzeInput(string command)
        {
            ProcessToAnalyze processToAnalyze = new ProcessToAnalyze();
            Regex reg = new Regex(@"(\w+)");
            var matches = reg.Matches(command);

            if (matches.Count != 3) //or number of parameters expected
            {
                Console.WriteLine("Problem with the input, should be ProcessName DurationInSeconds SamplingInMilliSeconds ");
                return null;
            }

            processToAnalyze.Name = matches[0].Value;

            if (TimeSpan.TryParse(matches[1].Value, out TimeSpan duration))
            {
                processToAnalyze.DurationSeconds = duration;
            }

            if (TimeSpan.TryParse(matches[2].Value, out TimeSpan samplingTime))
            {
                processToAnalyze.SamplingTimeMilliSeconds = samplingTime;
            }

            return processToAnalyze;
        }
    }
}