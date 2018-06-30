namespace MinimumSpanningTree
{

    public class EagerPrimMST
    {
        private Edge[] _edgeTo; //list of smallest known edges connecting the index vert to another vert
        private double[] _distTo; //the weight of each edge in _edgeTo
        private MinPQ<double> _pq;
        private bool[] _marked;

        public EagerPrimMST(EdgeWeightedGraph g)
        {
            _edgeTo = new Edge[g.V()];
            _distTo = new double[g.V()];
            for(var i=0; i < g.V(); i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _marked = new bool[g.V()];
            _pq = new MinPQ<double>(g.E());
            Visit(g, 0);

            
        }
        private void Visit(EdgeWeightedGraph g, int v)
        {
            _marked[v] = true;
            foreach (var e in g.Adj(v))
            {
                var notV = e.Other(v);
               
                if (e.Weight() < _distTo[notV]) 
                {
                    _edgeTo[notV] = e;
                    _distTo[notV] = e.Weight();
                    _pq.Insert(_distTo[notV]);
                }
            }
        }
    }
}
