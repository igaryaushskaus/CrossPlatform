using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
using Lab2;
using ClassLibraryLab3;

namespace Lab4
{
    internal class LabRunner
    {
        public void RunLab1(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                int N;
                decimal[] USD;
                decimal[] EUR;

                Lab1.Program.ReadInput(out N, out USD, out EUR, inputFile);

                decimal finalRubles = Lab1.Program.ProcessLab1(N, USD, EUR);

                string result = finalRubles.ToString(); 

                File.WriteAllText(outputFile, result.Trim());

                Console.WriteLine("Lab1");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RunLab2(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                var result = Lab2.Program.ProcessLab2(lines);

                File.WriteAllText(outputFile, result.ToString().Trim()); 

                Console.WriteLine("Lab2");
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
        public void RunLab3(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                string result = TaskProcessor.ProcessTask(lines); 

                File.WriteAllText(outputFile, result.Trim()); 

                Console.WriteLine("Lab3");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
