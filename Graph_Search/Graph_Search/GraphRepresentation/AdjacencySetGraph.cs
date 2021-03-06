using Graph_Search.GraphObjects;

namespace Graph_Search;

public class AdjacencySetGraph : GraphBase
{
    private HashSet<Node> VertexSet { get; }

    public AdjacencySetGraph(int numVertices, bool directed = false) : base(numVertices, directed)
    {
        VertexSet = new HashSet<Node>();
        for (int i = 0; i < numVertices; i++)
        {
            VertexSet.Add(new Node(i));
        }
    }

    public override void AddEdge(int v1, int v2, int weight = 1)
    {
        if (v1 >= NumVertices || v2 >= NumVertices || v1 < 0 || v2 < 0)
            throw new ArgumentOutOfRangeException("Vertices are out of bounds");

        if (weight != 1) throw new ArgumentException("An adjacency set cannot represent non-one edge weights");

        VertexSet.ElementAt(v1).AddEdge(v2);
        
        if (!Directed)
            VertexSet.ElementAt(v2).AddEdge(v1);
    }

    public override IEnumerable<int> GetAdjacentVertices(int v)
    {
        if(v < 0 || v >= NumVertices) 
            throw new NotImplementedException("Cannot access vertex");

        return VertexSet.ElementAt(v).GetAdjacentVertices();
    }

    public override int GetEdgeWeight(int v1, int v2)
    {
        return 1;
    }

    public void MarkVertex(int v)
    {
        VertexSet.ElementAt(v).SetVisited(true);
    }

    public void SetCostToReach(int v, int cost)
    {
        VertexSet.ElementAt(v).SetCostToReach(cost);
    }

    public void GetCostToReach(int v)
    {
        VertexSet.ElementAt(v).GetCostToReach();
    }
}