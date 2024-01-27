/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class SumOfMin
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given an UNDIRECTED Graph, calculate the sum of the min value in each connected component
        /// </summary>
        /// <param name="valuesOfVertices">value of each vertex (vertices are named from 0 to |V| - 1)</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <returns>sum of the min value in each component of the graph</returns>
        public static int CalcSumOfMinInComps(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            return Min(valuesOfVertices, edges);

        }
        public static int Min(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
        {
            var Vertices_Color = new Dictionary<int, string>();
            var graph = new Dictionary<int, List<int>>();
            var SumOfMin = 0;
            for (int i = 0; i < valuesOfVertices.Length; i++)
            {
                graph[i] = new List<int>();
                Vertices_Color[i] = "White";
            }

            foreach (var edge in edges)
            {
                graph[edge.Key].Add(edge.Value);
                graph[edge.Value].Add(edge.Key);
            }

            for (int start = 0; start < valuesOfVertices.Length; start++)
            {
                if (Vertices_Color[start] == "White")
                {
                    SumOfMin += BFS(graph, start, valuesOfVertices, Vertices_Color);
                }
            }

            return SumOfMin;
        }
        private static int BFS(Dictionary<int, List<int>> graph, int startVertex, int[] valuesOfVertices,
            Dictionary<int, string> Vertices_Color)
        {
            var Queue = new Queue<int>();
            var MinValue = valuesOfVertices[startVertex];

            Vertices_Color[startVertex] = "Gray";
            Queue.Enqueue(startVertex);
            while (Queue.Count != 0)
            {
                var v = Queue.Dequeue();

                foreach (var vertex in graph[v])
                {
                    if (Vertices_Color[vertex] == "White")
                    {
                        Vertices_Color[vertex] = "Gray";
                        Queue.Enqueue(vertex);
                        MinValue = Math.Min(MinValue, valuesOfVertices[vertex]);
                    }
                    else if (Vertices_Color[vertex] == "Gray")
                    {
                        MinValue = Math.Min(MinValue, valuesOfVertices[vertex]);
                    }
                }
                Vertices_Color[v] = "Black";
            }
            return MinValue;
        }
        #endregion
    }
}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{

    public static class SumOfMin
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given an UNDIRECTED Graph, calculate the sum of the min value in each connected component
        /// </summary>
        /// <param name="valuesOfVertices">value of each vertex (vertices are named from 0 to |V| - 1)</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <returns>sum of the min value in each component of the graph</returns>


        public static void DeapthFirstSearch(int node, Stack<int> com, List<int>[] adj, Dictionary<int, string> color, Stack<int> done)
        {

            color[node] = "g";
            com.Push(node);

            while (com.Count > 0)

            {
                int curr = com.Pop();

                if (color[curr] == "g")
                {
                    done.Push(curr);
                }
                if (adj[curr] != null)
                {
                    foreach (int a in adj[curr])
                    {
                        if (color[a] == "w")
                        {
                            color[a] = "g";
                            //   done.Push(neighbour);
                            com.Push(a);
                        }
                    }
                    color[curr] = "b";
                }
            }
        }
        public static int CalcSumOfMinInComps(int[] valuesOfVertices, KeyValuePair<int, int>[] edges)
        {
            int res = 0;
            List<int>[] adjacent;
            adjacent = new List<int>[valuesOfVertices.Length];
            Dictionary<int, string> color;
            color = new Dictionary<int, string>(valuesOfVertices.Length + 1);

            int y = 0;
            while (y < valuesOfVertices.Length)
            {
                adjacent[y] = new List<int>();
                color[y] = "w";
                y++;
            }
            for (int x = 0; x < edges.Length; x++)
            {
                KeyValuePair<int, int> edge = edges[x];
                int source = edge.Key, dest = edge.Value;
                adjacent[source].Add(dest);
                adjacent[dest].Add(source);
            }

            Stack<Stack<int>> c;
            c = new Stack<Stack<int>>();

            int it = 0;
            while (it < valuesOfVertices.Length)
            {
                if (color[it] == "w")
                {
                    Stack<int> x = new Stack<int>();
                    Stack<int> done = new Stack<int>();
                    DeapthFirstSearch(it, x, adjacent, color, done);
                    c.Push(done);
                }
                it++;
            }
            Stack<Stack<int>> allComponents;
            allComponents = c;

            foreach (Stack<int> i in allComponents)
            {
                Stack<int> connComp = i;
                int max = 10000000;
                foreach (int j in connComp)
                {
                    int p = j;
                    if (valuesOfVertices[p] < max)
                    {
                        max = valuesOfVertices[p];
                    }
                }
                res = res + max;
            }
            return res;
            #endregion

        }
    }

}


