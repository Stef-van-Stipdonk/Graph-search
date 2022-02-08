using System.Text;

namespace Graph_Search.GraphObjects;

public abstract class GraphBase
{
    protected readonly int NumVertices;
    protected readonly bool Directed;

    protected GraphBase(int numVertices, bool directed = false)
    {
        NumVertices = numVertices;
        Directed = directed;
    }

    public abstract void AddEdge(int v1, int v2, int weight = 1);

    public abstract IEnumerable<int> GetAdjacentVertices(int v);

    public abstract int GetEdgeWeight(int v1, int v2);

    public virtual void Display()
    {
        Console.WriteLine(Directed ? "Directed Graph:" : "Undirected Graph:");
        
        for (int i = 0; i < NumVertices; i++)
        {
            StringBuilder result = new StringBuilder();

            result.Append($"v{i} ->");
            
            foreach (var vertex in GetAdjacentVertices(i))
            {
                result.Append($" v{vertex}");
            }
            
            Console.WriteLine(result);
        }
    }
}