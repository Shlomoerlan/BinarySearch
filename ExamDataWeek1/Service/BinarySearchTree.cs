using ExamDataWeek1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service
{
    internal class BinarySearchTree
    {
        public DefenceStrategyNode Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public int FindMinSeverity(DefenceStrategyNode root)
        {
            var temp = root;
            while (temp.Left != null)
            {
                temp = temp.Left;
            }
            return temp.MinSeverity;
        }

        public DefenceStrategyNode PreOrderTreeSearch(DefenceStrategyNode root, int value, int minSeverity)
        {
            if (value < minSeverity)
            {
                throw new Exception("Attack severity is below the threshold. Attack is ignored");
            }

            if (root == null)
            {
                throw new Exception("No suitable defence was found. Brace for impact!");
            }

            if (value >= root.MinSeverity && value <= root.MaxSeverity)
            {
                return root;
            }

            DefenceStrategyNode leftNode = PreOrderTreeSearch(root.Left, value, minSeverity);
            if (leftNode != null)
            {
                return leftNode;
            }

            return PreOrderTreeSearch(root.Right, value, minSeverity);

        }


        public DefenceStrategyNode TreeSearch(DefenceStrategyNode root, int value, int minSeverity)
        {
            if (value < minSeverity)
            {
                throw new Exception("Attack severity is below the threshold. Attack is ignored");
            }

            if (root == null)
            {
                throw new Exception("No suitable defence was found. Brace for impact!");
            }

            if (value < root.MinSeverity)
            {
                return TreeSearch(root.Left, value, minSeverity);
            }
            else if (value > root.MaxSeverity)
            {
                return TreeSearch(root.Right, value, minSeverity);
            }

            return root;
        }
        public List<string> FindDefence
            (BinarySearchTree tree, DefenceStrategyNode root, ThreatModel threat, int minSeverity)
        {
            try
            {
                return tree.PreOrderTreeSearch(root, threat.Volume, minSeverity).Defenses.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void InsertRange(List<DefenceStrategyNode> list, BinarySearchTree tree)
        {
            foreach (DefenceStrategyNode defenc in list)
            {
                tree.Insert(defenc);
            }
        }


        public void Insert(DefenceStrategyNode newNode)
        {
            Root = InsertRec(Root, newNode);
        }

        private DefenceStrategyNode InsertRec(DefenceStrategyNode root, DefenceStrategyNode newNode)
        {
            if (root == null)
            {
                return newNode;
            }

            if (newNode.MinSeverity < root.MinSeverity)
            {
                root.Left = InsertRec(root.Left, newNode);
            }
            else if (newNode.MinSeverity > root.MinSeverity)
            {
                root.Right = InsertRec(root.Right, newNode);
            }

            return root;
        }

        public async Task PrintThreat(BinarySearchTree tree, DefenceStrategyNode root,
            List<ThreatModel> threatList, int minSeverty)
        {
            foreach (ThreatModel threat in threatList)
            {
                var defendes = FindDefence(tree, tree.Root, threat, minSeverty);
                if (defendes is List<string>)
                {
                    Console.WriteLine(string.Join(", ", defendes));
                }
                await Task.Delay(2000);

            }
        }

        public void Remove(int value)
        {
            // Use a helper method for the recursive implementation
            Root = RemoveRecursive(Root, value);
        }

        private DefenceStrategyNode? RemoveRecursive(DefenceStrategyNode? root, int Severity)
        {

            if (root == null)
            {
                return null;
            }

            if (Severity < root.MinSeverity)
            {
                root.Left = RemoveRecursive(root.Left, Severity);
            }
            else if (Severity > root.MaxSeverity)
            {
                root.Right = RemoveRecursive(root.Right, Severity);
            }
            else
            {
                if (root.Left == null && root.Right == null)
                {
                    return null;
                }
                else if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                else
                {
                    int minValue = FindMinSeverity(root.Right);
                    DefenceStrategyNode defence = TreeSearch(root, minValue, minValue);
                    root.MaxSeverity = defence.MaxSeverity;
                    root.MinSeverity = defence.MinSeverity;
                    root.Defenses = defence.Defenses;
                    
                    // Remove the successor from the right subtree
                    root.Right = RemoveRecursive(root.Right, Severity);
                }
            }

            return root;
        }
    }
}




