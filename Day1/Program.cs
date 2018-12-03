using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var frequencyChanges = new List<int>();
            using (var reader = File.OpenText("input.txt"))
            {
                string value;
                while ((value = reader.ReadLine()) != null)
                {
                    frequencyChanges.Add(int.Parse(value));
                }
            }

            // Part 1
            Console.WriteLine($"Frequency part 1: {frequencyChanges.Sum()}");

            // Part 2
            var frequencies = new HashSet<int>() { 0 };
            var found = false;

            var frequency = 0;
            while (!found)
            {
                foreach (var change in frequencyChanges)
                {
                    frequency += change;
                    if (found = frequencies.Contains(frequency)) break;
                    frequencies.Add(frequency);
                }
            }

            Console.WriteLine($"Frequency part 2: {frequency}");
        }
    }
}
