namespace adventofcode2023
{
    class day10
    {
        public static void Main(String[] args)
        {
            // init
            var input = Console.ReadLine();
            List<List<char>> maze = new();
            int dist = 0, contained = 0;
            
            // input
            while (input != null && input != string.Empty)
            {
                maze.Add(input.ToList());
                input = Console.ReadLine();
            }

            // find start
            byte y = (byte)maze.FindIndex(s => s.Contains('S'));
            byte x = (byte)maze[y].FindIndex(c => c == 'S');

            // walk through
            Queue<(int y, int x)> q = new();
            q.Enqueue((y, x));
            while (q.Count() != 0)
            {
                (int y, int x) posCur = q.Dequeue();
                switch (maze[posCur.y][posCur.x])
                {
                    case 'S':
                        CheckNorth(ref q, posCur, maze);
                        CheckSouth(ref q, posCur, maze);
                        CheckWest(ref q, posCur, maze);
                        CheckEast(ref q, posCur, maze);
                        goto default;
                    case '|':
                        CheckNorth(ref q, posCur, maze);
                        CheckSouth(ref q, posCur, maze);
                        goto default;
                    case '-':
                        CheckWest(ref q, posCur, maze);
                        CheckEast(ref q, posCur, maze);
                        goto default;
                    case 'F':
                        CheckSouth(ref q, posCur, maze);
                        CheckEast(ref q, posCur, maze);
                        goto default;
                    case '7':
                        CheckSouth(ref q, posCur, maze);
                        CheckWest(ref q, posCur, maze);
                        goto default;
                    case 'J':
                        CheckNorth(ref q, posCur, maze);
                        CheckWest(ref q, posCur, maze);
                        goto default;
                    case 'L':
                        CheckNorth(ref q, posCur, maze);
                        CheckEast(ref q, posCur, maze);
                        goto default;
                    default:
                        maze[posCur.y][posCur.x] = '#';
                        break;
                }
                dist++;

                // foreach (var s in maze)
                //     Console.WriteLine(string.Join("",s));
                // Console.WriteLine(dist);
            }

            // // flood fill from edge (part two)
            // char[] blockingTiles = ['#', '0'];
            // for (x = 0; x < maze[0].Count(); x++)
            // {
            //     if (!blockingTiles.Contains(maze[0][x]))
            //         q.Enqueue((0, x));
            //     if (!blockingTiles.Contains(maze[maze.Count() - 1][x]))
            //         q.Enqueue((maze.Count() - 1, x));
            // }
            // for (y = 0; y < maze.Count(); y++)
            // {
            //     if (!blockingTiles.Contains(maze[y][0]))
            //         q.Enqueue((y, 0));
            //     if (!blockingTiles.Contains(maze[y][maze[0].Count() - 1]))
            //         q.Enqueue((y, maze[0].Count() - 1));
            // }
            // while (q.Count() != 0)
            // {
            //     (int y, int x) posCur = q.Dequeue();
            //     maze[posCur.y][posCur.x] = '0';
            //     // north
            //     if (posCur.y - 1 >= 0)
            //         if (!blockingTiles.Contains(maze[posCur.y - 1][posCur.x]))
            //             q.Enqueue((posCur.y - 1, posCur.x));
            //     // south
            //     if (posCur.y + 1 < maze.Count())
            //         if (!blockingTiles.Contains(maze[posCur.y + 1][posCur.x]))
            //             q.Enqueue((posCur.y + 1, posCur.x));
            //     // west
            //     if (posCur.x - 1 >= 0)
            //         if (!blockingTiles.Contains(maze[posCur.y][posCur.x - 1]))
            //             q.Enqueue((posCur.y, posCur.x - 1));
            //     // east
            //     if (posCur.x + 1 < maze[0].Count())
            //         if (!blockingTiles.Contains(maze[posCur.y][posCur.x + 1]))
            //             q.Enqueue((posCur.y, posCur.x + 1));
            //     // north-west
            //     if (posCur.x - 1 >= 0 && posCur.y - 1 >= 0)
            //         if (!blockingTiles.Contains(maze[posCur.y - 1][posCur.x - 1]))
            //             q.Enqueue((posCur.y - 1, posCur.x - 1));
            //     // north-east
            //     if (posCur.x + 1 < maze[0].Count() && posCur.y - 1 >= 0)
            //         if (!blockingTiles.Contains(maze[posCur.y - 1][posCur.x + 1]))
            //             q.Enqueue((posCur.y - 1, posCur.x + 1));
            //     // south-west
            //     if (posCur.x - 1 >= 0 && posCur.y + 1 < maze.Count())
            //         if (!blockingTiles.Contains(maze[posCur.y + 1][posCur.x - 1]))
            //             q.Enqueue((posCur.y + 1, posCur.x - 1));
            //     // south-east
            //     if (posCur.x + 1 < maze[0].Count() && posCur.y + 1 < maze.Count())
            //         if (!blockingTiles.Contains(maze[posCur.y + 1][posCur.x + 1]))
            //             q.Enqueue((posCur.y + 1, posCur.x + 1));

            //     foreach (var s in maze)
            //         Console.WriteLine(string.Join("",s));
            //     Console.WriteLine();
            // }

            // // count ground tiles in contained in the loop
            // foreach (var s in maze)
            //     foreach(var c in s)
            //         if (c == '.')
            //             contained++;

            // output
            Console.WriteLine($"distance to farthest point: {dist / 2}");
            Console.WriteLine($"number of tiles enclosed by the loop: {contained}");
            Console.ReadKey();
        }

        private static void CheckNorth(ref Queue<(int y, int x)> q, (int y, int x) posCur, List<List<char>> maze)
        {
            char[] fittingPipes = ['|', 'F', '7'];
            
            if (posCur.y - 1 >= 0)
                if (fittingPipes.Contains(maze[posCur.y - 1][posCur.x]))
                    q.Enqueue((posCur.y - 1, posCur.x));
        }

        private static void CheckSouth(ref Queue<(int y, int x)> q, (int y, int x) posCur, List<List<char>> maze)
        {
            char[] fittingPipes = ['|', 'J', 'L'];
            if (posCur.y + 1 < maze.Count())
                if (fittingPipes.Contains(maze[posCur.y + 1][posCur.x]))
                    q.Enqueue((posCur.y + 1, posCur.x));
        }

        private static void CheckWest(ref Queue<(int y, int x)> q, (int y, int x) posCur, List<List<char>> maze)
        {
            char[] fittingPipes = ['-', 'F', 'L'];
            if (posCur.x - 1 >= 0)
                if (fittingPipes.Contains(maze[posCur.y][posCur.x - 1]))
                    q.Enqueue((posCur.y, posCur.x - 1));
        }

        private static void CheckEast(ref Queue<(int y, int x)> q, (int y, int x) posCur, List<List<char>> maze)
        {
            char[] fittingPipes = ['-', 'J', '7'];
            if (posCur.x + 1 < maze[0].Count())
                if (fittingPipes.Contains(maze[posCur.y][posCur.x + 1]))
                    q.Enqueue((posCur.y, posCur.x + 1));
        }
    }
}
