Given an array of vertices V where V[i] represent the value of the i
th vertex. Also given pair of
edges where u and v represent the nodes that are connected by an UNDIRECTED edge. The task
is to find the sum of the minimum element in all the connected components of the given
undirected graph. If a node has no connectivity to any other node, count it as a component with
one node.

Input:
  • |V| = from 4000 to 8000
  • |E| = sparse or dense
  • # components = from 1 to 100

Function to Implement
  static int CalcSumOfMinInComps(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
  SumOfMin.cs includes this method.
  "valuesOfVertices": value of each vertex (vertices are named from 0 to |V| - 1)
  "edges": array of edges in the graph (where key: sourceVertex, value: destVertex)
  <returns> sum of the min value in each component of the graph

Example
  vals1 = {0, 2, 5, 3, 4, 8 };
  edges1[0] = new KeyValuePair<int, int>(1, 4);
  edges1[1] = new KeyValuePair<int, int>(4, 5);
  expected1 = 10;

  vals2 = {0, 1, 6, 2, 7, 3, 8, 4, 9, 5, 10};
  edges2[0] = new KeyValuePair<int, int>(1, 2);
  edges2[1] = new KeyValuePair<int, int>(3, 4);
  edges2[2] = new KeyValuePair<int, int>(5, 6);
  edges2[3] = new KeyValuePair<int, int>(7, 8);
  edges2[4] = new KeyValuePair<int, int>(9, 10);
  expected2 = 15;
