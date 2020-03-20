using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    abstract class Graph
    {
        public const int NMAX = 500;

        public int nmbVertices, nmbEdges;
        public List<int> []graph = new List<int>[NMAX];


        virtual public List<int>[] returnGraph() {
            return graph;
        }
        virtual public int[,] returnAdjiacentMatrix(){
            int[,] toReturn = new int[NMAX, NMAX];

            for(int i = 1; i <= nmbVertices; ++i)
            {
                foreach (int var in graph[i])
                {
                    toReturn[i, var] = 1;
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

            foreach(int elemFirst in Q)
            {
                toReturn.Add(elemFirst);
                Q.Dequeue();

                foreach(int v in graph[elemFirst])
                {
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
            foreach (int v in graph[st])
                if (viz[v] == 0)
                    DFS(v, ref where, ref viz);
        }

        /// <param name="startVertex">Vertex to start the DFS from.</param>
        virtual public List<int> DFSArray(int startVertex)
        {
            List<int> toReturn = new List<int>();
            int[] viz = new int[nmbVertices + 5];

            DFS(startVertex, ref toReturn, ref viz);

            return toReturn;
        }
        

        /// <param name="type">Type of sort: 0 - minimal, 1 - maximal</param>
        /// <param name = "startVertex">Vertex to start the topological sort</param>
        virtual public List<int> sortTop(int type, int startVertex)
        {
            List<int> toReturn = new List<int>();
            Queue<int> Q = new Queue<int>();
            int[] viz = new int[nmbVertices + 1];


            for (int i = 1; i <= nmbVertices; ++i)
                graph[i].Sort();
            for (int i = 1; i <= nmbVertices; ++i)
                if (viz[i] == 0)
                    sortT(startVertex, ref toReturn, ref viz, type);
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


        /// <summary>Returns a list of pairs {how many vertices in that component, list of vertices}</summary>
        virtual public List<Tuple<int, List<int>>> ConexComponents()
        {
            List<Tuple<int, List<int>>> toReturn = new List<Tuple<int, List<int>>>();
            int[] viz = new int[nmbVertices + 5];
            int nmbModif = 0;
            List<int> aux = new List<int>();

            for (int i = 1; i <= nmbVertices; ++i)
                if(viz[i] == 0)
                {
                    aux.Clear();
                    nmbModif = 0;
                    DFS_forCC(i, ref aux, ref viz, ref nmbModif);
                    toReturn.Add(Tuple.Create(nmbModif, aux));
                }
            return toReturn;
        }

        virtual public bool existsPath(int from, int to)
        {
            foreach (int val in graph[from])
                if (val == to)
                    return true;
            return false;
        }




        abstract public void randomizeGraph();
        
        /// <param name="from">'From' vertex</param>
        /// <param name="to">'To' vertex</param>
        virtual public void addEdge(int from, int to){
            graph[from].Add(to);
            graph[to].Add(from);

        }





       
        private void DFS_forCC(int st, ref List<int> where, ref int[] viz, ref int modif)
        {
            viz[st] = 1;
            modif++;
            where.Add(st);
            foreach (int v in graph[st])
                if (viz[v] == 0)
                    DFS_forCC(v, ref where, ref viz, ref modif);
        }

        private void sortT(int vertex, ref List<int> where, ref int []viz, int type)
        {
            viz[vertex] = 1;
            if (type == 0)
            {
                foreach (int val in graph[vertex])
                    if (viz[val] == 0)
                        sortT(val, ref where, ref viz, type);
            }
            else for (int i = graph[vertex].Count - 1; i >= 0; --i)
                    if (viz[graph[vertex][i]] == 0)
                        sortT(graph[vertex][i], ref where, ref viz, type);
            where.Add(vertex);
        }
    }
}
