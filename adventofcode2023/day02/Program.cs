using System.Text.RegularExpressions;

namespace adventofcode2023
{
    class day02
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            int sum = 0, sum2 = 0;
            int game = 0;

            while (input != null && input != string.Empty)
            {
                // init
                bool possible = true;
                short r = 0, g = 0, b = 0;
                game++;

                // checks
                r = max_cube_count(input, @"(\d+)(?= red)", 12, ref possible);
                g = max_cube_count(input, @"(\d+)(?= green)", 13, ref possible);
                b = max_cube_count(input, @"(\d+)(?= blue)", 14, ref possible);

                // add game id to sume, if this game is possible (part one)
                if (possible)
                    sum += game;

                // add power of set to sum (part two)
                sum2 += r * g * b;

                // input
                input = Console.ReadLine();
            }

            // output
            Console.WriteLine($"sum of IDs: {sum}");
            Console.WriteLine($"sum of powers: {sum2}");
            Console.ReadKey();
        }

        private static short max_cube_count(string input, string regex, byte max_count, ref bool possible)
        {
            short max_cube_count = 0;

            foreach (Match match in Regex.Matches(input, regex))
            {
                // extract numbers
                var val = Convert.ToInt16(match.Value);

                // check if game is possible (part one)
                if (val > max_count)
                    possible = false;

                // find highest cube number seen (part two)
                if (val > max_cube_count)
                    max_cube_count = val;
            }

            return max_cube_count;
        }
    }
}
