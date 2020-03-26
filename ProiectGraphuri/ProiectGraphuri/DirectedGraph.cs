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
            graph = new List<int>[NMAX];
            for (int i = 1; i < NMAX - 5; ++i)
                graph[i] = new List<int>();
        }

        /// <param name="n">Number of vertices</param>
        public DirectedGraph(int n)
        {
            graph = new List<int>[NMAX];
            for (int i = 1; i <= n; ++i)
                graph[i] = new List<int>();
            nmbVertices = n;
        }
        /// <param name="n">Number of vertices</param>
        /// <param name="m">Number of edges</param>
        /// <param name="edges">For each node the list of nodes it is connected to</param>
        public DirectedGraph(int n, int m, List<int>[] edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            graph = new List<int>[NMAX];
            graph = edges;
        }

        /// <param name="n">Number of vertices</param>
        /// <param name="m">Number of edges</param>
        /// <param name="edges">List of edges</param>
        public DirectedGraph(int n, int m, List<Tuple<int, int>> edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            foreach (var t in edges)
                addEdge(t.Item1, t.Item2);
        }

        public override void randomizeGraph()
        {
            Random rand = new Random();
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

        public override void addEdge(int from, int to)
        {
            graph[from].Add(to);
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
            UndirectedGraph undirectedGraph = new UndirectedGraph(nmbVertices, nmbEdges);
            int[,] adiac = returnAdjiacentMatrix();

            for (int i = 1; i <= nmbVertices; ++i)
                for (int j = 1; j <= i; ++j)
                    if(adiac[i, j] == 1)
                        undirectedGraph.addEdge(i, j);

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

            foreach (int v in graph[nod])
            {
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



        public int NmbVertices
        {
            get { return nmbVertices; }
            set { nmbVertices = value; }
        }

        public int NmbEdges
        {
            get { return nmbEdges; }
            set { nmbEdges = value; }
        }

        public List<int>[] Graph
        {
            get { return graph; }
            set { graph = value; }
        }
    }
}
