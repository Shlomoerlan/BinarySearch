using ExamDataWeek1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service
{
    internal class BalansedTreeService
    {
       

        public static List<DefenceStrategyNode> CollectNodes(DefenceStrategyNode root)
        {
            List<DefenceStrategyNode> nodes = new List<DefenceStrategyNode>();
            InOrderCollect(root, nodes);
            return nodes;
        }

        public static void InOrderCollect(DefenceStrategyNode node, List<DefenceStrategyNode> nodes)
        {
            if (node == null) return;

            InOrderCollect(node.Left, nodes);
            nodes.Add(new DefenceStrategyNode
            {
                MinSeverity = node.MinSeverity,
                MaxSeverity = node.MaxSeverity,
                Defenses = new List<string>(node.Defenses)
            });

            InOrderCollect(node.Right, nodes);
        }

        public static DefenceStrategyNode BuildBalancedTree(List<DefenceStrategyNode> nodes, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            DefenceStrategyNode node = nodes[mid];

            node.Left = BuildBalancedTree(nodes, start, mid - 1);
            node.Right = BuildBalancedTree(nodes, mid + 1, end);

            return node;
        }

        public static DefenceStrategyNode BalanceTree(DefenceStrategyNode root)
        {
            List<DefenceStrategyNode> nodes = CollectNodes(root);

            nodes.Sort((a, b) => a.MinSeverity.CompareTo(b.MinSeverity));

            return BuildBalancedTree(nodes, 0, nodes.Count - 1);
        }


    }
}
