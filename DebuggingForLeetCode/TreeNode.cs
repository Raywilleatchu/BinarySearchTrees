using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingForLeetCode
{
    public class TreeNode
    {

        private int data;
        public int Data
        {
            get { return data; }
        }
        
        private TreeNode left;
        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }
        
        private TreeNode right;
        public TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }
        
        private bool isDeleted;
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public TreeNode(int value)
        {
            data = value;
        }

        public void Delete()
        {
            isDeleted = true;
        }

        public TreeNode Find(int value)
        {
            TreeNode currentNode = this;
            while (currentNode != null)
            {
                if (value == currentNode.data && isDeleted == false)
                { //If the current node is equal the value, then the node is found.
                    return currentNode;
                }
                else if (value > currentNode.data)
                { //If the value is greater than the current node, traverse right.
                    currentNode = currentNode.Right;
                }
                else if (value < currentNode.data)
                { //If the value is lesser than the current node, traverse left.
                    currentNode = currentNode.Left;
                }
            }
            return null; //If the value was not found.
        }

        public TreeNode FindRecursive(int value)
        {
            if (value == data && isDeleted == false)
            { //If the current node is equal the value, then the node is found.
                return this;
            }
            else if (value < data && Left != null)
            { //If the value is lesser than the current node's data AND it's left child is not null, the child becomes current and recursively runs this method with the new current node to compare.
                return Left.FindRecursive(value);
            }
            else if (value > data && Right != null)
            { //If the value is greater than the current node's data AND it's right child is not null, the child becomes current and recursively runs this method with the new current node to compare.
                return Right.FindRecursive(value);
            }
            else
            { 
                return null; //If the value was not found.
            }
        }

        public void Insert(int value)
        {
            if (value >= data)
            {
                if (Right == null)
                { //If Right child doesn't exist, set Right's value to the input value; 
                    Right = new TreeNode(value);
                }
                else
                { //If Right child does exist, recursively run this method using the Right child as a parent.
                    Right.Insert(value);
                }
            }
            else //Is Value Less Than Or Equal To Data
            {
                if (Left == null)
                { //If Left child doesn't exist, set Left's value to the input value; 
                    Left = new TreeNode(value);
                }
                else
                { //If Left child does exist, recursively run this method using the Left child as a parent.
                    Left.Insert(value);
                }
            }
        }

        public Nullable<int> SmallestValue()
        { //Smallest Only Works With Left
            if (Left == null)
            { //If there are no further left nodes, the current node is lowest.
                return data;
            }
            else
            { //If there is another left node, recursively run this method using the current left node as a parent.
                return Left.SmallestValue();
            }
        }

        public Nullable<int> LargestValue()
        { //Largest Only Works With Right
            if (right == null)
            { //If there are no further right nodes, the current node is largest.
                return data;
            }
            else
            { //If there is another right node, recursively run this method using the current right node as a parent.
                return right.LargestValue();
            }
        }

        // Traverses Tree starting from the left side reading each set of nodes Left->Parent->Right
        // When Left has been Traversed, do the same to right.
        public void InOrderTraversal()
        {
            if (Left != null)
                Left.InOrderTraversal();

            Console.Write(data + " ");

            if (right != null)
                Right.InOrderTraversal();
        }


        // Traverse Tree starting from the parent reading each set of nodes Parent->Left->Right
        //Start from parent, go down left then go down right.
        public void PreOrderTraversal()
        {
            Console.Write(data + " ");

            if (Left != null)
                Left.PreOrderTraversal();

            if (Right != null)
                Right.PreOrderTraversal();
        }

        //Traverse Tree from Left->Right->Parent
        public void PostOrderTraversal()
        {
            if (Left != null)
                Left.PostOrderTraversal();

            if (Right != null)
                Right.PostOrderTraversal();

            Console.Write(data + " ");
        }

        public int Height()
        {
            if(this.Left == null && this.Right == null)
                return 1;

            int l = 0;
            int r = 0;
        
            if (this.Left != null)
                l = this.Left.Height();
            if (this.Right != null)
                r = this.Right.Height();

            if (l > r)
                return l + 1;
            else
                return r + 1;
        }

        public int NumberOfLeafNodes()
        {
            if (this.Left == null && this.Right == null)
                return 1;

            int lLeaves = 0;
            int rLeaves = 0;

            if(this.Left != null)
                lLeaves = Left.NumberOfLeafNodes();
            if (this.Right != null)
                rLeaves = Right.NumberOfLeafNodes();

            return lLeaves + rLeaves;
        }

        public bool IsBalanced()
        {
            int LeftHeight = Left != null ? Left.Height() : 0;
            int RightHeight = Right != null ? Right.Height() : 0;

            int heightDifference = LeftHeight - RightHeight;

            if(Math.Abs(heightDifference) > 1)
            {
                return false;
            }
            else
            {
                return ((Left != null ? Left.IsBalanced() : true) && (Right != null ? Right.IsBalanced() : true));
            }
        }
    }
}
