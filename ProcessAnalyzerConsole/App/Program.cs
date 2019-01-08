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
                    ProcessToAnalyze pTA = ProcessToAnalyze.AnalyzeInput(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problem during the input analyze " + ex.Message);
                }
            } while (command != "qq");
            

        }

        
    }
}
