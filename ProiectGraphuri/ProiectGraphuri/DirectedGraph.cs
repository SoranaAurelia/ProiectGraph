using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class DirectedGraph:Graph
    {
        public DirectedGraph()
        {
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
        }

        /// <param name="n">Number of vertices</param>
        public DirectedGraph(int n)
        {
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
            nmbVertices = n;
        }

        /// <param name="n">Number of vertices</param>
        /// <param name="m">Number of edges</param>
        /// <param name="edges">For each node the list of nodes it is connected to</param>
        public DirectedGraph(int n, int m, List<Edge>[] edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            graph = new List<Edge>[NMAX];
            graph = edges;
        }

        /// <param name="n">Number of vertices</param>
        /// <param name="m">Number of edges</param>
        /// <param name="edges">List of edges</param>
        public DirectedGraph(int n, int m, List<Tuple<int, int>> edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < nmbVertices; ++i)
                graph[i] = new List<Edge>();
            foreach (var t in edges)
                addEdge(t.Item1, t.Item2);
        }

        public DirectedGraph(DirectedGraph dg)
        {
            nmbVertices = dg.NmbVertices;
            nmbEdges = dg.NmbEdges;
            
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
            graph = dg.Graph;
        }

        /// <summary>
        /// Returns the indegree of the vertex.
        /// </summary>
        public int indeg(int vertex)
        {
            int rez = 0;
            for(int i = 1; i <= nmbVertices; ++i)
            {
                foreach (Edge edge in graph[i])
                    if (edge.Vertex2 == vertex)
                        rez++;
            }
            return rez;
        }


        public override int numberOfIsolatedVertices()
        {
            int nr = 0;
            for (int i = 1; i <= nmbVertices; ++i)
                if (indeg(i) == 0 && outdeg(i) == 0)
                    nr++;
            return nr;
        }

        public override void randomizeGraph()
        {
            Random rand = new Random();
            if (nmbVertices == 0)
                nmbVertices = rand.Next(0, 15);
            for (int i = 1; i < nmbVertices; ++i)
                for (int j = i+1; j <= nmbVertices; ++j)
                {
                    int ok = rand.Next(0, 7);
                    if (ok < 4)
                        continue;
                    if (ok == 4)
                        addEdge(i, j);
                    if(ok == 5)
                    {
                        addEdge(j, i);
                        addEdge(i, j);
                    }
                    if (ok == 6)
                        addEdge(j, i);
                }
        }

        public override void addEdge(int from, int to, int weight = 1)
        {
            graph[from].Add(new Edge(from, to, 1));
        }

        public override void deleteEdge(int from, int to)
        {
            int indexDel = 0;
            for (int i = 0; i < graph[from].Count; ++i)
                if (graph[from][i].Vertex2 == to)
                {
                    indexDel = i;
                    break;
                }
            graph[from].RemoveAt(indexDel);
            nmbEdges--;
        }

        private Stack<int> S;
        public List<Tuple<int, List<int>>> StronglyConnectedComponents()
        {
            List<Tuple<int, List<int>>> ctc = new List<Tuple<int, List<int>>>();
            int[] viz = new int[nmbVertices + 5], isInStack = new int[nmbVertices + 5], lowlink = new int[nmbVertices + 5],
                  idx = new int[nmbVertices + 5];
            int index = 1;
            if (S == null)
                S = new Stack<int>();
            else if(S.Any()) S.Clear();
            for (int i = 1; i <= nmbVertices; ++i)
                if (viz[i] == 0)
                    solve(i, ref viz, ref isInStack, ref lowlink, ref idx, ref index, ref ctc);

            return ctc;

        }

        public override bool isConnected()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph(nmbVertices);
            int[,] adiac = returnAdjiacentMatrix();

            for (int i = 1; i <= nmbVertices; ++i)
                for (int j = 1; j <= i; ++j)
                    if (adiac[i, j] == 1 || adiac[j, i] == 1)
                    {
                        undirectedGraph.NmbEdges++;
                        undirectedGraph.addEdge(i, j);
                    }

            return undirectedGraph.isConnected();
        }

        void addCC(ref int[] isInStack, ref int[] lowlink, ref int[] idx, ref List<Tuple<int, List<int>>> ctc)
        {
            List<int> aux = new List<int>();
            int top, nrelem = 0;
            do
            {
                top = S.Peek();
                aux.Add(top);
                nrelem++;
                S.Pop();
                isInStack[top] = 0;
            } while (lowlink[top] != idx[top]);

            ctc.Add(Tuple.Create(nrelem, aux));
        }


        private void solve(int nod, ref int[] viz, ref int[] isInStack, ref int[] lowlink, ref int[] idx, ref int index, ref List<Tuple<int, List<int>>> ctc)
        {
            S.Push(nod);
            isInStack[nod] = 1;
            viz[nod] = 1;
            idx[nod] = index;
            lowlink[nod] = index;
            index++;

            foreach (Edge edge in graph[nod])
            {
                int v = edge.Vertex2;
                if (viz[v] == 0)
                {
                    solve(v, ref viz, ref isInStack, ref lowlink, ref idx, ref index, ref ctc);
                    lowlink[nod] = Math.Min(lowlink[nod], lowlink[v]);
                }
                else
                {
                    if (isInStack[v] == 1)
                        lowlink[nod] = Math.Min(lowlink[nod], lowlink[v]);
                }
            }

            if (lowlink[nod] == idx[nod])
            {
                addCC(ref isInStack, ref lowlink, ref idx, ref ctc);
            }
        }


        
        public List<Edge>[] Graph
        {
            get { return graph; }
            set { graph = value; }
        }
    }
}
