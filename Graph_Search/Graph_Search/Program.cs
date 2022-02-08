

using Graph_Search;
using Graph_Search.PathfindingMethods;

var numVertices = 8;

var set = new AdjacencySetGraph(numVertices, false);

set.AddEdge(0, 1);
set.AddEdge(0, 5);

set.AddEdge(1, 6);

set.AddEdge(2, 3);
set.AddEdge(2, 6);

set.AddEdge(3, 6);
set.AddEdge(3, 7);

set.AddEdge(4, 5);

set.AddEdge(5, 6);

var breathFirst = new BreathFirstSearch(set);

var marked = breathFirst.GetFastestPath(0, 4).ToList();
