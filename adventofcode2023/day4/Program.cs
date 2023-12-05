using System.Text.RegularExpressions;

namespace adventofcode2023
{
    class day4
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            List<int> winning_numbers, your_numbers;
            int sum = 0, sum2 = 0;
            int points = 0, cardID = 0, matching_numbers = 0;
            int[] card_count = new int[300];
            for (int i = 0; i < 300; i++)
                card_count[i] = 1;
            
            // input
            while (input != null && input != string.Empty)
            {
                // number of current card
                cardID++;

                // reset
                winning_numbers = new List<int>();
                your_numbers = new List<int>();
                matching_numbers = 0;
                points = 0;

                // get all numbers before "|"
                foreach (Match match in Regex.Matches(input, @"(?<= )\d+(?= .*\|)"))
                    winning_numbers.Add(Convert.ToInt32(match.Value));
                
                // get all numbers after "|"
                foreach (Match match in Regex.Matches(input, @"(?<=\|.*)\d+"))
                    your_numbers.Add(Convert.ToInt32(match.Value));
                
                // check for matches
                foreach (int match in your_numbers.Where(x => winning_numbers.Contains(x)))
                {
                    // if points > 0 then double, else set to 1
                    points = points > 0 ? points*2 : 1;
                    // count matches
                    matching_numbers++;
                }

                // add cards for matches (part two)
                for (int i = 1; i <= matching_numbers; i++)
                {
                    card_count[cardID + i] += card_count[cardID];
                }

                // add points together
                sum += points;

                // input
                input = Console.ReadLine();
            }

            // sum of cards (part two)
            for (int i = 1; i <= cardID; i++)
                sum2 += card_count[i];

            // output
            Console.WriteLine($"sum of points: {sum}");
            Console.WriteLine($"number of cards: {sum2}");
            Console.ReadKey();
        }
    }
}
