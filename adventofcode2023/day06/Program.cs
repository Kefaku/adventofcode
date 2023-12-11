using System.Text.RegularExpressions;

namespace adventofcode2023
{
    class day06
    {
        public static void Main(String[] args)
        {
            // init
            string input;
            List<int> times = new();
            List<int> distances = new();
            string total_time_in = "", total_distance_in = "";
            long total_time = 0, total_distance = 0;
            int margin_of_error = 1, possible_wins = 0;
            
            // input of time
            input = Console.ReadLine();
            foreach (Match match in Regex.Matches(input, @"\d+"))
            {
                times.Add(Convert.ToInt32(match.Value));
                // add digits together (part two)
                total_time_in += match.Value;
            }

            // input of record distance
            input = Console.ReadLine();
            foreach (Match match in Regex.Matches(input, @"\d+"))
            {
                distances.Add(Convert.ToInt32(match.Value));
                // add digits together (part two)
                total_distance_in += match.Value;
            }

            // convert string distance/time to int
            total_time = Convert.ToInt64(total_time_in);
            total_distance = Convert.ToInt64(total_distance_in);

            // for each race (part one)
            for (int race = 0; race < times.Count(); race++)
            {
                possible_wins = 0;

                // check all possible amounts of time the button can be held
                for (int button_time = 1; button_time <= times[race]; button_time++)
                {
                    // boat travels with speed = buttonTime for
                    if ((times[race] - button_time) * button_time > distances[race])
                    {
                        possible_wins++;
                    }
                }

                margin_of_error *= possible_wins;
            }
            // end part one

            // for the big race (part two)
            possible_wins = 0;

            // check all possible amounts of time the button can be held
            for (int button_time = 1; button_time <= total_time; button_time++)
            {
                if ((total_time - button_time) * button_time > total_distance)
                {
                    possible_wins++;
                }
            }
            // end part two

            // output
            Console.WriteLine($"margin of error (part one): {margin_of_error}");
            Console.WriteLine($"ways to beat the record (part two): {possible_wins}");
            Console.ReadKey();
        }
    }
}
