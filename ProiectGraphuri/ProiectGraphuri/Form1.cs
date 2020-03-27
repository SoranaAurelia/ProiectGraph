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
            showFunctions();
            cbFunction.Items.Clear();

            tbn.ReadOnly = false;
            tbm.ReadOnly = false;

            switch (cbClass.Text.ToString())
            {
                case "Undirected Graph":
                    functionAllGraph();
                    break;
                case "Directed Graph":
                    functionAllGraph();
                    cbFunction.Items.Add("Indegree of");
                    cbFunction.Items.Add("Strongly Connected Components");
                    break;
                case "Weighted Undirected Graph":
                    functionAllGraph();
                    functionWUG();
                    break;
                case "Weighted Directed Graph":
                    functionAllGraph();
                    functionWDG();
                    break;
                case "Tree":
                    functionTrees();
                    functionTree();
                    break;
                case "Trie":
                    hideFunctions();
                    tbn.ReadOnly = true;
                    tbm.ReadOnly = true;
                    break;
                case "Binary Search Tree":
                    hideFunctions();
                    tbn.ReadOnly = true;
                    tbm.ReadOnly = true;
                    break;
                case "Segment Tree":
                    hideFunctions();
                    tbn.ReadOnly = true;
                    tbm.ReadOnly = true;
                    break;
                default:
                    MessageBox.Show("Something in Class went wrong!");
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

        void functionTrees()
        {
            cbFunction.Items.Add("Adjiacent matrix");
            cbFunction.Items.Add("BFS Array");
            cbFunction.Items.Add("DFS Array");
            cbFunction.Items.Add("Topological Sort");
            cbFunction.Items.Add("Exists Edge?");
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
        void functionTree()
        {
            cbFunction.Items.Add("Parent vector");
            cbFunction.Items.Add("Parent of");
            cbFunction.Items.Add("Diameter");
            cbFunction.Items.Add("Farthest node from");
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
                case "Parent of":
                    labelInfos.Show();
                    labelInfo1.Text = "Of: ";
                    labelInfo1.Show();
                    tbInfo1.Show();
                    break;
                case "Farthest node from":
                    labelInfos.Show();
                    labelInfo1.Text = "From: ";
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
            if (!cbClass.Text.Equals("Trie") && !cbClass.Text.Equals("Binary Search Tree") && !cbClass.Text.Equals("Segment Tree"))
            {
                n = Convert.ToInt32(tbn.Text.ToString());
                m = Convert.ToInt32(tbm.Text.ToString());
            }
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
                case "Tree":
                    solveTreefunctions();
                    break;
                case "Trie":
                    solveTrieFunctions();
                    break;
                case "Binary Search Tree":
                    solveBSTFunctions();
                    break;
                case "Segment Tree":
                    solveSegTreeFunctions();
                    break;
                default:
                    MessageBox.Show("Class not implemented.");
                    break;
            }
            

        }


        
        void hideFunctions()
        {
            labelAlgorithm.Hide();
            cbFunction.Hide();
        }
        void showFunctions()
        {
            labelAlgorithm.Show();
            cbFunction.Show();
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
        void solveTreefunctions()
        {

            n = Convert.ToInt32(tbn.Text);
            m = n - 1;
            List<Tuple<int, int>> constr = new List<Tuple<int, int>>();
            List<string> val = new List<string>();
            string[] tempArray = tbMuchii.Lines;
            int i = 0;
            
            i = 1;
            for (i = 0; i < m; i++)
            {
                int j = 0;
                int val1 = createNumb(ref j, tempArray[i], tempArray[i].Length);
                if (val1 == -1)
                    return;
                j++;
                int val2 = createNumb(ref j, tempArray[i], tempArray[i].Length);
                if (val2 == -1)
                    return;
                constr.Add(Tuple.Create(val1, val2));
            }
            i = 0;
            int r = createNumb(ref i, tempArray[m], tempArray[m].Length);
            Tree t = new Tree(n, r, constr);
            string rez = "";

            switch(cbFunction.Text.ToString())
            {
                case "Diameter":
                    rez = t.Diameter() + "";
                    break;
                case "Parent of":
                    int t2 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (t2 > t.NmbVertices || t2 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    rez = t.DadOf(t2) + "";
                    break;
                case "Parent vector":
                    int[] dads = t.dads();
                    for (int j = 1; j <= n; j++)
                        rez = rez + dads[j] + " ";
                    break;
                case "Adjiacent matrix":
                    int[,] ad = t.returnAdjiacentMatrix();
                    for (int ii = 1; ii <= n; ++ii)
                    {
                        for (int j = 1; j <= n; ++j)
                            rez = rez + ad[ii, j] + " ";
                        rez = rez + "\r\n";
                    }
                    break;
                case "BFS Array":
                    int sv = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv > t.NmbVertices || sv < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> bfs = t.BFSArray(sv);
                    rez = stringFromList(bfs);
                    break;

                case "DFS Array":
                    int sv2 = Convert.ToInt32(tbInfo1.Text.ToString());
                    if (sv2 > t.NmbVertices || sv2 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> dfs = t.DFSArray(sv2);
                    rez = stringFromList(dfs);
                    break;
                case "Topological Sort":
                    int t1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    //  int t2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (t1 > t.NmbVertices || t1 < 1) { MessageBox.Show("Starting vertex must be from 1 to n."); return; }
                    List<int> top = t.sortTop(t1);
                    rez = stringFromList(top);
                    break;
                case "Exists Edge?":
                    int tt1 = Convert.ToInt32(tbInfo1.Text.ToString());
                    int tt2 = Convert.ToInt32(tbInfo2.Text.ToString());
                    if (tt1 > t.NmbVertices || tt1 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    if (tt2 > t.NmbVertices || tt2 < 1) { MessageBox.Show("Vertex must be from 1 to n."); return; }
                    bool ex = t.existsEdge(tt1, tt2);
                    rez = rez + ex;
                    break;
                case "Outdegree of":
                    int of = Convert.ToInt32(tbInfo1.Text.ToString());
                    int deg = t.outdeg(of);
                    rez = rez + deg;
                    break;
                case "Farthest node from":
                    int from = Convert.ToInt32(tbInfo1.Text.ToString());
                    Tuple<int, List<int>> tup = t.FarthestNodes(from);
                    rez = rez + tup.Item1 + "\r\n";
                    foreach (int vvv in tup.Item2)
                        rez = rez + vvv + " ";
                    break;
                default:
                    MessageBox.Show("Could not identify function!");
                    return;

            }
            tbRez.Text = rez;
            
        }
        void solveTrieFunctions()
        {
            Trie t = new Trie();
            tbRez.Text = "";
            //int nmbOfOperations = Convert.ToInt32(tbn.Text);
            string[] tempArray = tbMuchii.Lines;
            int m = tempArray.Length;
            for (int i = 0; i < m; i++)
            {
                string line = tempArray[i];
                string[] split = line.Split(new Char[] { ' ', ',' });
                if (split[0].Equals("add"))
                    t = t + split[1];
                else if (split[0].Equals("delete"))
                    t = t - split[1];
                else if (split[0].Equals("NOfApp"))
                    tbRez.Text = tbRez.Text + t.numberOfAppearances(split[1]) + "\r\n";
                else if (split[0].Equals("R"))
                {
                    int k = Convert.ToInt32(split[1]);
                    int[] toSend = new int[k];
                    for (int j = 0; j < k; j++)
                        toSend[j] = Convert.ToInt32(split[j + 2]);
                    tbRez.Text = tbRez.Text + t.LongestPrefixOfAListOfWords(k, toSend) + "\r\n";
                }
                else if (split[0].Equals("LP"))
                {
                    tbRez.Text = tbRez.Text + t.longestPrefix(split[1]) + "\r\n";
                }
                else
                {
                    MessageBox.Show("Could not identify function at line " + (i + 1));
                    return;
                }
            }
        }
        void solveBSTFunctions()
        {
            BinarySearchTree t = new BinarySearchTree();
            tbRez.Text = "";
            //int nmbOfOperations = Convert.ToInt32(tbn.Text);
            string[] tempArray = tbMuchii.Lines;
            int m = tempArray.Length;
            for (int i = 0; i < m; i++)
            {
                string line = tempArray[i];
                string[] split = line.Split(new Char[] { ' ', ',' });
                if (split[0].Equals("add"))
                    t.addNode(split[1][0]);
                else if (split[0].Equals("delete"))
                    t.delete(split[1][0]);
                else if (split[0].Equals("min"))
                    tbRez.Text = tbRez.Text + t.minimumElement() + "\r\n";
                else if (split[0].Equals("max"))
                    tbRez.Text = tbRez.Text + t.maximumElement() + "\r\n";
                else if (split[0].Equals("search"))
                    tbRez.Text = tbRez.Text + t.find(split[1][0]) + "\r\n";
                else if (split[0].Equals("preorder"))
                {
                    char[] ajut = t.preorder();
                    for (int j = 0; j < t.nmbVertices; j++)
                        tbRez.Text = tbRez.Text + ajut[j] + " ";
                    tbRez.Text = tbRez.Text + "\r\n";
                }
                else if (split[0].Equals("postorder"))
                {
                    char[] ajut = t.postorder();
                    for (int j = 0; j < t.nmbVertices; j++)
                        tbRez.Text = tbRez.Text + ajut[j] + " ";
                    tbRez.Text = tbRez.Text + "\r\n";
                }
                else if (split[0].Equals("inorder"))
                {
                    char[] ajut = t.inorder();
                    for (int j = 0; j < t.nmbVertices; j++)
                        tbRez.Text = tbRez.Text + ajut[j] + " ";
                    tbRez.Text = tbRez.Text + "\r\n";
                }
                else if (split[0].Equals("root"))
                {
                    tbRez.Text = tbRez.Text + t.Root() + "\r\n";
                }
                else
                {
                    MessageBox.Show("Could not identify function at line " + (i+1));
                    return;
                }
            }
        }
        void solveSegTreeFunctions()
        {
            SegmentTree t = new SegmentTree();
            tbRez.Text = "";
            //int nmbOfOperations = Convert.ToInt32(tbn.Text);
            string[] tempArray = tbMuchii.Lines;
            int m = tempArray.Length;
            int[] arr = new int[NMAX];
            string line1st = tempArray[0];
            string[] sp = line1st.Split(new Char[] { ' ', ',' });
            int el = sp.Count();
            for (int i = 1; i <= el; i++)
            {
                arr[i] = Convert.ToInt32(sp[i - 1]);
            }
            if(!tempArray[1].Equals("+") && !tempArray[1].Equals("-") && !tempArray[1].Equals("min") && !tempArray[1].Equals("max"))
            {
                MessageBox.Show("Could not identify operation.");
                return;
            }
            t.assign(el, arr, tempArray[1]);
            for (int i = 2; i < m; i++)
            {
                string line = tempArray[i];
                string[] split = line.Split(new Char[] { ' ', ',' });
                if (!digits(split[1]) || !digits(split[2]))
                    return;
                if (split[0].Equals("modify"))
                {
                    int s1 = Convert.ToInt32(split[1]);
                    if (s1> t.NmbVertices || s1 < 1)
                    {
                        MessageBox.Show("Position should be between 1 and n!");
                        return;
                    }
                    t.change(Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                }
                else if (split[0].Equals("value"))
                {
                    int s1 = Convert.ToInt32(split[1]), s2 = Convert.ToInt32(split[2]);
                    if (s1 > t.NmbVertices || s2 > t.NmbVertices || s1 < 1 || s2 < 1)
                    {
                        MessageBox.Show("Position should be between 1 and n!");
                        return;
                    }
                    tbRez.Text = tbRez.Text + t.returnValueForInterval(Convert.ToInt32(split[1]), Convert.ToInt32(split[2])) + "\r\n";
                }
                else
                {
                    MessageBox.Show("Could not identify function!");
                    return;
                }
            }
        }

        private int createNumb(ref int i, string s, int n)
        {
            int nr = 0;
            while (i < n && s[i] >= '0' && s[i] <= '9')
            {
                nr = nr * 10 + (s[i] - '0');
                i++;
            }
            if(i < n && s[i] != ' ')
            {
                MessageBox.Show("Invalid inputs.");
                return -1;
            }
            return nr;
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

            if (clas.Equals("Trie") || clas.Equals("Binary Search Tree") || clas.Equals("Segment Tree"))
                return true;

            if (!digits(n) || !digits(m))
                return false;
            if(Convert.ToInt32(n) < 1 || Convert.ToInt32(m) < 1)
            {
                MessageBox.Show("Number of vertices/edges should be positive!");
                return false;
            }
            if((clas.Equals("") || fct.Equals("")))
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
