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

            ids.ForEach(id =>
            {
                var grouped = id.GroupBy(x => x).ToList();
                exactTwo += grouped.Any(x => x.Count() == 2) ? 1 : 0;
                exactThree += grouped.Any(x => x.Count() == 3) ? 1 : 0;
            });

            Console.WriteLine($"Checksum {exactTwo * exactThree}");

            // Part 2
            string commonLetters =  "";
            foreach (var firstId in ids)
            {
                foreach (var secondId in ids)
                {
                    if (firstId == secondId) continue;
                    var currentCommon = firstId.Where((letter, index) => letter == secondId[index]);
                    if (currentCommon.Count() == firstId.Count() - 1)
                    {
                        commonLetters = string.Concat(currentCommon);
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(commonLetters)) break;
            }

            Console.WriteLine($"Common: {commonLetters}");

            Console.ReadLine();
        }
    }
}
