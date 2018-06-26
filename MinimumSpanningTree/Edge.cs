using System;

namespace MinimumSpanningTree
{ 
    public class Edge: IComparable<Edge>
    {
        double _weight;
        int _v;
        int _w;

        public Edge(int v, int w, double weight)
        {
            _weight = weight;
            _v = v;
            _w = w;
        }

        public double Weight() => _weight;

        public int Either() => _v;

        public int Other(int vertex)
        {
            if (vertex == _v) return _w;
            else if (vertex == _w) return _v;
            else throw new Exception("Inconsistant Edge");

        }

        public int CompareTo(Edge that)
        {
            if (this.Weight() < that.Weight()) return -1;
            if (this.Weight() > that.Weight()) return +1;
            else return 0;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1} {2}", _v, _w, _weight);
        }
    }
}
