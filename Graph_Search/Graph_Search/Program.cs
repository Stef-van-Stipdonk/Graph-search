

using Graph_Search;
using Graph_Search.PathfindingMethods;

var numVertices = 8;

var set = new AdjacencySetGraph(numVertices, false);

set.AddEdge(0, 1);
set.AddEdge(1, 2);
set.AddEdge(1, 3);

var breathFirst = new BreathFirstSearch(set);

breathFirst.GetFastestPath(0, 3);

