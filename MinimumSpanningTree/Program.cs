using System;
using System.IO;
using System.Collections;

namespace MinimumSpanningTree
{
    class Program
    {   

        static void Main(string[] args)
        {
            string[] dataFiles = new string[]
            {@"tinyEWG.txt",
                @"mediumEWG.txt"
            };
            foreach (var file in dataFiles)
            {
                var input = File.ReadAllLines(file);
                EdgeWeightedGraph ewg = new EdgeWeightedGraph(input);
                LazyPrimMST mst = new LazyPrimMST(ewg);
                foreach (var e in mst.Edges())
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine(mst.Weight());
            }
        }
    }
}
