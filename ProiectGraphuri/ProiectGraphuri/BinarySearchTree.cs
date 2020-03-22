using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectGraphuri
{
    class BinarySearchTree:BinaryTree
    {
        public BinarySearchTree()
        {
            
        }

        /// <summary>
        /// Inserting inf to the bst
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>   
        public override void addNode(char inf){
            if(nmbVertices == 0)
                r=null;
            add(ref r, inf);
            nmbVertices++;

        }

        private void add(ref Node r, char inf){
            if(r == null){
                r = new Node(inf);
                return;
            }
            if(inf<=r.Inf)
                add(ref r.st, inf);
            else add(ref r.dr, inf);
        }
        
        /// <summary>
        /// deletes the app of inf in the bst
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>     
        public void delete(char inf){
            if(nmbVertices!=0)
                del(ref r, inf);
            nmbVertices--;
        }

        public int find(char inf){
            return search(r, inf, 1);
        }

        private int search(Node p, char inf, int poz){
            if(p == null)
                return -1;
            if(p.Inf == inf)
                return poz;
            if(inf<=p.Inf)
                return search(p.St, inf, poz*2);
            else return search(p.Dr, inf, poz*2+1);
        }
        private void del(ref Node r, char inf){
            if(r == null)
                return;
            else if(r.Inf == inf){
                if(r.St == null && r.Dr == null){
                    r = null;
                }
                else if(r.St == null){
                    Node aux = r.Dr;
                    r = null;
                    r = aux;
                }
                else if(r.Dr == null){
                    Node aux = r.Dr;
                    r = null;
                    r = aux;
                }
                else{
                    stergNod(ref r,ref r.dr);
                }
            }
            else if(inf <= r.Inf)
                del(ref r.st, inf);
            else del(ref r.dr, inf);


        }

        private void stergNod(ref Node r,ref Node aj){
            if(aj.St!=null)
                stergNod(ref r, ref aj.st);
            else{
                r.Inf = aj.Inf;
                Node aux = aj;
                aj = aj.Dr;
                aux = null;
            }
        }
        public char minimumElement(){
            if(nmbVertices == 0)
                return '-';
            return miniElement(r);
        }
        private char miniElement(Node p){
            
            if(p.St == null && p.Dr == null)
                return p.Inf;
            if(p.St != null)
                return miniElement(p.St);
            else return p.Inf;
        }

        public char maximumElement(){
            if(nmbVertices == 0)
                return '-';
            return maxiElement(r);
        }
        
        public char maxiElement(Node p){
            if(p.St == null && p.Dr == null)
                return p.Inf;
            if(p.Dr != null)
                return maxiElement(p.Dr);
            else return p.Inf;
        }
    }
}
