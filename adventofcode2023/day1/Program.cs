using System.Text.RegularExpressions;

namespace adventofcode2023
{
    class day1
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            int sum = 0;

            while (input != null && input != string.Empty)
            {
                // part two
                Dictionary<string, string> digits = new Dictionary<string, string>
                {
                    {"one", "1"},
                    {"two", "2"},
                    {"three", "3"},
                    {"four", "4"},
                    {"five", "5"},
                    {"six", "6"},
                    {"seven", "7"},
                    {"eight", "8"},
                    {"nine", "9"},

                };

                // add digits to spelled out numbers
                input = Regex.Replace(
                    input,
                    @"one|two|three|four|five|six|seven|eight|nine",
                    match => $"{digits[match.Value]}{match.Value}",
                    RegexOptions.IgnoreCase
                );

                // repeat right to left (in case spellings overlap, e.g. "oneight"
                input = Regex.Replace(
                    input,
                    @"one|two|three|four|five|six|seven|eight|nine",
                    match => $"{digits[match.Value]}{match.Value}",
                    RegexOptions.IgnoreCase | RegexOptions.RightToLeft
                );
                // end part two

                // find first digit
                short first = Convert.ToInt16(
                    Regex
                    .Match(input, @"(?<=\b[a-z]*)(\d)", RegexOptions.IgnoreCase)
                    .Value
                );

                // find last digit
                short last = Convert.ToInt16(
                    Regex
                    .Match(input, @"(\d)(?=[a-z]*\b)", RegexOptions.IgnoreCase)
                    .Value
                );

                // add to sum
                sum += first * 10 + last;

                // input
                input = Console.ReadLine();
            }

            // output
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
