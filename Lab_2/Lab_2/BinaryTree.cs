using System;

namespace Lab2.Folder
{
    //представляет собой бинарное дерево
    class BinaryTree
    {
        public BinaryTreeNode RootNode { get; set; }

        // добавление узла в дерево
        public BinaryTreeNode Add(BinaryTreeNode node, BinaryTreeNode currentNode = null)
        {
            //если нет вершины то новый элемент будет вершиной
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }


            currentNode = currentNode ?? RootNode;

            node.ParentNode = currentNode;//текущий элемент станет родительским

            int result = node.Data.CompareTo(currentNode.Data);

            if (result == 0)
            {
                return currentNode;
            }
            else if (result < 0) // если новое значение меньше родительского то вставляем влево
            {
                if (currentNode.LeftNode == null)
                    return currentNode.LeftNode = node;
                else return Add(node, currentNode.LeftNode);
            }
            else // если новое значение больше родительского то вставляем вправо
            {
                if (currentNode.RightNode == null)
                    return currentNode.RightNode = node;
                else return Add(node, currentNode.RightNode);
            }
        }

        //удаление узла из дерева
        public void Remove(BinaryTreeNode node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //если у узла нет подузлов, можно его удалить
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют,
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                }
            }
        }
        //поиск по бинаному дереву
        public BinaryTreeNode FindNode(int data, BinaryTreeNode startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result = data.CompareTo(startWithNode.Data);
            if (result == 0)
            {
                return startWithNode;
            }
            else if (result < 0)
            {
                if (startWithNode.LeftNode == null)
                    return null;
                else return FindNode(data, startWithNode.LeftNode);
            }
            else
            {
                if (startWithNode.RightNode == null)
                    return null;
                else return FindNode(data, startWithNode.RightNode);
            }
        }
        public void Remove(int data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        public void PrintTree(BinaryTreeNode startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                //определяем сторону
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                //выводим
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                //добавляем отступ
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }


    }


}