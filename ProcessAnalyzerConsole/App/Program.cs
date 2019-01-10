using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ProcessAnalyzerConsole.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ProcessAnalyzer");

            string command;

            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                Console.WriteLine(process);
            }

            Console.WriteLine("Input the ProcessName DurationInSeconds SamplingInMilliSeconds ");
            Console.WriteLine("Example: Dropbox 60 1000");

            do
            {
                command = Console.ReadLine();
                try
                {
                    ProcessToAnalyze pTA = ProcessToAnalyze.AnalyzeInput(command);
                    processes = Process.GetProcessesByName(pTA.Name);

                    if (processes != null &&
                        pTA.DurationSeconds.TotalSeconds !=0 &&
                        pTA.SamplingTimeMilliSeconds.TotalMilliseconds !=0 )
                    {
                        List<ProcessToAnalyze> pTAs = new List<ProcessToAnalyze>();
                        foreach (var process in processes)
                        {
                            pTAs.Add(new ProcessToAnalyze(pTA.Name, pTA.DurationSeconds, pTA.SamplingTimeMilliSeconds, process));
                        }
                        Parallel.ForEach(pTAs, processus => processus.InitTimer());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problem during the input analyze " + ex.Message);
                }
            } while (command != "qq");
        }
    }
}