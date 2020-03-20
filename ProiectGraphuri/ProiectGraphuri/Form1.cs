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
        string clasa, functie;
        string muchii;
        List<int>[] gr = new List<int>[NMAX];

        private void button1_Click(object sender, EventArgs e)
        {

            n = Convert.ToInt32(tbn.Text.ToString());
            m = Convert.ToInt32(tbm.Text.ToString());
            clasa = tbClasa.Text.ToString();
            if(clasa.Equals("UndirectedGraph"))
            {
                UndirectedGraph ug = new UndirectedGraph(n);
                ug.NmbEdges = m;

                muchii = tbMuchii.Text.ToString();

                int l = muchii.Count(), nr1 = 0, nr2 = 0;
                bool seenSpace = false;

                for (int i = 0; i < l; ++i)
                {
                    if (muchii[i] >= '0' && muchii[i] <= '9')
                    {
                        if (!seenSpace)
                            nr1 = nr1 * 10 + (muchii[i] - '0');
                        else nr2 = nr2 * 10 + (muchii[i] - '0');
                    }
                    else if (muchii[i] == ' ')
                        seenSpace = true;
                    else if (muchii[i] == '\r')
                    {
                        ug.addEdge(nr1, nr2);
                        seenSpace = false;
                        nr1 = 0;
                        nr2 = 0;
                    }
                }

                string rez = "";
                List<Tuple<int, List<int>>> list = ug.ConexComponents();
                foreach (var cc in list)
                {
                    rez = rez + cc.Item1 + ": ";
                    foreach (int i in cc.Item2)
                        rez = rez + i + " ";
                    rez = rez + "\r\n";
                }
                /*
                int[,] edges = ug.returnAdjiacentMatrix();
                for(int i = 1; i <= ug.NmbVertices; ++i)
                {
                    for (int j = 1; j <= ug.nmbVertices; ++j)
                        rez = rez + edges[i, j] + " ";
                    rez = rez + "\r\n";
                }*/
                tbRez.Text = rez;
            }
            

            
            
        }

        public Form1()
        {
            InitializeComponent();
            
        }
    }
}
