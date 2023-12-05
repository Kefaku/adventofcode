namespace adventofcode2023
{
    class day3
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            List<string> engine_schema = new List<string>();
            int sum = 0, sum2 = 0;
            int line = 0;
            (int y,int x)[] dirs = {(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1)};

            // input
            while (input != null && input != string.Empty)
            {

                engine_schema.Add(input);
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
                                }
                            }
                        }

                        if (valid)
                            sum += Convert.ToInt32(num);

                    }
                }
            }

            // part two
            // for (int y = 0; y < engine_schema.Count(); y++)
            // {
            //     for (int x = 0; x < engine_schema[y].Count(); x++)
            //     {
            //         byte adjacent_numbers = 0;
            // 
            //         if (engine_schema[y][x] == '*')
            //         {
            //             foreach (var dir in dirs)
            //             {
            //                 if ( x + dir.x < engine_schema[0].Count()
            //                     && y + dir.y < engine_schema.Count()
            //                     && x + dir.x >= 0
            //                     && y + dir.y >= 0)
            //                 {
            //                     if (!Char.IsDigit(engine_schema[y + dir.y][x + dir.x])
            //                         && engine_schema[y + dir.y][x + dir.x] != '.')
            //                         adjacent_numbers++;
            //                 }
            //             }
            //         }
            //     }
            // }
            // end part two

            // output
            Console.WriteLine($"sum of part numbers: {sum}");
            Console.WriteLine($"sum of gear ratios: {sum2}");
            Console.ReadKey();
        }
    }
}