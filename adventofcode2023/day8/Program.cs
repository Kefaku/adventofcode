using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace adventofcode2023
{
    class day8
    {
        public static void Main(String[] args)
        {
            // init
            char[] sequence;
            sequence = Console.ReadLine().ToCharArray();
            Dictionary<string, (string l, string r)> networkMap = new();

            Console.ReadLine(); // skip empty line
            string input = Console.ReadLine();
 
            // input
            (string l, string r) instructions = ("", "");
            while (input != null && input != string.Empty)
            {
                string node = Regex.Match(input, @"\w{3}(?= =)").Value;
                instructions.l = Regex.Match(input, @"(?<=\()\w{3}").Value;
                instructions.r = Regex.Match(input, @"\w{3}(?=\))").Value;

                networkMap.Add(node, instructions);

                // input
                input = Console.ReadLine();
            }

            // follow the instructions
            string nodeCurrent = "AAA";
            int sequenceCurrentStep = 0;
            int steps = 0;
            
            // (part 1)
            while (nodeCurrent != "ZZZ")
            {
                // step to next node
                if (sequence[sequenceCurrentStep] == 'L')
                    nodeCurrent = networkMap[nodeCurrent].l;
                else
                    nodeCurrent = networkMap[nodeCurrent].r;

                // next instruction from sequence
                if (sequenceCurrentStep < sequence.Count() - 1)
                    sequenceCurrentStep++;
                else
                    sequenceCurrentStep = 0;

                // count steps
                steps++;
            }

            // // (part two)
            // sequenceCurrentStep = 0;
            // List<string> nodesCurrent = networkMap.Keys
            //     .Where(s => s.EndsWith("A"))
            //     .ToList();
            // BigInteger steps2 = 0;

            // // continue until all all nodes end with "Z"
            // while (nodesCurrent.Where(s => s.EndsWith("Z")).Count() != nodesCurrent.Count())
            // {
            //     for (int i = 0; i < nodesCurrent.Count(); i++)
            //     {
            //         // step to next node
            //         if (sequence[sequenceCurrentStep] == 'L')
            //             nodesCurrent[i] = networkMap[nodesCurrent[i]].l;
            //         else
            //             nodesCurrent[i] = networkMap[nodesCurrent[i]].r;
            //     }

            //     // next instruction from sequence
            //     if (sequenceCurrentStep < sequence.Count() - 1)
            //         sequenceCurrentStep++;
            //     else
            //         sequenceCurrentStep = 0;

            //     // count steps
            //     steps2++;
            // }
            
            // output
            Console.WriteLine($"required steps (part one): {steps}");
            // Console.WriteLine($"required steps (part two): {steps2}");
            Console.ReadKey();
        }
    }
}
