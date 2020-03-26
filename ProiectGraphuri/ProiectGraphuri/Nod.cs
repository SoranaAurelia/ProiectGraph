using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class Nod
    {
        int nrcnt;
        int fin;
        public Nod[] copii;

        public int Nrcnt
        {
            get { return nrcnt; }
            set { nrcnt = value; }
        }
        public int Fin
        {
            get { return fin; }
            set { fin = value; }
        }

        public Nod()
        {
            nrcnt = 0;
            fin = 0;
            copii = new Nod[30];

        }
    }
}