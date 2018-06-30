using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSample
{
    class Node
    {
        public int val;
        public Node left;
        public Node right;
        public int level;
        public Node(int x, int l)
        {
            left = null;
            right = null;
            val = x;
            level = l;
        }
    }

    

    class Program
    {
        public static void PrintTree(Node node)
        {
            if (node == null) return;
            Console.WriteLine(string.Format("({0})//{1}", node.val, node.level));
            PrintTree(node.left);
            PrintTree(node.right);
        }

        public static void AddNode(Node root, Node node)
        {
            if(node.val < root.val)
            {
                if(root.left == null)
                {
                    root.left = node;
                    node.level = root.level + 1;
                }else
                {
                    AddNode(root.left, node);
                }
            }
            else if(node.val > root.val)
            {
                if(root.right == null)
                {
                    root.right = node;
                    node.level = root.level + 1;
                }else
                {
                    AddNode(root.right, node);
                }
            }
        }

        static int Trace(Node node)
        {
            if(node.right.right == null)
            {
                return node.val;
            }else
            {
                return Trace(node.right);
            }
        }

        static void Main(string[] args)
        {

            int[] a = { 10,9,8,7,6,5,4,3,2,1};

            Node root = new Node(a[0],0);
              
            for(int i = 1; i < a.Length; ++i)
            {
                AddNode(root, new Node(a[i],-1));
            }


            if(root.right == null)
            {
                Console.WriteLine(root.left.val);
            }else
            {
                Console.WriteLine(Trace(root));
            }

            //PrintTree(root);
        }
    }
}
