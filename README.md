# ProcessAnalyzer

The program is a console application built with .Net Core 2.1 but targets .Net Framework 4.7.1 for the moment as the technology used to monitor the process activity (relying on PerformanceCounter class ) is currently not supported on .Net Core (https://stackify.com/performance-counters-net-core/).

The programs starts, shows the various processes, then asks for : the process name, the sampling duration (in seconds) and the sample period (in milliseconds).

Once input, the process(es) are analyzed accordingly using a timer elapsed event coupled with the PerformanceCounter Class from System.Diagnostics.PerformanceCounter.
