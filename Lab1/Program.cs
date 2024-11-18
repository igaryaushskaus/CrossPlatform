using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lab1
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;

    public class Program
    {
        public static void Main() 
        {
            Console.OutputEncoding = Encoding.UTF8;
            string inputFilePath = Path.Combine("Lab1", "INPUT.TXT");
            string outputFilePath = Path.Combine("Lab1", "OUTPUT.TXT");

            int N;
            decimal[] USD;
            decimal[] EUR;

            string[] lines = File.ReadAllLines(inputFilePath);

            ReadInput(out N, out USD, out EUR, inputFilePath);

            Validate(N, USD, EUR);

            decimal finalRubles = ProcessLab1(N, USD, EUR);

            WriteOutput(finalRubles, outputFilePath);

            Console.WriteLine("Lab1");
            Console.WriteLine("Input data:");
            Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
            Console.WriteLine("Output data:");
            Console.WriteLine(finalRubles.ToString());
        }

        // Method to validate the input data
        public static void Validate(int N, decimal[] USD, decimal[] EUR)
        {
            if (N < 1 || N > 5000)
            {
                throw new InvalidOperationException("N must be between 1 and 5000.");
            }

            for (int i = 1; i <= N; i++)
            {
                if (USD[i] < 0.01m || USD[i] > 10000m)
                {
                    throw new InvalidOperationException($"USD rate on day {i} is out of range (0.01 to 10000).");
                }

                if (EUR[i] < 0.01m || EUR[i] > 10000m)
                {
                    throw new InvalidOperationException($"EUR rate on day {i} is out of range (0.01 to 10000).");
                }
            }
        }

        // Method to read input data from the file
        static void ReadInput(out int N, out decimal[] USD, out decimal[] EUR, string inputFilePath)
        {
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                N = int.Parse(sr.ReadLine());

                USD = new decimal[N + 1];
                EUR = new decimal[N + 1];

                for (int i = 1; i <= N; i++)
                {
                    string[] inputs = sr.ReadLine().Split();
                    USD[i] = decimal.Parse(inputs[0], CultureInfo.InvariantCulture);
                    EUR[i] = decimal.Parse(inputs[1], CultureInfo.InvariantCulture);
                }
            }
        }

        // Method to perform calculations
        public static decimal ProcessLab1(int N, decimal[] USD, decimal[] EUR)
        {
            // Arrays to store the maximum values for rubles, dollars, and euros
            decimal[] rubles = new decimal[N + 1];
            decimal[] dollars = new decimal[N + 1];
            decimal[] euros = new decimal[N + 1];

            // Initial values
            rubles[0] = 100m;
            dollars[0] = 0m;
            euros[0] = 0m;

            // Perform calculations for each day
            for (int i = 1; i <= N; i++)
            {
                decimal rate_USD_to_EUR = USD[i] / EUR[i];
                decimal rate_EUR_to_USD = EUR[i] / USD[i];

                // Update ruble values
                rubles[i] = Max(
                    rubles[i - 1],             // Keep rubles
                    dollars[i - 1] * USD[i],  // Convert dollars to rubles
                    euros[i - 1] * EUR[i]     // Convert euros to rubles
                );

                // Update dollar values
                dollars[i] = Max(
                    dollars[i - 1],                // Keep dollars
                    rubles[i - 1] / USD[i],       // Convert rubles to dollars
                    euros[i - 1] * rate_EUR_to_USD // Convert euros to dollars
                );

                // Update euro values
                euros[i] = Max(
                    euros[i - 1],                // Keep euros
                    rubles[i - 1] / EUR[i],      // Convert rubles to euros
                    dollars[i - 1] * rate_USD_to_EUR // Convert dollars to euros
                );
            }

            // Final result in rubles
            decimal finalRubles = Max(
                rubles[N],             // Keep rubles
                dollars[N] * USD[N],   // Convert dollars to rubles
                euros[N] * EUR[N]      // Convert euros to rubles
            );

            return finalRubles;
        }

        // Method to write the result to the output file
        public static void WriteOutput(decimal finalRubles, string outputFilePath)
        {
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.WriteLine(finalRubles.ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        // Method to find the maximum of three numbers
        static decimal Max(decimal a, decimal b, decimal c)
        {
            return Math.Max(a, Math.Max(b, c));
        }
    }

}
