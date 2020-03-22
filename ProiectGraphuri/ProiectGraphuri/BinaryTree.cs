using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    abstract class BinaryTree:Tree
    {
        public class Node
        {
            char inf;
            int InfInf;
            public Node st, dr;
            public Node()
            {

            }
            public Node(char x)
            {
                inf = x;
                st = dr = null;
            }

            public char Inf{
                get{ return inf; }
                set{ inf = value; }
            }
            public Node St{
                get{ return st; }
                set{ st = value; }
            }

            public Node Dr{
                get{ return dr; }
                set{ dr = value; }
            }
        }
        public Node r;


        public BinaryTree(){
            r = new Node();
        }

        public BinaryTree(char x){
            r = new Node(x);
        }

        abstract public void addNode(char inf);


        virtual public char[] inorder(){
            int aux = 0;
            char[] ret = new char[NMAX];
            inord(r, ref ret, ref aux);
            return ret;
        }
        private void inord(Node r, ref char[] ret, ref int cate){
            if(r == null)
                return;
            inord(r.St, ref ret, ref cate);
            ret[cate++] = r.Inf;
            inord(r.Dr, ref ret, ref cate);
        }
        

        virtual public char[] postorder(){
            int aux = 0;
            char[] ret = new char[NMAX];
            postord(r, ref ret, ref aux);
            return ret;
        }
        private void postord(Node r, ref char[] ret, ref int cate){
            if(r == null)
                return;
            postord(r.St, ref ret, ref cate);
            postord(r.Dr, ref ret, ref cate);
            ret[cate++] = r.Inf;
        }
       

        virtual public char[] preorder(){
            int aux = 0;
            char[] ret = new char[NMAX];
            preord(r, ref ret, ref aux);
            return ret;
        }
        private void preord(Node r, ref char[] ret, ref int cate){
            if(r == null)
                return;
            ret[cate++] = r.Inf;
            preord(r.St, ref ret, ref cate);
            preord(r.Dr, ref ret, ref cate);
        }

        virtual public char Root(){
            return r.Inf;
        }
        
    }
}
