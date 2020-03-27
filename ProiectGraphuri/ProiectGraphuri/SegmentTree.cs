using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class SegmentTree : BinaryTree
    {
        private int[] a = new int[4 * NMAX];
        string op;
        public SegmentTree()
        {

        }
        /// <param name="n"> the number of elements in arr </param>
        /// <param name="arr"> sirul </param>
        /// <param name="op"> operatia necesara (+, -, min, max)</param>
        public SegmentTree(int n, int[] arr, string ope)
        {
            op = ope;
            adaug(1, n, 1, arr);
            nmbVertices = n;
        }
        public override void addNode(char inf)
        {
            throw new NotImplementedException();
        }

        public void assign(int n, int[] arr, string ope)
        {
            op = ope;
            adaug(1, n, 1, arr);
            nmbVertices = n;
        }
        private void adaug(int st, int dr, int poz, int[] arr)
        {
            if (st == dr)
            {
                a[poz] = arr[st];
                return;
            }
            int mij = (st + dr) / 2;
            adaug(st, mij, poz * 2, arr);
            adaug(mij + 1, dr, poz * 2 + 1, arr);

            switch (op)
            {
                case "+":
                    a[poz] = a[poz * 2] + a[poz * 2 + 1];
                    break;
                case "*":
                    a[poz] = a[poz * 2] * a[poz * 2 + 1];
                    break;
                case "min":
                    if (2 * poz + 1 > NmbVertices)
                        a[poz] = a[poz * 2];
                    else 
                        a[poz] = Math.Min(a[poz * 2], a[poz * 2 + 1]);
                    break;
                case "max":
                    a[poz] = Math.Max(a[poz * 2], a[poz * 2 + 1]);
                    break;
            }
        }
        /// <summary>
        /// Changes the element arr[i] with newval
        /// </summary>
        /// <param name="i"> the i-th element </param>
        /// <param name="newval"> the new value of the element </param>
        public void change(int i, int newval)
        {
            modificare(1, nmbVertices, i, 1, newval);
        }

        private void modificare(int st, int dr, int i, int poz, int newval)
        {
            if (st == dr)
            {
                a[poz] = newval;
                return;
            }
            int mij = (st + dr) / 2;
            if (i <= mij)
                modificare(st, mij, i, poz * 2, newval);
            else modificare(mij + 1, dr, i, poz * 2 + 1, newval);
            switch (op)
            {
                case "+":
                    a[poz] = a[poz * 2] + a[poz * 2 + 1];
                    break;
                case "*":
                    a[poz] = a[poz * 2] * a[poz * 2 + 1];
                    break;
                case "min":
                    if (2 * poz + 1 > NmbVertices)
                        a[poz] = a[poz * 2];
                    else
                        a[poz] = Math.Min(a[poz * 2], a[poz * 2 + 1]);
                    break;
                case "max":
                    a[poz] = Math.Max(a[poz * 2], a[poz * 2 + 1]);
                    break;
            }
        }

        /// <summary>
        /// returns the value for the op for the interval [x,y]
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public int returnValueForInterval(int x, int y)
        {
            return value(x, y, 1, nmbVertices, 1);
        }

        private int value(int st, int dr, int star, int drar, int poz)
        {
            if (dr < star || (star == drar && st != dr))
                return 0;
            if (st == star && dr == drar)
                return a[poz];
            int mij = (star + drar) / 2;
            int val1 = 0, val2 = 0;
            if (op.Equals("min"))
                val1 = val2 = 0x3f3f3f3f;
            if (st <= mij)
                val1 = value(st, Math.Min(dr, mij), star, mij, poz * 2);
            if (dr > mij)
                val2 = value(Math.Max(st, mij + 1), dr, mij + 1, drar, poz * 2 + 1);

            int val = 0;
            switch (op)
            {
                case "+":
                    val = val1 + val2;
                    break;
                case "*":
                    val = val1 * val2;
                    break;
                case "min":
                    val = Math.Min(val1, val2);
                    break;
                case "max":
                    val = Math.Max(val1, val2);
                    break;
            }
            return val;
        }
    }
}
