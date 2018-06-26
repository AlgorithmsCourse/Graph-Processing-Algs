using System.Collections.Generic;
using System;

namespace MinimumSpanningTree
{
    public class MinPQ<Edge> where Edge : IComparable
    {
        Edge[] _heap;
        int N = 0; //size of PQ
        public MinPQ(int size)
        {
            _heap = new Edge[size];
        }

        public void Insert(Edge v)
        {
            _heap[++N] = v;
            Swim(N);
        }
        private  void Swim(int child)
        {
            while (child > 1)
            {
                var parent = child / 2;
                if (Greater(_heap[child], _heap[parent])) break;
                Exch(_heap[child], _heap[parent]);
                child = parent;
            }
        }
        public Edge DelMin()
        {
            var min = _heap[1];
            _heap[1] = _heap[N];
            N--;
            Sink(1);
            return min;
        }
        private void Sink(int p)
        {
            while (p*2 <= N)
            {
                var lC = p*2;
                if (lC < N && Greater(_heap[lC], _heap[++lC])) lC++;
                if (!Greater(_heap[p], _heap[lC])) break;
                Exch(_heap[p], _heap[lC]);
                p = lC;
            }
        }

        public Edge Min()
        {
            return _heap[1];
        }

        public int Size() => N;

        public bool IsEmpty => N == 0;

        private bool Greater(Edge v, Edge w)
        {   
            return v.CompareTo(w)>0;
         }
        private void Exch(Edge v, Edge w)
        {
            var temp = v;
            v = w;
            w = temp;
        }

 
        
    }
}
