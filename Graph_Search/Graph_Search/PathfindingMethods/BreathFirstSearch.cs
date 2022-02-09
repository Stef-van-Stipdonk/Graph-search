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
        visitedNodes.Add(startVertex);
        
        int?[] prevArray = new int?[Graph.GetNumberOfVertices()];
        
        while (nodesToVisitQueue.Count > 0)
        {
            var currVertex = nodesToVisitQueue.Dequeue();
            
            if (currVertex == endVertex)
                break;

            foreach (var vertex in Graph.GetAdjacentVertices(currVertex))
            {
                if (!visitedNodes.Contains(vertex))
                {
                    nodesToVisitQueue.Enqueue(vertex);
                    visitedNodes.Add(currVertex);
                    
                    if(prevArray[vertex] == null)
                        prevArray[vertex] = currVertex;
                }
            }
        }

        var path = new List<int>();

        for (int? i = endVertex; i != null; i = prevArray[(Index)i])
        {
            path.Add((int)i);
        }

        path.Reverse();

        if (path[0] == startVertex)
            return path;
        
        return new List<int>();
    }
}