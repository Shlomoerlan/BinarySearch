using ExamDataWeek1.Model;
using ExamDataWeek1.Service;
using System.Text.Json;

namespace ExamDataWeek1
{
    class Program
    {

        public static async Task Main()
        {
            // All Threat
            var threats = GetAll.GetAllThreat();
            // All defences
            var defences = GetAll.GetAllDefence();
            // All Unbalance defences
            var defenceUnbalance = GetAll.GetAllDefenceUnbalance();
            // create new tree
            BinarySearchTree tree = new ();       
            // insert all the defences
            tree.InsertRange(defenceUnbalance, tree);
            // Find min severtity
            int minSeverty = tree.FindMinSeverity(tree.Root);

            PrintTypes.PrintTreePreOrder(tree.Root);

            await Task.Delay(2000);

            DefenceStrategyNode balancedRoot = BalansedTreeService.BalanceTree(tree.Root);
            PrintTypes.PrintInOrder(balancedRoot);

            await Task.Delay(2000);

            // print the tree in order


            

            await tree.PrintThreat(tree, tree.Root, threats, minSeverty);
            
        }
    }
}




