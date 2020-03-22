using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class UndirectedGraph:Graph
    {
        public UndirectedGraph(){
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
        }
        
        /// <param name="n">Number of vertices</param>
        public UndirectedGraph(int n)
        {
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
            nmbVertices = n;
        }
        
        /// <param name="n">Number of vertices</param>
        /// <param name="m">Number of edges</param>
        /// <param name="edges">For each node the list of nodes it is connected to</param>
        public UndirectedGraph(int n, int m, List<Edge>[] edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            graph = new List<Edge>[NMAX];
            graph = edges;
        }

        /// <param name="n">Number of vertices</param>
        /// <param name="m">Number of edges</param>
        /// <param name="edges">List of edges</param>
        public UndirectedGraph(int n, int m, List<Tuple<int, int>> edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            foreach (var t in edges)
                addEdge(t.Item1, t.Item2);
        }

        public override void randomizeGraph()
        {
            Random rand = new Random();
            for(int i = 1; i  < nmbVertices; ++i)
                for(int j = i+1; j <= nmbVertices; ++j)
                {
                    int ok = rand.Next(0, 2);
                    if (ok != 0)
                        addEdge(i, j);
                }
        }

        
        
        public List<Edge>[] Graph
        {
            get { return graph; }
            set { graph = value; }
        }

    }
}
