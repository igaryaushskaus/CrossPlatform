using System;
using System.IO;
using System.Globalization;
using Xunit;

namespace Lab1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_ValidInput()
        {
            int N = 3;
            decimal[] USD = { 0, 1.5m, 2.0m, 2.5m };
            decimal[] EUR = { 0, 1.0m, 1.8m, 2.4m };

            var ex = Record.Exception(() => Program.Validate(N, USD, EUR));
            Assert.Null(ex);
        }

        [Fact]
        public void Test_Invalid_N_ExceedsLimit()
        {
            int N = 5001;
            decimal[] USD = new decimal[N + 1];
            decimal[] EUR = new decimal[N + 1];

            var ex = Record.Exception(() => Program.Validate(N, USD, EUR));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("N must be between 1 and 5000.", ex.Message);
        }

        [Fact]
        public void Test_Invalid_USD_ExceedsLimit()
        {
            int N = 2;
            decimal[] USD = { 0, 0.005m, 20000m }; // Second value invalid
            decimal[] EUR = { 0, 1.0m, 1.5m };

            var ex = Record.Exception(() => Program.Validate(N, USD, EUR));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("USD rate on day 1 is out of range (0.01 to 10000).", ex.Message);
        }

        [Fact]
        public void Test_Invalid_EUR_ExceedsLimit()
        {
            int N = 2;
            decimal[] USD = { 0, 1.0m, 2.0m };
            decimal[] EUR = { 0, 0.005m, 20000m }; // Second value invalid

            var ex = Record.Exception(() => Program.Validate(N, USD, EUR));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("EUR rate on day 1 is out of range (0.01 to 10000).", ex.Message);
        }

        [Fact]
        public void Test_ProcessingWithEdgeRates()
        {
            int N = 2;
            decimal[] USD = { 0, 0.01m, 10000m };
            decimal[] EUR = { 0, 10000m, 0.01m };

            decimal expected = 100000000; // Extreme conversion scenario

            decimal result = Program.ProcessLab1(N, USD, EUR);

            Assert.Equal(expected, result);
        }
    }
}
