using System;

namespace Lab2.Folder
{
    public enum Side
    {
        Left,
        Right
    }

    //класс представляет собой узел бинарного дерева
    class BinaryTreeNode
    {
        public BinaryTreeNode(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public BinaryTreeNode LeftNode { get; set; }

        public BinaryTreeNode RightNode { get; set; }

        public BinaryTreeNode ParentNode { get; set; }

        public Side? NodeSide =>
        ParentNode == null
        ? (Side?)null
        : ParentNode.LeftNode == this
        ? Side.Left
        : Side.Right;


        public override string ToString() => Data.ToString();
    }
}