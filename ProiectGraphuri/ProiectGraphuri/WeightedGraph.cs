using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    abstract class WeightedGraph:Graph
    {
        
        public static int INF = 0x3f3f3f3f;
        

        public override int[,] returnAdjiacentMatrix()
        {
            int[,] a = new int[nmbVertices + 5, nmbVertices + 5];
            
            for(int i = 1; i <= nmbVertices; ++i)
            {
                foreach (Edge e in graph[i])
                    a[e.Vertex1, e.Vertex2] = e.Weight;
            }

            return a;
        }

        virtual public int[,] shortestLengthPaths()
        {
            int[,] rf = returnAdjiacentMatrix();
            initINF(ref rf, nmbVertices);

            for (int k = 1; k <= nmbVertices; ++k)
                for (int i = 1; i <= nmbVertices; ++i)
                    for (int j = 1; j <= nmbVertices; ++j)
                        if (rf[i, j] > rf[i, k] + rf[k, j])
                            rf[i, j] = rf[i, k] + rf[k, j];

            return rf;
        }


        /// <summary>
        /// Returns an array where a[i] = shortestLength (start vertex, i vertex). All aray will be -1 if there is a negative cycle
        /// </summary>
        /// <param name="startVertex">Reference Vertex</param>
        /// <returns></returns>
        virtual public int[] shortestLengthPaths(int startVertex)
        {
            int[] negative = new int[nmbVertices + 5];
            int[] Dmin = new int[nmbVertices + 5], viz = new int[nmbVertices + 5], decateori = new int[nmbVertices + 5];
            for (int i = 1; i <= nmbVertices; ++i)
            {
                Dmin[i] = INF;
                negative[i] = -1;
            }

            Queue<int> Q = new Queue<int>();
            Q.Enqueue(startVertex);
            Dmin[startVertex] = 0;
            viz[startVertex] = 1;

            while(Q.Any())
            {
                int top = Q.First();
                Q.Dequeue();
                viz[top] = 0;
                foreach(Edge edge in graph[top])
                    if(Dmin[edge.Vertex2] > Dmin[top] + edge.Weight)
                    {
                        Dmin[edge.Vertex2] = Dmin[top] + edge.Weight;
                        decateori[edge.Vertex2]++;
                        if(viz[edge.Vertex2] == 0)
                        {
                            Q.Enqueue(edge.Vertex2);
                            viz[edge.Vertex2] = 1;
                        }
                        if(decateori[edge.Vertex2] >= nmbVertices)
                        {
                            return negative;
                        }
                    }
            }
            return Dmin;
        }
        
        /// <summary>
        /// Makes all paths that don't exist INF
        /// </summary>
        /// <param name="a">Adjiacent Matrix</param>
        /// <param name="n">Number of vertices</param>
        private void initINF(ref int[,] a, int n)
        {
            for (int i = 1; i <= n; ++i)
                for (int j = 1; j <= n; ++j)
                    if (a[i, j] == 0 && i != j)
                        a[i, j] = INF;
        }


        public List<Edge>[] Graph
        {
            get { return graph; }
            set { graph = value; }
        }

    }
}
