using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class UndirectedWeightedGraph:WeightedGraph
    {
        public UndirectedWeightedGraph()
        {
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
        }
        public UndirectedWeightedGraph(int n)
        {
            nmbVertices = n;
            graph = new List<Edge>[NMAX];
            for (int i = 1; i < NMAX; ++i)
                graph[i] = new List<Edge>();
        }
        public UndirectedWeightedGraph(int n, int m, List<Edge>[] edges)
        {
            nmbVertices = n;
            nmbEdges = m;
            graph = edges;
        }
        public UndirectedWeightedGraph(UndirectedWeightedGraph undirected)
        {
            nmbVertices = undirected.NmbVertices;
            nmbEdges = undirected.NmbEdges;
            graph = undirected.Graph;
        }


        
        public override void randomizeGraph()
        {

            Random rand = new Random();
            if (nmbVertices == 0)
                nmbVertices = rand.Next(0, 15);
            for (int i = 1; i < nmbVertices; ++i)
                for (int j = i + 1; j <= nmbVertices; ++j)
                {
                    int ok = rand.Next(0, 2);
                    int weight = rand.Next(-100, 100);
                    if (ok != 0)
                        addEdge(i, j, weight);
                }
        }

        public override void addEdge(int from, int to, int weight)
        {
            graph[from].Add(new Edge(from, to, weight));
            graph[to].Add(new Edge(to, from, weight));
            nmbEdges++;
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

            for (int j = 0; j < graph[to].Count; ++j)
                if (graph[to][j].Vertex2 == from)
                {
                    indexDel = j;
                    break;
                }
            graph[to].RemoveAt(indexDel);
            nmbEdges--;
        }

        private int rad_act = 0;
        /// <summary>
        /// Returns a tuple {minimum cost, undirectedWeightedGraph remaining}
        /// </summary>
        /// <returns></returns>
        public Tuple<int, UndirectedWeightedGraph> minimumSpanningTree()
        {
            UndirectedWeightedGraph uwg = new UndirectedWeightedGraph(nmbVertices);
            int[] tati = new int[nmbVertices + 5];
            initTati(ref tati);

            List<Edge> allEdges = new List<Edge>();
            initAll(ref allEdges);
            allEdges.Sort(
                delegate (Edge e1, Edge e2)
                {
                    int compareWeight = e1.Weight.CompareTo(e2.Weight);
                    if (compareWeight == 0)
                    {
                        int compareY = e1.Vertex2.CompareTo(e2.Vertex2);
                        if (compareY == 0)
                        {
                            return e1.Vertex1.CompareTo(e2.Vertex1);
                        }
                        else return compareY;
                    }
                    else return compareWeight;
                });

            int chosen = 0, cmin = 0;
            foreach(Edge actEdge in allEdges)
            {
                if (chosen >= nmbVertices - 1)
                    return Tuple.Create(cmin, uwg);
                if(!findSameR(actEdge.Vertex1, actEdge.Vertex2, ref tati))
                {
                    chosen++;
                    cmin += actEdge.Weight;
                    uwg.addEdge(actEdge.Vertex1, actEdge.Vertex2, actEdge.Weight);
                    unionOf(actEdge.Vertex1, actEdge.Vertex2, ref tati);
                }
            }
            return Tuple.Create(cmin, uwg);
        }

        private void initTati(ref int[] tati)
        {
            for (int i = 1; i <= nmbVertices; ++i)
                tati[i] = i;
        }

        private void initAll(ref List<Edge> edges)
        {
            int[,] adj = returnAdjiacentMatrix();
            for(int i = 1; i <= nmbVertices; ++i)
            {
                for (int j = 1; j <= i; ++j)
                    if (adj[i, j] != 0)
                        edges.Add(new Edge(i, j, adj[i, j]));
            }
        }

        private void rad(int x, ref int[] tati)
        {
            if(tati[x] == x)
            {
                rad_act = x;
                return;
            }
            rad(tati[x], ref tati);
            tati[x] = rad_act;

        }

        private void unionOf(int x, int y, ref int[] tati)
        {
            rad(x, ref tati);
            int aux = rad_act;
            rad(y, ref tati);
            tati[aux] = rad_act;

        }


        private bool findSameR(int x, int y, ref int[] tati)
        {
            rad(x, ref tati);
            int rox = rad_act;
            rad(y, ref tati);
            int roy = rad_act;
            if (rox == roy)
                return true;
            return false;
        }

        

    }
}
