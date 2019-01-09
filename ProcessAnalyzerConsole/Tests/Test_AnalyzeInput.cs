using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProcessAnalyzerConsole.Tests
{   
    public class Test_AnalyzeInput
    {
        [Fact]
        public void Test_FirstArgMissing()
        {
            string input = " 123 123";
            var process = ProcessToAnalyze.AnalyzeInput(input);
            Assert.Null(process);
        }

        [Fact]
        public void Test_FirstArgCorrect()
        {
            string input = "dropbox 123 123";
            var process = ProcessToAnalyze.AnalyzeInput(input);
            Assert.Equal("dropbox", process.Name);
        }

        [Fact]
        public void Test_SecondArgMissing()
        {
            string input = "123  123";
            var process = ProcessToAnalyze.AnalyzeInput(input);
            Assert.Null(process);
        }

        [Fact]
        public void Test_ThirdArgMissing()
        {
            string input = "123 123 ";
            var process = ProcessToAnalyze.AnalyzeInput(input);
            Assert.Null(process);
        }

    }
}
