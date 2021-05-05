using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    abstract class Graph
    {

        public class Edge
        {
            int vertex1, vertex2, weight;
            public Edge() { }

            public Edge(int v1, int v2, int w)
            {
                vertex1 = v1;
                vertex2 = v2;
                weight = w;
            }
            public static bool operator >(Edge first, Edge other)
            {
                if (first.weight != other.weight)
                    return first.weight > other.weight;
                if (first.vertex2 != other.vertex2)
                    return first.vertex2 > other.vertex2;
                return first.vertex1 > other.vertex1;
            }

            public static bool operator <(Edge first, Edge other)
            {
                if (first.weight != other.weight)
                    return first.weight < other.weight;
                if (first.vertex2 != other.vertex2)
                    return first.vertex2 < other.vertex2;
                return first.vertex1 < other.vertex1;

            }


            public int Vertex1
            {
                get { return vertex1; }
                set { vertex1 = value; }
            }
            public int Vertex2
            {
                get { return vertex2; }
                set { vertex2 = value; }
            }
            public int Weight
            {
                get { return weight; }
                set { weight = value; }
            }

        }

        public const int NMAX = 500;

        public int nmbVertices, nmbEdges;
        public List<Edge> []graph;

        

        virtual public int[,] returnAdjiacentMatrix(){
            int[,] toReturn = new int[NMAX, NMAX];

            for(int i = 1; i <= nmbVertices; ++i)
            {
                foreach (Edge var in graph[i])
                {
                    toReturn[i, var.Vertex2] = 1;
                }
            }

            return toReturn;


        }
        
        /// <param name="startVertex">Vertex to start the BFS from.</param>
        virtual public List<int> BFSArray(int startVertex) {
            List<int> toReturn = new List<int>();
            Queue<int> Q = new Queue<int>();
            int[] viz = new int[nmbVertices + 5];

            Q.Enqueue(startVertex);
            viz[startVertex] = 1;

            while(Q.Any())
            {
                int elemFirst = Q.First();
                toReturn.Add(elemFirst);
                Q.Dequeue();

                foreach(Edge edge in graph[elemFirst])
                {
                    int v = edge.Vertex2;
                    if(viz[v] == 0)
                    {
                        Q.Enqueue(v);
                        viz[v] = 1;

                    }
                }
            }
            return toReturn;

        }
        private void DFS(int st, ref List<int> where, ref int[] viz)
        {
            viz[st] = 1;
            where.Add(st);
            foreach (Edge edge in graph[st])
                if (viz[edge.Vertex2] == 0)
                    DFS(edge.Vertex2, ref where, ref viz);
        }

        /// <param name="startVertex">Vertex to start the DFS from.</param>
        virtual public List<int> DFSArray(int startVertex)
        {
            List<int> toReturn = new List<int>();
            int[] viz = new int[nmbVertices + 5];

            DFS(startVertex, ref toReturn, ref viz);

            return toReturn;
        }
        
        
        virtual public List<int> sortTop()
        {
            List<int> toReturn = new List<int>();
            Queue<int> Q = new Queue<int>();
            int[] viz = new int[nmbVertices + 1];


            for (int i = 1; i <= nmbVertices; ++i)
                graph[i].Sort(
                    delegate(Edge e1, Edge e2)
                    {
                        int compare2 = e1.Vertex2.CompareTo(e2.Vertex2);
                        return compare2;
                    });
            for (int i = 1; i <= nmbVertices; ++i)
                if (viz[i] == 0)
                    sortT(i, ref toReturn, ref viz);
            return toReturn;
        }

        virtual public int numberOfIsolatedVertices()
        {
            int nr = 0;
            for (int i = 1; i <= nmbVertices; ++i)
                if (graph[i].Count == 0)
                    nr++;
            return nr;
        }

        virtual public bool isConnected()
        {
            int[] viz = new int[NMAX];
            List<int> aux = new List<int>();
            DFS(1, ref aux, ref viz);

            if (aux.Count() < nmbVertices)
                return false;
            return true;
        }

        /// <summary>Returns a list of pairs {how many vertices in that component, list of vertices}</summary>
        virtual public List<Tuple<int, List<int>>> ConectedComponents()
        {
            List<Tuple<int, List<int>>> toReturn = new List<Tuple<int, List<int>>>();
            int[] viz = new int[nmbVertices + 5];
            int nmbModif = 0;

            for (int i = 1; i <= nmbVertices; ++i)
                if(viz[i] == 0)
                {
                    List<int> aux = new List<int>();
                    aux.Clear();
                    nmbModif = 0;
                    DFS_forCC(i, ref aux, ref viz, ref nmbModif);
                    toReturn.Add(Tuple.Create(nmbModif, aux));
                }
            return toReturn;
        }

        virtual public bool existsEdge(int from, int to)
        {
            foreach (Edge edge in graph[from])
                if (edge.Vertex2 == to)
                    return true;
            return false;
        }
        
        /// <summary>
        /// Returns the outdegree of the vertex
        /// </summary>
        virtual public int outdeg(int vertex)
        {
            return graph[vertex].Count;
        }


        abstract public void randomizeGraph();
        
        virtual public void addEdge(int from, int to, int weight = 1){
            graph[from].Add(new Edge(from, to, 1));
            graph[to].Add(new Edge(to, from, 1));
            nmbEdges++;
        }

        virtual public void deleteEdge(int from, int to)
        {
            int indexDel = 0;
            for(int i = 0; i < graph[from].Count; ++i)
                if(graph[from][i].Vertex2 == to)
                {
                    indexDel = i;
                    break;
                }
            graph[from].RemoveAt(indexDel);

            for(int j = 0; j < graph[to].Count; ++j)
                if(graph[to][j].Vertex2 == from)
                {
                    indexDel = j;
                    break;
                }
            graph[to].RemoveAt(indexDel);
            nmbEdges--;
        }

        virtual public void clear()
        {
            for (int i = 1; i <= nmbVertices; ++i)
                graph[i].Clear();
            nmbVertices = nmbEdges = 0;
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




        private void DFS_forCC(int st, ref List<int> where, ref int[] viz, ref int modif)
        {
            viz[st] = 1;
            modif++;
            where.Add(st);
            foreach (Edge edge in graph[st])
                if (viz[edge.Vertex2] == 0)
                    DFS_forCC(edge.Vertex2, ref where, ref viz, ref modif);
        }

        private void sortT(int vertex, ref List<int> where, ref int []viz)
        {
            viz[vertex] = 1;
            foreach (Edge val in graph[vertex])
                if (viz[val.Vertex2] == 0)
                    sortT(val.Vertex2, ref where, ref viz);
            where.Add(vertex);
        }
        
    }
}
