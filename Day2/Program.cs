using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ids = new List<string>();
            using (var reader = File.OpenText("input.txt"))
            {
                string value;
                while ((value = reader.ReadLine()) != null)
                {
                    ids.Add(value);
                }
            }

            // Part 1
            var exactTwo = 0;
            var exactThree = 0;

            foreach (var id in ids)
            {
                var grouped = id.GroupBy(x => x).ToList();
                exactTwo += grouped.Any(x => x.Count() == 2) ? 1 : 0;
                exactThree += grouped.Any(x => x.Count() == 3) ? 1 : 0;

            }

            Console.WriteLine($"Checksum {exactTwo * exactThree}");


            Console.ReadLine();
        }
    }
}
