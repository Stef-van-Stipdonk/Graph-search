

using Graph_Search;

var numVertices = 9;

var matrix = new AdjacencySetGraph(numVertices, false);

matrix.AddEdge(0, 8);
matrix.AddEdge(0, 6);
matrix.AddEdge(0, 1);
matrix.AddEdge(1, 2);
matrix.AddEdge(2, 8);

matrix.Display();
