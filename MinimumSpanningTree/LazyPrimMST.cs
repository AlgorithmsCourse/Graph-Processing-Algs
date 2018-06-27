using System;
using System.Collections;
using System.Collections.Generic;

namespace MinimumSpanningTree
{
  
        public class LazyPrimMST
    {
        private bool[] _marked;
        private Queue<Edge> _mst;
        private MinPQ<Edge> _pq;


        public LazyPrimMST(EdgeWeightedGraph g)
        {
            _marked = new bool[g.V()]; //tracks V's that are added to Graph
            _pq = new MinPQ<Edge>(g.E()); //sorts edges do that min is next
            _mst = new Queue<Edge>(); //collects min edges connecting each added V
            Check(g, 0);

                while (!_pq.IsEmpty)
                {
                    //get the smallest edge by weight
                    var minCross = _pq.DelMin();
                    //if either end of the minCross is already marked, skip it and select another
                    int x = minCross.Either();
                    int w = minCross.Other(x);
                    if (_marked[x] && _marked[w]) continue;
                    _mst.Enqueue(minCross);
                    if (!_marked[x]) Check(g, x);
                    if (!_marked[w]) Check(g, w);
                }

        }

        private void Check(EdgeWeightedGraph g, int v)
        {
            _marked[v] = true;
            //for each edge connected to v...
            foreach (var e in g.Adj(v))
            {   //if the other end of edge is not yet marked...
                if (!_marked[e.Other(v)])
                    //add it to the priority queue
                    _pq.Insert(e);
            }
        }
            public IEnumerable<Edge> Edges()
            {
            return _mst;
            }
            
        public double Weight()
        {
            double weight = 0;
            foreach(var e in Edges())
            {
                weight += e.Weight();
            }
            return weight;
        }
        }
    }
    

