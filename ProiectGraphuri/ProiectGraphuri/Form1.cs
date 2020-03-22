using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectGraphuri
{
    public partial class Form1 : Form
    {
        const int NMAX = 500;

        int n, m;
        
        List<int>[] gr = new List<int>[NMAX];

        private void Form1_Load(object sender, EventArgs e)
        {
            initAll();
        }


        private void initAll()
        {
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClass.Items.Add("Undirected Graph");
            cbClass.Items.Add("Directed Graph");
            cbClass.Items.Add("Weighted Undirected Graph");
            cbClass.Items.Add("Weighted Directed Graph");
            cbClass.Items.Add("Tree");
            cbClass.Items.Add("Trie");
            cbClass.Items.Add("Segment Tree");
            cbClass.Items.Add("Binary Search Tree");
            cbClass.Items.Add("Heap");

            cbFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            hideInfos();
        }
        
        void hideInfos()
        {
            labelInfos.Hide();
            labelInfo1.Hide();
            labelInfo2.Hide();
            labelInfo3.Hide();
            tbInfo1.Text = "";
            tbInfo2.Text = "";
            tbInfo3.Text = "";
            tbInfo1.Hide();
            tbInfo2.Hide();
            tbInfo3.Hide();

        }


        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideInfos();
            cbFunction.Items.Clear();
            functionAllGraph();
            switch(cbClass.Text.ToString())
            {
                case "Undirected Graph":
                    break;
                case "Directed Graph":
                    cbFunction.Items.Add("Indegree of");
                    cbFunction.Items.Add("Strongly Connected Components");
                    break;
                case "Weighted Undirected Graph":
                    functionWUG();
                    break;
                case "Weighted Directed Graph":
                    functionWDG();
                    break;
                default:
                    MessageBox.Show("Somterhing in Class went wrong!");
                    break;

            }
        }

        void functionAllGraph()
        {
            cbFunction.Items.Add("Adjiacent matrix");
            cbFunction.Items.Add("BFS Array");
            cbFunction.Items.Add("DFS Array");
            cbFunction.Items.Add("Topological Sort");
            cbFunction.Items.Add("Number of isolated vertices");
            cbFunction.Items.Add("Is Connected?");
            cbFunction.Items.Add("Exists Edge?");
            cbFunction.Items.Add("Connected Components");
            cbFunction.Items.Add("Outdegree of");
        }


        
        void functionWUG()
        {
            cbFunction.Items.Add("Roy-Floyd");
            cbFunction.Items.Add("Shortest Length Path from");
            cbFunction.Items.Add("Minimum Spanning Tree");
        }
        void functionWDG()
        {
            cbFunction.Items.Add("Indegree of");
            cbFunction.Items.Add("Strongly Connected Components");
            cbFunction.Items.Add("Roy-Floyd");
            cbFunction.Items.Add("Shortest Length Path from");
        }

        private void cbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideInfos();
            switch(cbFunction.Text.ToString())
            {
                case "BFS Array":
                    labelInfos.Show();
                    labelInfo1.Text = "Starting vertex: ";
                    labelInfo1.Show();
                    tbInfo1.Show();
                    break;
                case "DFS Array":
                    labelInfos.Show();
                    labelInfo1.Text = "Starting vertex: ";
                    labelInfo1.Show();
                    tbInfo1.Show();
                    break;
                case "Shortest Length Path from":
                    labelInfos.Show();
                    labelInfo1.Text = "Starting vertex: ";
                    labelInfo1.Show();
                    tbInfo1.Show();
                    break;
                case "Topological Sort":
                    labelInfos.Show();
                    labelInfo1.Text = "Starting vertex: ";
                    //labelInfo2.Text = "Type (0 - max, 1 - min):";
                    labelInfo1.Show();
                    //labelInfo2.Show();
                    tbInfo1.Show();
                    //tbInfo2.Show();
                    break;
                case "Exists Edge?":
                    labelInfos.Show();
                    labelInfo1.Text = "From: ";
                    labelInfo2.Text = "To: ";
                    labelInfo1.Show();
                    labelInfo2.Show();
                    tbInfo1.Show();
                    tbInfo2.Show();
                    break;
                case "Outdegree of":
                    labelInfos.Show();
                    labelInfo1.Text = ("Of: ");
                    labelInfo1.Show();
                    tbInfo1.Show();
                    break;
                case "Indegree of":
                    labelInfos.Show();
                    labelInfo1.Text = ("Of: ");
                    labelInfo1.Show();
                    tbInfo1.Show();
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!isOk())
                return;
            n = Convert.ToInt32(tbn.Text.ToString());
            m = Convert.ToInt32(tbm.Text.ToString());
            switch(cbClass.Text.ToString())
            {
                case "Undirected Graph":
                    solveUGfunctions();
                    break;
                case "Directed Graph":
                    solveDGfunctions();
                    break;
                case "Weighted Undirected Graph":
                    solveWUGfunctions();
                    break;
                case "Weighted Directed Graph":
                    solveWDGfunctions();
                    break;
                default:
                    MessageBox.Show("Class not implemented.");
                    break;
            }
            

        }

        void solveUGfunctions()
        {
            UndirectedGraph ug = new UndirectedGraph(n);
            string rez = "";
            string[] lines = tbMuchii.Lines;
            if(lines.Length != m)
            {
                MessageBox.Show("Please make sure you entered the correct number of edges! No additional lines needed.");
                return;
            }
            int nr1 = 0, nr2 = 0, seenSpaces = 0;
            foreach(string temp in lines)
            {
                nr1 = 0;
                nr2 = 0;
                seenSpaces = 0;
                int l = temp.Length;
                for(int i = 0; i < l; ++i)
                {
                    if (temp[i] >= '0' && temp[i] <= '9')
                    {
                        if (seenSpaces == 0)
                            nr1 = nr1 * 10 + (temp[i] - '0');
                        else nr2 = nr2 * 10 + (temp[i] - '0');
                    }
                    else if (temp[i] == ' ')
                    {
                        seenSpaces++;
                        if (seenSpaces > 1)
                        {
                            MessageBox.Show("Please don't input additional spaces.");
                            return;
                        }
                    }
                    else if(temp[i] != '\r' && temp[i] != '\n')
                    {
                        MessageBox.Show("Please input only accepted characters.");
                        return;
                    }
                }
                if (seenSpaces == 0)
                {
                    MessageBox.Show("Please note that every line of the input should be formed of 2 numbers.");
                    return;
                }
                else
                {
                    if(nr1 > n || nr2 > n || nr1 < 1 || nr2 < 1)
                    {
                        MessageBox.Show("All vertices must be between 1 and n.");
                        return;
                    }
                    ug.addEdge(nr1, nr2);
                }
            }

            switch(cbFunction.Text.ToString())
            {
                case "Adjiacent matrix":
                    int[,] ad = ug.returnAdjiacentMatrix();
                    for(int i = 1; i <= n; ++i)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + ad[i, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;

                case "BFS Array":
                    int sv = Convert.ToInt32(tbInfo1.Text.ToString());
                    if(sv > ug.NmbVertices || sv < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> bfs = ug.BFSArray(sv);
                    rez = stringFromList(bfs);
                    break;

                case "DFS Array":
                    int sv2 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv2 > ug.NmbVertices || sv2 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> dfs = ug.DFSArray(sv2);
                    rez = stringFromList(dfs);
                    break;
                case "Topological Sort":
                    int t1 = Convert.ToInt32(tbInfo1.Text.ToString());
                  //  int t2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (t1 > ug.NmbVertices || t1 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> top = ug.sortTop(t1);
                    rez = stringFromList(top);
                    break;
                case "Number of isolated vertices":
                    int nr = ug.numberOfIsolatedVertices();
                    rez = rez + nr;
                    break;
                case "Is Connected?":
                    bool con = ug.isConnected();
                    rez = rez + con;
                    break;
                case "Exists Edge?":
                    int tt1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    int tt2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (tt1 > ug.NmbVertices || tt1 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    if (tt2 > ug.NmbVertices || tt2 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    bool ex = ug.existsEdge(tt1, tt2);
                    rez = rez + ex;
                    break;
                case "Connected Components":
                    List<Tuple<int, List<int>>> list = ug.ConectedComponents();
                    foreach (var cc in list)
                    {
                        rez = rez + cc.Item1 + ": ";
                        foreach (int i in cc.Item2)
                            rez = rez + i + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Outdegree of":
                    int of = Convert.ToInt32(tbInfo1.Text.ToString());
                    int deg = ug.outdeg(of);
                    rez = rez + deg;
                    break;
                default:
                    MessageBox.Show("Could not identify the function.");
                    break;
            }
            tbRez.Text = rez;
        }
        void solveDGfunctions()
        {

            DirectedGraph dg = new DirectedGraph(n);
            string rez = "";
            string[] lines = tbMuchii.Lines;
            if (lines.Length != m)
            {
                MessageBox.Show("Please make sure you entered the correct number of edges! No additional lines needed.");
                return;
            }
            int nr1 = 0, nr2 = 0, seenSpaces = 0;
            foreach (string temp in lines)
            {
                nr1 = 0;
                nr2 = 0;
                seenSpaces = 0;
                int l = temp.Length;
                for (int i = 0; i < l; ++i)
                {
                    if (temp[i] >= '0' && temp[i] <= '9')
                    {
                        if (seenSpaces == 0)
                            nr1 = nr1 * 10 + (temp[i] - '0');
                        else nr2 = nr2 * 10 + (temp[i] - '0');
                    }
                    else if (temp[i] == ' ')
                    {
                        seenSpaces++;
                        if (seenSpaces > 1)
                        {
                            MessageBox.Show("Please don't input additional spaces.");
                            return;
                        }
                    }
                    else if(temp[i] != '\r' && temp[i] != '\n')
                    {
                        MessageBox.Show("Please only input accepted characters.");
                        return;
                    }
                }
                if (seenSpaces == 0)
                {
                    MessageBox.Show("Please note that every line of the input should be formed of 2 numbers.");
                    return;
                }
                else
                {
                    if (nr1 > n || nr2 > n || nr1 < 1 || nr2 < 1)
                    {
                        MessageBox.Show("All vertices must be between 1 and n.");
                        return;
                    }
                    dg.addEdge(nr1, nr2);
                }
            }

            switch (cbFunction.Text.ToString())
            {
                case "Adjiacent matrix":
                    int[,] ad = dg.returnAdjiacentMatrix();
                    for (int i = 1; i <= n; ++i)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + ad[i, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;

                case "BFS Array":
                    int sv = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv > dg.NmbVertices || sv < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> bfs = dg.BFSArray(sv);
                    rez = stringFromList(bfs);
                    break;

                case "DFS Array":
                    int sv2 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv2 > dg.NmbVertices || sv2 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> dfs = dg.DFSArray(sv2);
                    rez = stringFromList(dfs);
                    break;
                case "Topological Sort":
                    int t1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (t1 > dg.NmbVertices || t1 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    
                    List<int> top = dg.sortTop(t1);
                    rez = stringFromList(top);
                    break;
                case "Number of isolated vertices":
                    int nr = dg.numberOfIsolatedVertices();
                    rez = rez + nr;
                    break;
                case "Is Connected?":
                    bool con = dg.isConnected();
                    rez = rez + con;
                    break;
                case "Exists Edge?":
                    int tt1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    int tt2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (tt1 > dg.NmbVertices || tt1 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    if (tt2 > dg.NmbVertices || tt2 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    bool ex = dg.existsEdge(tt1, tt2);
                    rez = rez + ex;
                    break;
                case "Connected Components":
                    List<Tuple<int, List<int>>> list = dg.ConectedComponents();
                    foreach (var cc in list)
                    {
                        rez = rez + cc.Item1 + ": ";
                        foreach (int i in cc.Item2)
                            rez = rez + i + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Strongly Connected Components":
                    List<Tuple<int, List<int>>> list2 = dg.StronglyConnectedComponents();
                    foreach (var cc in list2)
                    {
                        rez = rez + cc.Item1 + ": ";
                        foreach (int i in cc.Item2)
                            rez = rez + i + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Outdegree of":
                    int of = Convert.ToInt32(tbInfo1.Text.ToString());
                    int deg = dg.outdeg(of);
                    rez = rez + deg;
                    break;
                case "Indegree of":
                    int off = Convert.ToInt32(tbInfo1.Text.ToString());
                    int indeg = dg.indeg(off);
                    rez = rez + indeg;
                    break;
                default:
                    MessageBox.Show("Could not identify the function.");
                    break;
            }
            tbRez.Text = rez;
        }
        void solveWUGfunctions()
        {
            UndirectedWeightedGraph uwg = new UndirectedWeightedGraph(n);
            string rez = "";
            string[] lines = tbMuchii.Lines;
            if (lines.Length != m)
            {
                MessageBox.Show("Please make sure you entered the correct number of edges! No additional lines needed.");
                return;
            }
            int nr1 = 0, nr2 = 0, nr3 = 0, seenSpaces = 0, p = 1;
            foreach (string temp in lines)
            {
                nr1 = 0;
                nr2 = 0;
                nr3 = 0;
                p = 1;
                seenSpaces = 0;
                int l = temp.Length;
                for (int i = 0; i < l; ++i)
                {
                    if (temp[i] >= '0' && temp[i] <= '9')
                    {
                        if (seenSpaces == 0)
                            nr1 = nr1 * 10 + (temp[i] - '0');
                        else if (seenSpaces == 1) nr2 = nr2 * 10 + (temp[i] - '0');
                        else nr3 = nr3 * 10 + (temp[i] - '0');
                    }
                    else if (temp[i] == '-')
                    {
                        if(seenSpaces != 2)
                        {
                            MessageBox.Show("All vertices must be between 1 and n.");
                            return;
                        }
                        else p = -1;
                    }
                    else if (temp[i] == ' ')
                    {
                        seenSpaces++;
                        if (seenSpaces > 2)
                        {
                            MessageBox.Show("Please don't input additional spaces.");
                            return;
                        }
                    }
                    else if (temp[i] != '\r' && temp[i] != '\n')
                    {
                        MessageBox.Show("Please only input accepted characters.");
                        return;
                    }
                }
                if (seenSpaces < 2)
                {
                    MessageBox.Show("Please note that every line of the input should be formed of 3 numbers.");
                    return;
                }
                else
                {
                    if (nr1 > n || nr2 > n|| nr1 < 1 || nr2 < 1)
                    {
                        MessageBox.Show("All vertices must be between 1 and n.");
                        return;
                    }
                    uwg.addEdge(nr1, nr2, nr3*p);
                }
            }

            switch (cbFunction.Text.ToString())
            {
                case "Adjiacent matrix":
                    int[,] ad = uwg.returnAdjiacentMatrix();
                    for (int i = 1; i <= n; ++i)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + ad[i, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;

                case "BFS Array":
                    int sv = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv > uwg.NmbVertices || sv < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> bfs = uwg.BFSArray(sv);
                    rez = stringFromList(bfs);
                    break;

                case "DFS Array":
                    int sv2 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv2 > uwg.NmbVertices || sv2 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> dfs = uwg.DFSArray(sv2);
                    rez = stringFromList(dfs);
                    break;
                case "Topological Sort":
                    int t1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (t1 > uwg.NmbVertices || t1 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    
                    List<int> top = uwg.sortTop(t1);
                    rez = stringFromList(top);
                    break;
                case "Number of isolated vertices":
                    int nr = uwg.numberOfIsolatedVertices();
                    rez = rez + nr;
                    break;
                case "Is Connected?":
                    bool con = uwg.isConnected();
                    rez = rez + con;
                    break;
                case "Exists Edge?":
                    int tt1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    int tt2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (tt1 > uwg.NmbVertices || tt1 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    if (tt2 > uwg.NmbVertices || tt2 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    bool ex = uwg.existsEdge(tt1, tt2);
                    rez = rez + ex;
                    break;
                case "Connected Components":
                    List<Tuple<int, List<int>>> list = uwg.ConectedComponents();
                    foreach (var cc in list)
                    {
                        rez = rez + cc.Item1 + ": ";
                        foreach (int i in cc.Item2)
                            rez = rez + i + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Roy-Floyd":
                    int[,] rf = uwg.shortestLengthPaths();
                    for (int i = 1; i <= n; ++i)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + rf[i, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Shortest Length Path from":
                    int from = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (from > uwg.NmbVertices || from < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    int[] bellman = uwg.shortestLengthPaths(from);
                    for (int i = 1; i <= n; ++i)
                        rez = rez + bellman[i] + " ";
                    break;
                case "Minimum Spanning Tree":
                    Tuple<int, UndirectedWeightedGraph> msp = uwg.minimumSpanningTree();
                    rez = rez + msp.Item1 + "\r\n" + msp.Item2.NmbVertices + " " + msp.Item2.NmbEdges + "\r\n";
                    for(int i = 1; i <= msp.Item2.NmbVertices; ++i)
                    {
                        rez = rez + i + ": ";
                        foreach (Graph.Edge edge in msp.Item2.Graph[i])
                            rez = rez + "(" + edge.Vertex2 + ", " + edge.Weight + ") ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Outdegree of":
                    int of = Convert.ToInt32(tbInfo1.Text.ToString());
                    int deg = uwg.outdeg(of);
                    rez = rez + deg;
                    break;
                default:
                    MessageBox.Show("Could not identify the function.");
                    break;
            }
            tbRez.Text = rez;
        }
        void solveWDGfunctions()
        {
            DirectedWeightedGraph dwg = new DirectedWeightedGraph(n);
            string rez = "";
            string[] lines = tbMuchii.Lines;
            if (lines.Length != m)
            {
                MessageBox.Show("Please make sure you entered the correct number of edges! No additional lines needed.");
                return;
            }
            int nr1 = 0, nr2 = 0, nr3 = 0, seenSpaces = 0, p = 1;
            foreach (string temp in lines)
            {
                nr1 = 0;
                nr2 = 0;
                nr3 = 0;
                p = 1;
                seenSpaces = 0;
                int l = temp.Length;
                for (int i = 0; i < l; ++i)
                {
                    if (temp[i] >= '0' && temp[i] <= '9')
                    {
                        if (seenSpaces == 0)
                            nr1 = nr1 * 10 + (temp[i] - '0');
                        else if (seenSpaces == 1) nr2 = nr2 * 10 + (temp[i] - '0');
                        else nr3 = nr3 * 10 + (temp[i] - '0');
                    }
                    else if (temp[i] == '-')
                    {
                        if (seenSpaces != 2)
                        {
                            MessageBox.Show("All vertices must be between 1 and n.");
                            return;
                        }
                        else p = -1;
                    }
                    else if (temp[i] == ' ')
                    {
                        seenSpaces++;
                        if (seenSpaces > 2)
                        {
                            MessageBox.Show("Please don't input additional spaces.");
                            return;
                        }
                    }
                    else if (temp[i] != '\r' && temp[i] != '\n')
                    {
                        MessageBox.Show("Please only input accepted characters.");
                        return;
                    }
                }
                if (seenSpaces < 2)
                {
                    MessageBox.Show("Please note that every line of the input should be formed of 3 numbers.");
                    return;
                }
                else
                {
                    if (nr1 > n || nr2 > n || nr1 < 1 || nr2 < 1)
                    {
                        MessageBox.Show("All vertices must be between 1 and n.");
                        return;
                    }
                    dwg.addEdge(nr1, nr2, nr3 * p);
                }
            }

            switch (cbFunction.Text.ToString())
            {
                case "Adjiacent matrix":
                    int[,] ad = dwg.returnAdjiacentMatrix();
                    for (int i = 1; i <= n; ++i)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + ad[i, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;

                case "BFS Array":
                    int sv = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv > dwg.NmbVertices || sv < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> bfs = dwg.BFSArray(sv);
                    rez = stringFromList(bfs);
                    break;

                case "DFS Array":
                    int sv2 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv2 > dwg.NmbVertices || sv2 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> dfs = dwg.DFSArray(sv2);
                    rez = stringFromList(dfs);
                    break;
                case "Topological Sort":
                    int t1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (t1 > dwg.NmbVertices || t1 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    
                    List<int> top = dwg.sortTop(t1);
                    rez = stringFromList(top);
                    break;
                case "Number of isolated vertices":
                    int nr = dwg.numberOfIsolatedVertices();
                    rez = rez + nr;
                    break;
                case "Is Connected?":
                    bool con = dwg.isConnected();
                    rez = rez + con;
                    break;
                case "Exists Edge?":
                    int tt1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    int tt2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (tt1 > dwg.NmbVertices || tt1 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    if (tt2 > dwg.NmbVertices || tt2 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    bool ex = dwg.existsEdge(tt1, tt2);
                    rez = rez + ex;
                    break;
                case "Connected Components":
                    List<Tuple<int, List<int>>> list = dwg.ConectedComponents();
                    foreach (var cc in list)
                    {
                        rez = rez + cc.Item1 + ": ";
                        foreach (int i in cc.Item2)
                            rez = rez + i + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Strongly Connected Components":
                    List<Tuple<int, List<int>>> list2 = dwg.StronglyConnectedComponents();
                    foreach (var cc in list2)
                    {
                        rez = rez + cc.Item1 + ": ";
                        foreach (int i in cc.Item2)
                            rez = rez + i + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Roy-Floyd":
                    int[,] rf = dwg.shortestLengthPaths();
                    for (int i = 1; i <= n; ++i)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + rf[i, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "Shortest Length Path from":
                    int from = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (from > dwg.NmbVertices || from < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    int[] bellman = dwg.shortestLengthPaths(from);
                    for (int i = 1; i <= n; ++i)
                        rez = rez + bellman[i] + " ";
                    break;
                case "Outdegree of":
                    int of = Convert.ToInt32(tbInfo1.Text.ToString());
                    int deg = dwg.outdeg(of);
                    rez = rez + deg;
                    break;
                case "Indegree of":
                    int off = Convert.ToInt32(tbInfo1.Text.ToString());
                    int indeg = dwg.indeg(off);
                    rez = rez + indeg;
                    break;
                default:
                    MessageBox.Show("Could not identify the function.");
                    break;
            }
            tbRez.Text = rez;
        }


        string stringFromList(List<int> list)
        {
            string rez = "";
            foreach (var el in list)
                rez = rez + el + " ";
            return rez;
        }


        bool isOk()
        {
            string n = tbn.Text.ToString();
            string m = tbm.Text.ToString();
            string edges = tbMuchii.Text.ToString();
            string clas = cbClass.Text.ToString();
            string fct = cbFunction.Text.ToString();

            if (!digits(n) || !digits(m))
                return false;
            if(clas.Equals("") || fct.Equals(""))
            {
                MessageBox.Show("Please select a Class & Function!");
                return false;
            }
            if (tbInfo1.Visible == true)
            {
                if (!digits(tbInfo1.Text.ToString()))
                    return false;
                int val = Convert.ToInt32(tbInfo1.Text.ToString());
                if (val > Convert.ToInt32(n) || val < 1)
                {
                    MessageBox.Show("Integers in additional boxes should be between 1 and n.");
                    return false;
                }
            }
            if (tbInfo2.Visible == true)
            {
                if (!digits(tbInfo2.Text.ToString()))
                    return false;

                int val = Convert.ToInt32(tbInfo2.Text.ToString());
                if (val > Convert.ToInt32(n) || val < 1)
                {
                    MessageBox.Show("Integers in additional boxes should be between 1 and n.");
                    return false;
                }
            }
            if (tbInfo3.Visible == true)
            {
                if (!digits(tbInfo3.Text.ToString()))
                    return false;

                int val = Convert.ToInt32(tbInfo3.Text.ToString());
                if (val > Convert.ToInt32(n) || val < 1)
                {
                    MessageBox.Show("Integers in additional boxes should be between 1 and n.");
                    return false;
                }
            }

            return true;
        }

        bool digits(string s)
        {
            if (s.Equals(""))
            {
                MessageBox.Show("Please complete all text boxes!");
                return false;
            }
            try
            {
                int nr = Convert.ToInt32(s);
                return true;
            }
            catch
            {
                MessageBox.Show("Please input only accepted characters!");
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            
        }
    }
}
