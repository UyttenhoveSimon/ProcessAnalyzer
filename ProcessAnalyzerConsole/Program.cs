using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;

namespace ProcessAnalyzerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ProcessAnalyzer");
            Timer timerAnalyzer = new Timer();
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
                    ProcessToAnalyze pTA = AnalyzeInput(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problem during the input analyze " + ex.Message);
                }
            } while (command != "qq");
            

        }

        private static ProcessToAnalyze AnalyzeInput(string command)
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
