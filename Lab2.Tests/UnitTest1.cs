using System;
using System.IO;
using Xunit;

namespace Lab2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ValidInput()
        {
            string[] lines = { "6", "0110" };  

            var ex = Record.Exception(() => Program.Validate(lines));
            Assert.Null(ex);  
        }

        [Fact]
        public void Test_InputExceedsLimit_N()
        {
            string[] lines = { "0", "0110" };  // N < 2

            var ex = Record.Exception(() => Program.Validate(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("N must be between 2 and 100,000.", ex.Message); 
        }

        [Fact]
        public void Test_InvalidNumberFormat()
        {
            string[] lines = { "abc", "xyz" }; 

            var ex = Record.Exception(() => Program.Validate(lines));
            Assert.NotNull(ex);
            Assert.Equal("The input string 'abc' was not in a correct format.", ex.Message); 
        }


        [Fact]
        public void Test_ProcessingWithNoSolution()
        {
            string[] lines = { "6", "0000" }; 

            string result = Program.ProcessLab2(lines);
            Assert.Equal("No solution", result); 
        }

        [Fact]
        public void Test_ValidResultOutput()
        {
            string[] lines = { "4", "0110" }; 

            string expected = "1101"; 

            string result = Program.ProcessLab2(lines);

            Assert.Equal(expected, result);  
        }

        [Fact]
        public void Test_InvalidNumberOfLines()
        {
            string[] lines = { "5" };  

            var ex = Record.Exception(() => Program.Validate(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("Input must contain exactly two lines.", ex.Message);  
        }
    }
}
