using System;
using System.Collections.Generic;
using System.Text;
using DirectionalGraphs;
using PriorityQueue;

namespace GraphProcessingAlgs
{
    //finds shortest path, adding next non-tree vertex that is closest to the source
    //UTH:start with source on PQ. Then everytime you delete the min edge, check the adj edges. If they form a shorter path
    //than what is already listed for that V, add it to the PQ. Once PQ is empty, parent linked array EdgeTo should trace path.
    class DijkstrasShortestPath
    {
        //parent-linked array that shows the edge leading to it
        DirectedEdge[] _edgeTo;
        double[] _distTo;
        IndexMinPQ<Double> _pq;

        //ctor inits DSs, builds shortest path tree and computes distances
        //takes a built DiGraph and a source vertex
        public DijkstrasShortestPath(EdgeWeightedDiGraph g, int s)
        {
            _pq = new IndexMinPQ<double>(g.V);
            _edgeTo = new DirectedEdge[g.V];
            _distTo = new double[g.V];
            //load initial values
            for (int i = 1; i < g.V; i++)
            {
                _distTo[i] = Double.PositiveInfinity;
            }
            _distTo[s] = 0.0;
            _edgeTo[s] = null;
            //loads a starting value onto PQ to start process
            _pq.Insert(s, _distTo[s]);
            //start business logic
            //start cycle of deleting min edges and checking adj edges for 'eligability'
            while (!_pq.IsEmpty())
            {
                var minV = _pq.DelMin();
                Relax(g, minV);
            }
        }
            private void Relax(EdgeWeightedDiGraph g, int v) {
                foreach (var edge in g.Adj(v))
                {
                    //test if current weight of path to W is more than going through v; ie v 'relaxes' the path
                    
                    int w = edge.To();
                    double distViaV = _distTo[v] + edge.Weight();
                    //if current distTo w is greater than (distTo v + this.edge weight), then add/or replace on arrays and PQ
                    if (distViaV < _distTo[w])
                    {
                        _distTo[w] = distViaV;
                        _edgeTo[w] = edge;
                        if (_pq.Contains(w))
                        {
                            _pq.Change(w, distViaV);
                        }
                        else
                        {
                            _pq.Insert(w, distViaV);
                        }
                    }
                } 
        



        } 

        //returns weight/cost of shortest path from source to v
        public double DistTo(int v)
        {
            return _distTo[v];
        }

        //Bool repr is Path from source to v exists
        public bool HasPathTo(int v)
        {
            return _distTo[v] != double.PositiveInfinity;
        }

        //collection of edges repr the shortest path from source to v
        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            var path = new Stack<DirectedEdge>();
            for (int i = v; _edgeTo[i] != null; i = _edgeTo[i].From())
            {
                path.Push(_edgeTo[i]);
            }
            return path;
        }
    }
}
