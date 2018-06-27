using System;
using System.IO;

namespace MinimumSpanningTree
{
    partial class Program
    {   

        static void Main(string[] args)
        {

            var input = File.ReadAllLines(@"C:\Users\beth.hart\source\repos\Algorithms\MinimumSpanningTree\MinimumSpanningTree\tinyEWG.txt");
            EdgeWeightedGraph ewg = new EdgeWeightedGraph(input);
            LazyPrimMST mst = new LazyPrimMST(ewg);
            Console.WriteLine(mst.Weight());
        }
    }
}
