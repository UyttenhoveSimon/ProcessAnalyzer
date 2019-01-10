using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessAnalyzerConsole.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ProcessAnalyzer, here is the processes list:");

            string command;

            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                Console.WriteLine(process.ProcessName);
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
                        pTA.DurationSeconds.TotalSeconds != 0 &&
                        pTA.SamplingTimeMilliSeconds.TotalMilliseconds != 0)
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