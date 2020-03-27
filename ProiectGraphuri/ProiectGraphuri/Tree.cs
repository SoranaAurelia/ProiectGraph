using System;
using System.Collections.Generic;
using System.Linq;

namespace ProiectGraphuri
{
    class Tree : Graph
    {
        int r;
        int[] tati = new int[NMAX];
        List<Tuple<int, int>> edges;
        /// <summary>
        /// Constructor of the graph
        /// </summary>
        /// <param name="n"> Number of vertices</param>
        /// <param name="rad"> The number of the root</param>
        /// <param name="Leg"> A list with {parent, child}</param>

        public Tree(int n, int rad, List<Tuple<int, int>> Leg)
        {
            graph = new List<Edge>[NMAX];
            for (int i = 0; i <= n; i++)
                graph[i] = new List<Edge>();
            nmbVertices = n;
            r = rad;
            foreach (var i in Leg)
            {
                graph[i.Item1].Add(new Edge(i.Item1, i.Item2, 1));
                graph[i.Item2].Add(new Edge(i.Item2, i.Item1, 1));
            }
            formVectTati();

        }

        public Tree()
        {
            nmbVertices = 0;
            nmbEdges = 0;
        }
        void formVectTati()
        {
            int[] viz = new int[NMAX];
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(r);
            viz[r] = 1;

            while (Q.Any())
            {
                int el = Q.First();
                Q.Dequeue();
                foreach (var i in graph[el])
                {

                    if (viz[i.Vertex2] == 0)
                    {
                        tati[i.Vertex2] = el;
                        Q.Enqueue(i.Vertex2);
                        viz[i.Vertex2] = 1;
                    }
                }
            }
        }
        /// <summary>
        /// Returns int[] with dads
        /// </summary>
        /// <returns></returns>
        public int[] dads()
        {
            return tati;
        }

        /// <summary>
        /// Returns the dad of the node
        /// </summary>
        /// <param name="nod">the node for which we want to know the dad</param>
        /// <returns></returns>
        public int DadOf(int nod)
        {
            return tati[nod];
        }
        public int Diameter()
        {
            Tuple<int, List<int>> f = FarthestNodes(r);
            f = FarthestNodes(f.Item2[0]);
            return f.Item1;
        }
        /// <summary>
        /// Return the farthest distance from a node, as well as the nodes (in number of nodes)
        /// </summary>
        /// <param name="vfStart"> the vertex from which we want the distance</param>
        /// <returns></returns>
        public Tuple<int, List<int>> FarthestNodes(int vfStart)
        {
            int[] viz = new int[NMAX];

            int vmax = 0;
            List<int> toReturn = new List<int>();
            Queue<Tuple<int, int>> Q = new Queue<Tuple<int, int>>();

            Q.Enqueue(Tuple.Create(vfStart, 1));
            viz[vfStart] = 1;


            while (Q.Any())
            {
                var i = Q.First();
                foreach (var v in graph[i.Item1])
                {
                    if (viz[v.Vertex2] == 0)
                    {
                        if (i.Item2 + 1 > vmax)
                        {
                            vmax = i.Item2 + 1;
                            toReturn.Clear();
                            toReturn.Add(v.Vertex2);
                        }
                        else if (i.Item2 + 1 == vmax)
                        {
                            toReturn.Add(v.Vertex2);
                        }
                        viz[v.Vertex2] = 1;
                        Q.Enqueue(Tuple.Create(v.Vertex2, i.Item2 + 1));
                    }

                }
                Q.Dequeue();
            }



            return Tuple.Create(vmax, toReturn);
        }
        public override void randomizeGraph()
        {

        }

        private List<int> getKids(int i)
        {
            List<int> toReturn = new List<int>();
            for (int j = 0; j < edges.Count(); j++)
            {
                if (edges[i].Item1 == i)
                    toReturn.Add(edges[i].Item2);
            }
            return toReturn;
        }


    }
}