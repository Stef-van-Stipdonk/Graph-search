namespace Graph_Search.GraphObjects;

public class Node
{
    private readonly int Vertex;
    private readonly HashSet<int> AdjacencySet;

    public Node(int vertex)
    {
        Vertex = vertex;
        AdjacencySet = new HashSet<int>();
    }

    public void AddEdge(int v)
    {
        if (Vertex == v)
            throw new ArgumentException("The vertex cannot be adjacent to itself");

        AdjacencySet.Add(v);
    }

    public HashSet<int> GetAdjacentVertices()
    {
        return AdjacencySet;
    }
}