using ExamDataWeek1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service
{
    internal class PrintTypes
    {
        public static void PrintPreOrder(DefenceStrategyNode node, int level = 0)
        {
            if (node == null) return;

            Console.WriteLine(new string(' ', level * 4) + $"[{node.MinSeverity}, {node.MaxSeverity}]");
            Console.WriteLine(new string(' ', level * 4) + "Defenses: " + string.Join(", ", node.Defenses));

            PrintPreOrder(node.Left, level + 1);

            PrintPreOrder(node.Right, level + 1);
        }

        public static void PrintInOrder(DefenceStrategyNode node, int level = 0)
        {
            if (node == null) return;

            PrintInOrder(node.Left, level + 1);

            Console.WriteLine(new string(' ', level * 4) + $"[{node.MinSeverity}, {node.MaxSeverity}]");
            Console.WriteLine(new string(' ', level * 4) + "Defenses: " + string.Join(", ", node.Defenses));

            PrintInOrder(node.Right, level + 1);
        }

        public static void PrintPostOrder(DefenceStrategyNode node, int level = 0)
        {
            if (node == null) return;

            PrintPostOrder(node.Left, level + 1);

            PrintPostOrder(node.Right, level + 1);

            Console.WriteLine(new string(' ', level * 4) + $"[{node.MinSeverity}, {node.MaxSeverity}]");
            Console.WriteLine(new string(' ', level * 4) + "Defenses: " + string.Join(", ", node.Defenses));
        }

        public static void PrintTreePreOrder(DefenceStrategyNode node, string indent = "", bool isLeft = true)
        {
            if (node == null) return;

            Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + $"[{node.MinSeverity}, {node.MaxSeverity}]");
            Console.WriteLine(indent + (isLeft ? "│   " : "    ") + "Defenses: " + string.Join(", ", node.Defenses));

            if (node.Left != null)
                PrintTreePreOrder(node.Left, indent + (isLeft ? "│   " : "    "), true);

            if (node.Right != null)
                PrintTreePreOrder(node.Right, indent + (isLeft ? "│   " : "    "), false);
        }

    }
}
