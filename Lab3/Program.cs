using System;
using System.IO;
using ClassLibraryLab3;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string inputFilePath = Path.Combine("Lab3", "INPUT.TXT");
                string outputFilePath = Path.Combine("Lab3", "OUTPUT.TXT");

                string[] lines = File.ReadAllLines(inputFilePath);
                Validate(lines);

                string result = TaskProcessor.ProcessTask(lines);

                File.WriteAllText(outputFilePath, result);

                // Optional: Display results
                Console.WriteLine("Lab3");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.ToString().Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void Validate(string[] lines)
        {
            if (lines.Length < 2)
                throw new InvalidOperationException("Input must contain at least two lines.");

            if (!int.TryParse(lines[0], out int n) || n < 1 || n > 100000)
                throw new InvalidOperationException("n must be between 1 and 100000");

            string[] times = lines[1].Split();
            if (times.Length != n)
                throw new InvalidOperationException($"Second line must contain exactly {n} numbers");

            foreach (string time in times)
            {
                if (!long.TryParse(time, out long t) || t < 1 || t > 1000000000)
                    throw new InvalidOperationException("Production times must be between 1 and 10^9");
            }

            if (lines.Length != n + 2)
                throw new InvalidOperationException($"Input must contain exactly {n + 2} lines");

            int totalDependencies = 0;
            for (int i = 2; i < lines.Length; i++)
            {
                string[] deps = lines[i].Split();
                if (!int.TryParse(deps[0], out int k))
                    throw new InvalidOperationException($"Invalid dependency count on line {i + 1}");

                if (deps.Length != k + 1)
                    throw new InvalidOperationException($"Line {i + 1} must contain {k + 1} numbers");

                totalDependencies += k;
                if (totalDependencies > 200000)
                    throw new InvalidOperationException("Total number of dependencies exceeds 200000");
            }
        }
    }
}