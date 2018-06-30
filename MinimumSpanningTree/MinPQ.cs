using System.Collections.Generic;
using System;

namespace MinimumSpanningTree
{
    public class MinPQ<Key> where Key : IComparable<Key>
    {
        Key[] _heap;
        int N = 0; //size of PQ
        public MinPQ(int size)
        {
            _heap = new Key[size];
        }

        public void Insert(Key v)
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
                Exch(child, parent);
                child = parent;
            }
        }
        public Key DelMin()
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
                if (lC < N && Greater(_heap[lC], _heap[lC+1]))
                {
                    lC++;
                }
                if (!Greater(_heap[p], _heap[lC])) break;
                Exch(p, lC);
                p = lC;
            }
        }

        public Key Min()
        {
            return _heap[1];
        }

        public int Size() => N;

        public bool IsEmpty => N == 0;

        private bool Greater(IComparable<Key> v, Key w)
        {   
          
            return v.CompareTo(w)>0;
         }
        private void Exch(int v, int w)
        {
            var temp = _heap[v];
            _heap[v] = _heap[w];
            _heap[w] = temp;
        }

 
        
    }
}
