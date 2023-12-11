namespace adventofcode2023
{
    class day09
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            int sum = 0, sum2 = 0;
            List<List<int>> histories = new();
            
            // input
            while (input != null && input != string.Empty)
            {
                // extract int values from input
                histories.Add(
                    input.Split(' ')
                         .Select(x => Convert.ToInt32(x))
                         .ToList()
                );

                input = Console.ReadLine();
            }

            // sequences of differences
            foreach (var history in histories)
            {
                List<List<int>> sequencesDifferences = new(){history};
                List<int> sequenceDifferencesOld = history;
                List<int> sequenceDifferencesNew = new();

                do
                {
                    // calculate difference between 2 values in old sequence of differences
                    for (int i = 1; i < sequenceDifferencesOld.Count(); i++)
                    {
                        sequenceDifferencesNew.Add(sequenceDifferencesOld[i] - sequenceDifferencesOld[i-1]);
                    }

                    // store sequence of differences
                    sequencesDifferences.Add(sequenceDifferencesNew);

                    // new sequence of differences is old sequence of differences for next run
                    sequenceDifferencesOld = new(sequenceDifferencesNew);
                    sequenceDifferencesNew = new();

                }
                // while there are still elements in the last sequence of differences that arent = 0
                while (sequencesDifferences.Last().Where(x => x != 0).Count() != 0);

                int val = 0, val2 = 0;
                for (int i = sequencesDifferences.Count() - 1; i > 0; i--)
                {
                    // extrapolate forwards (part one)
                    val = sequencesDifferences[i-1].Last() + val;
                    // extrapolate backwards (part two)
                    val2 = sequencesDifferences[i-1].First() - val2;
                }

                // sums
                sum += val;
                sum2 += val2;
            }

            // output
            Console.WriteLine($"sum of extrapolated values (forwards): {sum}");
            Console.WriteLine($"sum of extrapolated values (backwards): {sum2}");
            Console.ReadKey();
        }
    }
}
