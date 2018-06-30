using System;
using System.Collections.Generic;

namespace MinimumSpanningTree
{
    /// <summary>
    //takes input from file and establishes and EdgeWeighted Graph
    /// </summary>
    public class EdgeWeightedGraph
    {
        private int _v;
        private int _e;
        private LinkedList<Edge>[] _adj;

        public EdgeWeightedGraph(int v)
        {
            _v = v;
            _e = 0;
            _adj = new LinkedList<Edge>[v];
            for(int i=0; i<_v; i++)
            {
                _adj[i] = new LinkedList<Edge>();
            }
        }

        //Creates Edges from parsed line from input
        public EdgeWeightedGraph(string[] input) :this(Convert.ToInt32(input[0]))
        {
            for(var i =2; i<input.Length; i++)
            {
                var parsedLine = input[i].Split();
                var newEdge = new Edge(Convert.ToInt32(parsedLine[0]), Convert.ToInt32(parsedLine[1]), Convert.ToDouble(parsedLine[2]));
                AddEdge(newEdge);
            }
        }

        public int V() => _v;
        public int E() => _e;
        public void AddEdge(Edge e)
        {
            int v = e.Either();
            int w = e.Other(v);

            _adj[v].AddFirst(e);
            _adj[w].AddFirst(e);
            _e++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return _adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            var edges = new LinkedList<Edge>();
            foreach (var v in _adj)
            {
                foreach(var e in v)
                {
                    if (e.Either() > e.Other(e.Either())) edges.AddFirst(e);
                }
            }
            return edges;
        }



    }
}
