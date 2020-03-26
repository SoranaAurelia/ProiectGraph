using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class Trie : Tree
    {
        Nod r;
        private static int numberOfWords;
        static List<Nod>[] cuv = new List<Nod>[NMAX];
        static List<string> cuvinte = new List<string>();
        public Trie()
        {
            r = new Nod();
        }
        public static Trie operator +(Trie me, string s)
        {
            int l = s.Length;
            numberOfWords++;
            cuv[numberOfWords] = new List<Nod>(l + 2);
            for (int i = 0; i < l + 2; i++)
                cuv[numberOfWords].Add(new Nod());
            cuvinte.Add(s);
            me.adaug(me.r, 0, s);

            return me;
        }
        public static Trie operator -(Trie me, string s)
        {
            int l = s.Length;
            me.sterg(me.r, 0, s);
            cuvinte[me.firstIndexOfString(s) - 1] = null;
            return me;
        }

        void sterg(Nod p, int poz, string s)
        {
            if (poz == s.Length)
            {
                p.Fin--;
                if (p.Nrcnt == 0 && p.Fin == 0)
                    p = null;
                return;
            }
            p.copii[s[poz] - 'a'].Nrcnt--;
            sterg(p.copii[s[poz] - 'a'], poz + 1, s);
            if (p.Nrcnt == 0 && p.Fin == 0 && poz != 0)
                p = null;
        }

        void adaug(Nod p, int poz, string s)
        {
            if (poz == s.Length)
            {
                p.Fin++;
                return;
            }
            if (p.copii[s[poz] - 'a'] == null)
            {
                p.copii[s[poz] - 'a'] = new Nod();
            }
            p.copii[s[poz] - 'a'].Nrcnt++;
            adaug(p.copii[s[poz] - 'a'], poz + 1, s);
            cuv[numberOfWords][poz] = p.copii[s[poz] - 'a'];
        }
        /// <summary>
        /// Returns the string at 'index'
        /// </summary>
        /// <param name="index"></param>
        public string StringAtIndex(int index)
        {
            return cuvinte[index];
        }

        /// <summary>
        /// returns the first index of the strinf 's'
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int firstIndexOfString(string s)
        {
            for (int j = 0; j < cuvinte.Count; j++)
            {
                if (cuvinte[j] == null)
                    continue;
                if (cuvinte[j].Equals(s))
                    return j + 1;
            }
            return -1;
        }
        /// <summary>
        /// Returns how many times the string s appears in the trie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int numberOfAppearances(string s)
        {
            return nmbApp(r, 0, s);
        }

        private int nmbApp(Nod p, int poz, string s)
        {
            if (poz == s.Length)
                return p.Fin;
            if (p.copii[s[poz] - 'a'] != null)
                return nmbApp(p.copii[s[poz] - 'a'], poz + 1, s);
            return 0;
        }

        /// <summary>
        /// Returns the longest prefix of the word s with the any of the introduced words
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns></returns>
        public int longestPrefix(string s)
        {
            return nmbLP(r, 0, s);
        }
        /// <summary>
        /// Returns the longest prefix from a list of words
        /// </summary>
        /// <param name="k">The number of words</param>
        /// <param name="index">The list with the indeces of the words in the order that they were introduced</param>
        /// <returns></returns>
        public string LongestPrefixOfAListOfWords(int k, int[] index)
        {
            int vmin = NMAX;
            if (cuvinte == null)
                return "nu exista cuvinte in trie";
            for (int j = 0; j < k; j++)
            {
                if (cuvinte.Count < index[j])
                    return "nu exista cuvantul cu index " + index[j];
                if (cuvinte[index[j] - 1] == null)
                    return "nu exista cuvantul cu index " + index[j];
                if (cuv[index[j]].Count < vmin)
                    vmin = cuv[index[j]].Count;
            }

            int lg;
            for (lg = 1; lg <= vmin; lg <<= 1) ;

            int i = 0;
            int ok = 0;
            for (int l = lg; l != 0; l >>= 1)
                if (i + l < vmin && verif(i + l, k, index) == 1)
                {
                    i += l;
                    ok = 1;
                }
            if (ok == 0 && verif(0, k, index) == 0)
                return "";
            return cuvinte[index[0]].Substring(0, i + 1);
        }

        int verif(int x, int k, int[] index)
        {
            for (int j = 1; j < k; j++)
            {
                if (cuv[index[j]][x] != cuv[index[0]][x])
                    return 0;
            }
            return 1;
        }
        private int nmbLP(Nod p, int poz, string s)
        {
            if (poz == s.Length)
                return s.Length;
            if (p.copii[s[poz] - 'a'] == null || p.copii[s[poz] - 'a'].Nrcnt == 0)
                return poz;
            return nmbLP(p.copii[s[poz] - 'a'], poz + 1, s);
        }

    }
}