using System.Text.RegularExpressions;

namespace adventofcode2023
{
    class day05
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            List<long> seeds = new(), seed_ranges = new();
            
            // input (seeds)
            foreach (Match match in Regex.Matches(input, @"\d+"))
                seeds.Add(Convert.ToInt64(match.Value));

            // input (seed ranges)
            foreach (Match match in Regex.Matches(input, @"\d+ \d+"))
            {
                long[] seed_range = match.Value
                    .Split(" ")
                    .Select(x => Convert.ToInt64(x))
                    .ToArray();
                
                for (long i = seed_range[0]; i < seed_range[0] + seed_range[1]; i++)
                    seed_ranges.Add(i);
            }

            Console.ReadLine(); // skip empty line
            
            // input maps
            for (int i = 0; i <= 6; i++) // 6 map types: seed-to-soil, ...
            {
                Console.ReadLine(); // skip title

                input = Console.ReadLine();
                List<long> new_seeds = new List<long>(seeds);
                List<long> new_seed_ranges = new List<long>(seed_ranges);
                while (input != null && input != string.Empty)
                {
                    long[] range = input
                        .Split(" ")
                        .Select(x => Convert.ToInt64(x))
                        .ToArray();
                    
                    // convert (part one)
                    for (int seed = 0; seed < seeds.Count(); seed++)
                    {
                        if (seeds[seed] >= range[1] && seeds[seed] < range[1] + range[2])
                            new_seeds[seed] += range[0] - range[1];
                    }

                    // convert (part two)
                    for (int seed = 0; seed < seed_ranges.Count(); seed++)
                    {
                        if (seed_ranges[seed] >= range[1] && seed_ranges[seed] < range[1] + range[2])
                            new_seed_ranges[seed] += range[0] - range[1];
                    }

                    // title
                    input = Console.ReadLine();
                }

                seeds = new_seeds.ToList();
                seed_ranges = new_seed_ranges.ToList();
            }
            
            // output
            Console.WriteLine($"lowest location number (part one): {seeds.Min()}");
            Console.WriteLine($"lowest location number (part two): {seed_ranges.Min()}");
            Console.ReadKey();
        }
    }
}
