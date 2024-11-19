using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryLab3
{
    public class ManufacturingProcess
    {
        private int n;
        private long[] p;  // Production time for each part
        private List<int>[] dependencies;  // Dependencies list
        private bool[] used;  // Tracking array for produced parts
        private List<int> result;  // Production order list
        private long[] dp;  // Minimum production time for each part

        public ManufacturingProcess(string[] lines)
        {
            ParseInput(lines);
            used = new bool[n];
            dp = new long[n];
            result = new List<int>();
        }

        private void ParseInput(string[] lines)
        {
            // Parse number of parts
            n = int.Parse(lines[0]);

            // Parse production times
            p = lines[1].Split().Select(long.Parse).ToArray();

            // Initialize dependencies
            dependencies = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                dependencies[i] = new List<int>();
            }

            // Parse dependencies
            for (int i = 0; i < n; i++)
            {
                string[] parts = lines[i + 2].Split();
                int k = int.Parse(parts[0]);
                for (int j = 1; j <= k; j++)
                {
                    dependencies[i].Add(int.Parse(parts[j]) - 1);  // Convert to 0-based indexing
                }
            }
        }

        private long DFS(int idx)
        {
            if (used[idx]) return dp[idx];
            used[idx] = true;

            long time = p[idx];
            foreach (var dep in dependencies[idx])
            {
                time = Math.Max(time, DFS(dep) + p[idx]);
            }

            dp[idx] = time;
            result.Add(idx + 1);
            return dp[idx];
        }

        public string ProcessTask()
        {
            StringBuilder finalResult = new StringBuilder();
            long minTime = DFS(0);
            if (result == null || result.Count == 0)
            {
                throw new InvalidOperationException("Result is not initialized or empty.");
            }
            finalResult.Append($"{minTime} {result.Count} \n");
            finalResult.Append(string.Join(" ", result));

            return finalResult.ToString();
        }

    }

    public class TaskProcessor
    {
        public static string ProcessTask(string[] lines)
        {
            var process = new ManufacturingProcess(lines);
            return process.ProcessTask();
        }
    }
}