namespace adventofcode2023
{
    class day03
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            List<string> engine_schema = new List<string>();
            List<List<(int adjacent_numbers, int gear_ration)>> gear_schema = new List<List<(int , int)>>();
            int sum = 0, sum2 = 0;
            int line = 0;
            (int y,int x)[] dirs = {(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1)};

            // input
            while (input != null && input != string.Empty)
            {

                engine_schema.Add(input);
                gear_schema.Add(Enumerable.Repeat((0,1), input.Length).ToList());
                line++;

                input = Console.ReadLine();
            }

            for (int i = 0; i < engine_schema.Count(); i++)
            {
                for (int j = 0; j < engine_schema[i].Count(); j++)
                {
                    if (Char.IsDigit(engine_schema[i][j]))
                    {
                        string num = string.Empty;
                        Stack<(int y, int x)> s = new Stack<(int y, int x)>();
                        
                        do
                        {
                            num += engine_schema[i][j];
                            s.Push((i,j));
                            j++;
                        }
                        while (j < engine_schema[i].Count() && Char.IsDigit(engine_schema[i][j]));

                        bool valid = false;
                        
                        foreach (var pos in s)
                        {
                            foreach (var dir in dirs)
                            {
                                if ( pos.x + dir.x < engine_schema[0].Count()
                                    && pos.y + dir.y < engine_schema.Count()
                                    && pos.x + dir.x >= 0
                                    && pos.y + dir.y >= 0)
                                {
                                    if (!Char.IsDigit(engine_schema[pos.y + dir.y][pos.x + dir.x])
                                        && engine_schema[pos.y + dir.y][pos.x + dir.x] != '.')
                                        valid = true;
                                    // part two
                                    if (engine_schema[pos.y + dir.y][pos.x + dir.x] == '*')
                                    {
                                        var gear_data = gear_schema[pos.y + dir.y][pos.x + dir.x];
                                        gear_data.adjacent_numbers++;
                                        gear_data.gear_ration *= Convert.ToInt32(num);
                                        gear_schema[pos.y + dir.y][pos.x + dir.x] = gear_data;
                                    }
                                }
                                if (valid) break;
                            }
                            if (valid) break;
                        }

                        if (valid)
                            sum += Convert.ToInt32(num);

                    }
                }
            }

            // sum of gear ratios (part two)
            foreach (var row in gear_schema)
            {
               foreach (var pos in row)
               {
                    if (pos.adjacent_numbers == 2)
                        sum2 += pos.gear_ration;
               }
            }
            
            // end part two

            // output
            Console.WriteLine($"sum of part numbers: {sum}");
            Console.WriteLine($"sum of gear ratios: {sum2}");
            Console.ReadKey();
        }
    }
}
