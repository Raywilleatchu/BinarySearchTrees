using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Binary Tree vs Binary Search Tree
/// Typically don't use binary tree... instead we need to use a binary search tree in which
/// Left node is less than parent  and right node is greater than its parent
/// Binary Search Tree is a logical structure (abstract data type) - so it can be implemented in different ways
/// Balanced vs unbalanced
//like all right nodes instead of left and right nodes evenly distributed

//height
// 2^h-1 = n -> h = log(n+1) -> O logn)
//      O     Level 0
//     / \
//    O   O   Level 1
//   /\   /\
//  O  O O  O Level 2
//time complexity for delete and insert are also log n because essentially they are finding a node 
//and then adding constant time to do the operation so we can forget about the added constant time

//Data structures that use BinarySearchTree in their implementation are the C# sortedDictionary, Java Treemap and the C++ set class
//Also the heep is an implementation of a Binary Search Tree
/// </summary>

namespace DebuggingForLeetCode
{
    public class BinaryTree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }

        public TreeNode Find(int data)
        {
            if (root != null)
                return root.Find(data);
            else
                return null;
        }

        public TreeNode FindRecursive(int data)
        {
            if (root != null)
                return root.FindRecursive(data);
            else
                return null;
        }

        public void Insert(int data)
        {
            if (root != null)
                root.Insert(data);
            else
                root = new TreeNode(data);
        }
        
        public void Remove(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;

            if (current == null)
                return;

            while(current != null && current.Data != data)
            {
                parent = current;

                if (data < current.Data)
                {
                    current = current.Left;
                    isLeftChild = true;
                }
                else
                {
                    current = current.Right;
                    isLeftChild = false;
                }
            }

            if (current == null)
                return;

            if (current.Right == null && current.Left == null)
            {
                if (current == root)
                    root = null;
                else
                {
                    if (isLeftChild)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
            }
            else if (current.Right == null)
            {
                if (current == root)
                    root = current.Left;
                else
                {
                    if (isLeftChild)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Left == null)
            {
                if (current == root)
                    root = current.Right;
                else
                {
                    if (current == root)
                        root = current.Right;
                    else
                    {
                        if (isLeftChild)
                            parent.Left = current.Right;
                        else
                            parent.Right = current.Right;
                    }
                }
            }
            else
            {
                TreeNode successor = GetSuccessor(current);
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parent.Left = successor;
                else
                    parent.Right = successor;
            }
        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.Right;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.Left;
            }
            if (successor != node.Right)
            {
                parentOfSuccessor.Left = successor.Right;
                successor.Right = node.Right;
            }

            successor.Left = node.Left;
            return successor;
        }

        public void SoftDelete(int data)
        {
            TreeNode toDelete = Find(data);
            if (toDelete != null)
                toDelete.Delete();
        }

        public Nullable<int> Smallest()
        {
            if (root != null)
                return root.SmallestValue();
            else
                return null;
        }

        public Nullable<int> Largest()
        {
            if (root != null)
                return root.LargestValue();
            else
                return null;
        }

        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }

        public void PreOrderTraversal()
        {
            if (root != null)
                root.PreOrderTraversal();
        }

        public void PostOrderTraversal()
        {
            if (root != null)
                root.PostOrderTraversal();
        }

        public int NumberOfLeaveNodes()
        {
            if (root == null)
                return 0;

            return root.NumberOfLeafNodes();
        }

        public int Height()
        {
            if (root == null)
                return 0;

            return root.Height();
        }

        public bool IsBalanced()
        {
            if (root == null)
                return true;

            return root.IsBalanced();
        }
    }
}
