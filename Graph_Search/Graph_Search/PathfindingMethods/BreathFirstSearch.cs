using Graph_Search.GraphObjects;

namespace Graph_Search.PathfindingMethods;

public class BreathFirstSearch
{
    private List<int> Path { get; set; }

    private AdjacencySetGraph Graph { get; set; }
    
    public BreathFirstSearch(AdjacencySetGraph graph)
    {
        Graph = graph;
    }

    public IEnumerable<int> GetFastestPath(int start, int end)
    {
        if (start >= Graph.GetNumberOfVertices() || end >= Graph.GetNumberOfVertices() || start < 0 || end < 0)
            throw new ArgumentException("start or end not in bounds of vertices");
        
        var queue = new Queue<int>();
        queue.Enqueue(start);
        
        var markedNodes = new List<int>();

        var amountOfVisits = 0;
        
        while (queue.Count > 0)
        {
            start = queue.Dequeue();

            if (!markedNodes.Contains(start))
            {
                markedNodes.Add(start);
                Graph.MarkVertex(start);

                amountOfVisits++;

                foreach (var vertex in Graph.GetAdjacentVertices(start))
                {
                    if (!markedNodes.Contains(vertex))
                        queue.Enqueue(vertex);
                }
            }
        }
        
        Console.WriteLine(amountOfVisits);
        
        return markedNodes;
    }
}