using System;
using System.IO;
using System.Collections;
using DirectionalGraphs;
using GraphProcessingAlgs;

namespace GraphProcessingAlgs
{
    class Program
    {   

        static void Main(string[] args)
        {
            //string[] dataFiles = new string[]
            //{@"tinyEWG.txt",
            //    @"mediumEWG.txt"
            //};
            //foreach (var file in dataFiles)
            //{
            //    var input = File.ReadAllLines(file);
            //    EdgeWeightedGraph ewg = new EdgeWeightedGraph(input);
            //    LazyPrimMST mst = new LazyPrimMST(ewg);
            //    foreach (var e in mst.Edges())
            //    {
            //        Console.WriteLine(e);
            //    }
            //    Console.WriteLine(mst.Weight());
            //}

            var file = @"tinyEWD.txt";
            var data = File.ReadAllLines(file);
            var ewd = new EdgeWeightedDiGraph(data);
            DijkstrasShortestPath dsp = new DijkstrasShortestPath(ewd, 0);
            var sp = dsp.PathTo(5);
            foreach(var p in sp)
            {
                Console.WriteLine(p);
            }
            }
        }
    }

