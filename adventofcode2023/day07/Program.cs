namespace adventofcode2023
{
    class day07
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            int sum = 0, sum2 = 0;
            List<(string hand, int bid)> hands = new();
            Dictionary<char, int> cardStrength = new(){
                {'2', 1},
                {'3', 2},
                {'4', 3},
                {'5', 4},
                {'6', 5},
                {'7', 6},
                {'8', 7},
                {'9', 8},
                {'T', 9},
                {'J', 10},
                {'Q', 11},
                {'K', 12},
                {'A', 13}
            };
            
            Dictionary<char, int> cardStrength2 = new(){
                {'j', 1},
                {'2', 2},
                {'3', 3},
                {'4', 4},
                {'5', 5},
                {'6', 6},
                {'7', 7},
                {'8', 8},
                {'9', 9},
                {'T', 10},
                {'Q', 11},
                {'K', 12},
                {'A', 13}
            };
            
            // input
            while (input != null && input != string.Empty)
            {
                // get data
                var inputData = input.Split(' ');
                hands.Add((inputData[0], Convert.ToInt32(inputData[1])));

                // input
                input = Console.ReadLine();
            }

            // without jokers (part one)
            hands = OrderHands(hands, cardStrength, false);
            for (int i = 0; i < hands.Count(); i++)
            {
                // rank * bid
                sum += (i+1) * hands[i].bid;
            }

            // with jokers (part two)
            hands = OrderHands(hands, cardStrength2, true);
            for (int i = 0; i < hands.Count(); i++)
            {
                // rank * bid
                sum2 += (i+1) * hands[i].bid;
            };
            // DEBUG
            hands.Reverse();

            // output
            Console.WriteLine($"total winnings (part one): {sum}");
            Console.WriteLine($"total winnings (part two): {sum2}");
            Console.ReadKey();
        }

        private static List<(string hand, int bid)> OrderHands(
            List<(string hand, int bid)> hands,
            Dictionary<char, int> cardValues,
            bool useJokers)
        {
            // mark jokers for usage
            if (useJokers)
            {
                hands = hands.Select(
                    hand => (hand.hand.Replace('J', 'j'), hand.bid))
                    .ToList();
            }

            // first, order by type
            return hands.OrderBy(x =>
                HandValue(
                    // replace Jokers with most common card
                    x.hand.Replace(
                        'j', 
                        x.hand
                            .GroupBy(c => c)
                            .OrderBy(x => x.Key == 'j' ? 1 : 0)
                            .ThenByDescending(x => x.Count())
                            .First()
                            .Key
                    )
                )
            )
            // then order by strength of first card, second card, ...
                .ThenBy(x => cardValues[x.hand[0]])
                .ThenBy(x => cardValues[x.hand[1]])
                .ThenBy(x => cardValues[x.hand[2]])
                .ThenBy(x => cardValues[x.hand[3]])
                .ThenBy(x => cardValues[x.hand[4]])
                .ToList();
        }

        private static int HandValue(string hand)
        {
            var handOrdered = hand.ToCharArray().Order().ToList();

            // Five of a kind
            if (handOrdered.Distinct().Count() == 1)
                return 7;
                
            // Four of a kind
            if (handOrdered.Where(x => x == handOrdered[2]).Count() == 4)
                return 6;
            
            if (handOrdered.Where(x => x == handOrdered[2]).Count() == 3)
                // Full House
                if (handOrdered.Distinct().Count() == 2)
                    return 5;
                // Three of a kind
                else
                    return 4;
            
            // Two pair
            if (handOrdered.Distinct().Count() == 3)
                return 3;
            
            // One pair
            if (handOrdered.Distinct().Count() == 4)
                return 2;

            // High card
            return 1;
        }
    }
}
