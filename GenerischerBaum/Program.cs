using System;
using System.Threading;
using System.Collections.Generic;

namespace GenerischerBaum
{
    class Program
    {
        static void Main(string[] args)
        {
        var tree = new TreeNode<string>(null, "root");
        var child1 = tree.CreateNode("child1");
        var child2 = tree.CreateNode("child2");
        tree.AppendChild(child1);
        tree.AppendChild(child2);
        var grand11 = tree.CreateNode("grand11");
        var grand12 = tree.CreateNode("grand12");
        var grand13 = tree.CreateNode("grand13");
        child1.AppendChild(grand11);
        child1.AppendChild(grand12);
        child1.AppendChild(grand13);
        var grand21 = tree.CreateNode("grand21");
        child2.AppendChild(grand21);
        child1.RemoveChild(grand12);

        //tree.PrintTree();
        //tree.ForEach(Func2);
        //tree.ForEach(Func);
        tree.PrintTree();
        Thread.Sleep(50000);
        }
        static void Func(TreeNode<string> treeNode)
        {
            Console.Write(treeNode + " | ");
        }

        static void Func2(TreeNode<string> treeNode)
        {
            treeNode.SetContent(treeNode.GetContent() + "(i bims func2 die diesen string verändert hat)");
        }

        static void Test1(TreeNode<string> tree){
            //tree.AddEventListener("AppendChild",PrintMSG);
        }

        static void PrintMSG(){
            Console.WriteLine("Kind is da");
        }
    }
}
