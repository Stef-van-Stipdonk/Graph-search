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

    public IEnumerable<int> GetFastestPath(int startVertex, int endVertex)
    {
        if (startVertex >= Graph.GetNumberOfVertices() || endVertex >= Graph.GetNumberOfVertices() || startVertex < 0 || endVertex < 0)
            throw new ArgumentException("startVertex or endVertex not in bounds of vertices");
        
        var nodesToVisitQueue = new Queue<int>();
        nodesToVisitQueue.Enqueue(startVertex);
        
        var visitedNodes = new List<int>();

        var stepsToEndNode = 0;
        
        while (nodesToVisitQueue.Count > 0)
        {
            startVertex = nodesToVisitQueue.Dequeue();

            if (visitedNodes.Contains(startVertex)) continue;
            
            visitedNodes.Add(startVertex);
            
            Console.Write($"{startVertex} -> ");

            stepsToEndNode++;

            if (startVertex == endVertex)
                break;

            foreach (var vertex in Graph.GetAdjacentVertices(startVertex))
            {
                if (!visitedNodes.Contains(vertex))
                    nodesToVisitQueue.Enqueue(vertex);
            }
        }
        
        Console.WriteLine("Done");
        Console.WriteLine($"Took {stepsToEndNode} steps");
        
        return visitedNodes;
    }
}