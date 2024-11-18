using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string inputFilePath = Path.Combine("Lab2", "INPUT.TXT");
                string outputFilePath = Path.Combine("Lab2", "OUTPUT.TXT");

                // Read all lines from input file
                string[] lines = File.ReadAllLines(inputFilePath);

                // Validate input
                Validate(lines);

                // Process the problem and get result
                string result = ProcessLab2(lines);

                // Write result to output file
                File.WriteAllText(outputFilePath, result);

                // Optional: Console output for debugging
                Console.WriteLine("Lab2");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine('\n');
        }

        public static void Validate(string[] lines)
        {
            // Validate number of lines and input format
            if (lines.Length != 2)
                throw new InvalidOperationException("Input must contain exactly two lines.");

            int n = int.Parse(lines[0]);

            // Validate N range
            if (n < 2 || n > 100000)
                throw new InvalidOperationException("N must be between 2 and 100,000.");

            // Validate boolean function description
            if (lines[1].Length != 4 || !lines[1].All(c => c == '0' || c == '1'))
                throw new InvalidOperationException("Boolean function must be 4 binary digits.");
        }

        public static string ProcessLab2(string[] lines)
        {
            // Existing implementation remains the same as in the previous solution
            int n = int.Parse(lines[0]);
            int[] f = lines[1].Select(c => (int)char.GetNumericValue(c)).ToArray();

            var dd = new (int, int)[] { (0, 0), (0, 1), (1, 0), (1, 1) };
            var d = new (int, int)[n];
            d[0] = (0, 1);

            for (int i = 1; i < n; i++)
            {
                int[] cur = { -1, -1 };
                foreach (var (p0, p1) in dd)
                {
                    int e = f[(p0 << 1) + p1];
                    cur[e] = Math.Max(cur[e], (p0 == 0 ? d[i - 1].Item1 : d[i - 1].Item2) + p1);
                }
                d[i] = (cur[0], cur[1]);
            }

            if (d[n - 1].Item2 < 0)
            {
                return "No solution";
            }
            else
            {
                int e = 1;
                char[] result = new char[n];
                int resultIndex = n - 1;

                for (int i = n - 1; i > 0; i--)
                {
                    foreach (var (k, (p0, p1)) in dd.Select((x, index) => (index, x)))
                    {
                        if (e == f[k] && (e == 0 ? d[i].Item1 : d[i].Item2) == (p0 == 0 ? d[i - 1].Item1 : d[i - 1].Item2) + p1)
                        {
                            e = p0;
                            result[resultIndex--] = p1.ToString()[0];
                            break;
                        }
                    }
                }

                result[resultIndex] = e.ToString()[0];
                return new string(result);
            }
        }
    }
}