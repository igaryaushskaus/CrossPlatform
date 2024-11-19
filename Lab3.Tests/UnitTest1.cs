using System;
using System.IO;
using Xunit;
using ClassLibraryLab3;

namespace Lab3.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ValidInput()
        {
            string[] lines =
            {
                "3",
                "100 200 300",
                "1 2",
                "0",
                "2 2 1"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.Null(ex);
        }

        [Fact]
        public void Test_InputExceedsLimit_N()
        {
            string[] lines =
            {
                "100001",
                "1 1 1",
                "0",
                "1 1",
                "0"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("n must be between 1 and 100000", ex.Message);
        }

        [Fact]
        public void Test_InputInvalidProductionTime()
        {
            string[] lines =
            {
                "3",
                "100 1000000001 300",
                "1 2",
                "0",
                "2 2 1"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("Production times must be between 1 and 10^9", ex.Message);
        }

        [Fact]
        public void Test_TooManyDependencies()
        {
            string[] lines =
            {
                "2",
                "100 200",
                "200001 1 1 1 1 1",
                "0"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("Line 3 must contain 200002 numbers", ex.Message);
        }

        [Fact]
        public void Test_InvalidNumberFormat()
        {
            string[] lines =
            {
                "three",
                "100 200 300",
                "1 2",
                "0",
                "2 2 1"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("n must be between 1 and 100000", ex.Message);
        }

        [Fact]
        public void Test_Processing_MinimalTimeAndSequence()
        {
            string[] lines =
            {
                "4",
                "2 3 4 5",
                "2 3 2",
                "1 3",
                "0",
                "2 1 3"
            };

            string expected = "9 3 \n3 2 1";

            string result = TaskProcessor.ProcessTask(lines);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Processing_SingleDetail()
        {
            string[] lines =
            {
                "1",
                "10",
                "0"
            };

            string expected = "10 1 \n1";

            string result = TaskProcessor.ProcessTask(lines);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Processing_NoDependencies()
        {
            string[] lines =
            {
                "2",
                "5 10",
                "0",
                "0"
            };

            string expected = "5 1 \n1";

            string result = TaskProcessor.ProcessTask(lines);

            Assert.Equal(expected, result);
        }
    }
}
