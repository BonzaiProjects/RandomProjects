using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthCreater
{
    enum TerrainTypes
    {
        /// <summary>
        /// Blank space
        /// </summary>
        Nothing,
        /// <summary>
        /// All the ways
        /// </summary>
        Fourway,
        /// <summary>
        /// Straight line from top to bottom
        /// </summary>
        StraightVertical,
        /// <summary>
        /// Straight line from left to right
        /// </summary>
        StraightHorizontal,
        /// <summary>
        /// From bottom to right
        /// </summary>
        UpRight,
        /// <summary>
        /// From bottom to left
        /// </summary>
        UpLeft,
        /// <summary>
        /// From right to up
        /// </summary>
        RightUp,
        /// <summary>
        /// From left to up
        /// </summary>
        LeftUp,
        /// <summary>
        /// From bottom to left and right
        /// </summary>
        UpLeftRight,
        /// <summary>
        /// From left to up and down
        /// </summary>
        RightUpDown,
        /// <summary>
        /// From top to left and right
        /// </summary>
        DownLeftRight,
        /// <summary>
        /// From right to up and down
        /// </summary>
        LeftUpDown,
        //FourwaySplitTopRight,
        //FourwaySplitTopLeft,

        // Only add new spaces above theese
        /// <summary>
        /// Starting space
        /// </summary>
        Start = 99,
        /// <summary>
        /// Goal space
        /// </summary>
        Goal = 101
    }

    public class Class1
    {
        Random randy = new Random();
        int[,] tempLabyrinth;
        List<int[,]> LabyrinthCollection = new List<int[,]>();
        Node[,] visitedNodes;
        int attempts = 0;

        public int[,] CreateLabyrinth(int x, int y)
        {
            attempts++;
            int totalFields = x * y;
            visitedNodes = new Node[x, y];
            tempLabyrinth = new int[x,y]; // setting size of the labyrinth

            // create collection of terrain types
            List<int> terrainCollection = new List<int>();

            // fill the list
            for (int i = 0; i < totalFields - 2; i++)
            {
                terrainCollection.Add(randy.Next(Enum.GetNames(typeof(TerrainTypes)).Length - 2)); // -2 to remove start+goal from the list
            }

            // create the real labyrinth
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        tempLabyrinth[0, 0] = 99; // start point
                    }
                    else if (i == (x - 1) && j == (y - 1))
                    {
                        tempLabyrinth[x - 1, y - 1] = 101; // goal point
                    }
                    else
                    {
                        int temp = randy.Next(terrainCollection.Count);
                        int temp2 = terrainCollection[temp];
                        tempLabyrinth[i, j] = temp2;
                        terrainCollection.RemoveAt(temp);
                    }
                }
            }

            // check if we can go through the labyrinth
            if (TestLabyrinth())
            {
                // save the labyrinth
                LabyrinthCollection.Add(tempLabyrinth);

                attempts = 0;

                // return it
                return tempLabyrinth;
            }
            else
            {
                return CreateLabyrinth(x, y);
            }
        }

        public int[] TerrainConvert(int terrainIndex)
        {
            int[] tempField;
            // from 0 to 11
            switch (terrainIndex)
            {
                case 0:
                    tempField = new int[] { 0, 0, 0, 0 };
                    break;
                case 1:
                    tempField = new int[] { 1, 1, 1, 1 };
                    break;
                case 2:
                    tempField = new int[] { 1, 0, 1, 0 };
                    break;
                case 3:
                    tempField = new int[] { 0, 1, 0, 1 };
                    break;
                case 4:
                    tempField = new int[] { 0, 1, 1, 0 };
                    break;
                case 5:
                    tempField = new int[] { 0, 0, 1, 1 };
                    break;
                case 6:
                    tempField = new int[] { 1, 1, 0, 0 };
                    break;
                case 7:
                    tempField = new int[] { 1, 0, 0, 1 };
                    break;
                case 8:
                    tempField = new int[] { 0, 1, 1, 1 };
                    break;
                case 9:
                    tempField = new int[] { 1, 0, 1, 1 };
                    break;
                case 10:
                    tempField = new int[] { 1, 1, 0, 1 };
                    break;
                case 11:
                    tempField = new int[] { 1, 1, 1, 0 };
                    break;

                    // only add new above theese
                case 99:
                    tempField = new int[] { -1, 1, 1, -1 }; // start
                    break;
                case 101:
                    tempField = new int[] { 1, 2, 2, 1 }; // goal
                    break;
                default:
                    throw new Exception("Only 0 to 11");
            }

            return tempField;
        }

        private bool TestLabyrinth()
        {
            Node root = new Node(TerrainConvert(tempLabyrinth[0, 0]), 0, 0);
            visitedNodes[0, 0] = root;
            CheckNodeConnections(root);

            // go through tree .. check for Goal field

            return FoundGoal(root);

            //for (int i = 0; i < 4; i++)
            //{
            //    if (root.FieldConnections[i] != 0)
            //    {
            //        int[] temp = null;
            //        int x = -1;
            //        int y = -1;

            //        switch (i)
            //        {
            //            case 0: // Up
            //                if (root.X - 1 < 0)
            //                {
            //                    break;
            //                }
            //                temp = TerrainConvert(tempLabyrinth[root.X -1, root.Y]);
            //                x = root.X - 1;
            //                y = root.Y;
            //                root.Up = new Node(temp, x, y);
            //                break;
            //            case 1: // Right
            //                if (root.Y + 1 > tempLabyrinth.GetLength(1))
            //                {
            //                    break;
            //                }
            //                temp = TerrainConvert(tempLabyrinth[root.X, root.Y + 1]);
            //                x = root.X;
            //                y = root.Y + 1;
            //                root.Right = new Node(temp, x, y);
            //                break;
            //            case 2: // Down
            //                if (root.X +1 > tempLabyrinth.GetLength(0))
            //                {
            //                    break;
            //                }
            //                temp = TerrainConvert(tempLabyrinth[root.X + 1, root.Y]);
            //                x = root.X + 1;
            //                y = root.Y;
            //                root.Down = new Node(temp, x, y);
            //                break;
            //            case 3: // Left
            //                if (root.Y - 1 < 0)
            //                {
            //                    break;
            //                }
            //                temp = TerrainConvert(tempLabyrinth[root.X, root.Y - 1]);
            //                x = root.X;
            //                y = root.Y - 1;
            //                root.Left = CheckNodeConnections(new Node(temp, x, y));
            //                break;
            //            default:
            //                // start or end fix
            //                break;
            //        }
            //    }
            //}
        }

        private Node CheckNodeConnections(Node previous)
        {
            for (int i = 0; i < 4; i++)
            {
                // check if we have an outgoing connection
                if (previous.FieldConnections[i] != 0)
                {
                    switch (i)
                    {
                        case 0:
                            DoTheCheck(previous, -1, 0, i);
                            break;
                        case 1:
                            DoTheCheck(previous, 0, 1, i);
                            break;
                        case 2:
                            DoTheCheck(previous, 1, 0, i);
                            break;
                        case 3:
                            DoTheCheck(previous, 0, -1, i);
                            break;
                        default:
                            break;
                    }
                    //int[] temp = null;
                    //int x = -1;
                    //int y = -1;

                    // check if outside board
                    // check if the field has a connection to us
                    // check if its the previous Node
                    //switch (i)
                    //{
                    //    case 0: // Up
                    //        if (previous.X - 1 < 0)
                    //        {
                    //            break;
                    //        }
                    //        x = previous.X - 1;
                    //        y = previous.Y;
                    //        temp = TerrainConvert(tempLabyrinth[x, y]);
                    //        // if the field's down is not 0 we can go up to it
                    //        if (temp[2] != 0)
                    //        {
                    //            previous.Up = CheckNodeConnections(new Node(temp, x, y));
                    //            break;
                    //        }
                    //        break;
                    //    case 1: // Right
                    //        if (previous.Y + 1 > tempLabyrinth.GetLength(1))
                    //        {
                    //            break;
                    //        }
                    //        x = previous.X;
                    //        y = previous.Y + 1;
                    //        temp = TerrainConvert(tempLabyrinth[x, y]);
                    //        // if the field's left is not 0 we can go to the right
                    //        if (temp[3] != 0)
                    //        {
                    //            previous.Right = CheckNodeConnections(new Node(temp, x, y));
                    //            break;
                    //        }
                    //        break;
                    //    case 2: // Down
                    //        if (previous.X + 1 > tempLabyrinth.GetLength(0))
                    //        {
                    //            break;
                    //        }
                    //        x = previous.X + 1;
                    //        y = previous.Y;
                    //        temp = TerrainConvert(tempLabyrinth[x, y]);
                    //        // if the field's up is not 0 we can go to down
                    //        if (temp[0] != 0)
                    //        {
                    //            previous.Down = CheckNodeConnections(new Node(temp, x, y));
                    //            break;
                    //        }
                    //        break;
                    //    case 3: // Left
                    //        if (previous.Y - 1 < 0)
                    //        {
                    //            break;
                    //        }
                    //        x = previous.X;
                    //        y = previous.Y - 1;
                    //        temp = TerrainConvert(tempLabyrinth[previous.X, previous.Y - 1]);
                    //        // if the field's right is not 0 we can go to the left
                    //        if (temp[1] != 0)
                    //        {
                    //            previous.Left = CheckNodeConnections(new Node(temp, x, y));
                    //            break;
                    //        }
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }

            return previous;
        }

        private void DoTheCheck(Node previous, int changeX, int changeY, int direction)
        {
            // position of the field we are going to
            int x = previous.X + changeX;
            int y = previous.Y + changeY;

            // if outside board
            if (x < 0 || y < 0 || x > tempLabyrinth.GetLength(0) || y > tempLabyrinth.GetLength(1))
            {
                // 
                return;
            }

            int[] temp = TerrainConvert(tempLabyrinth[x,y]);
            if (visitedNodes[x, y] != null)
            {
                return;
            }
            Node current = new Node(temp, x, y);
            visitedNodes[x, y] = current;
            
            // if going back to previous Node
            if (current.X == previous.X && current.Y == previous.Y)
            {
                
            }

            if (temp[direction] != 0)
            {
                temp = TerrainConvert(tempLabyrinth[x, y]);
                switch (direction)
                {
                    case 0:
                        previous.Up = CheckNodeConnections(current);
                        break;
                    case 1:
                        previous.Right = CheckNodeConnections(current);
                        break;
                    case 2:
                        previous.Left = CheckNodeConnections(current);
                        break;
                    case 3:
                        previous.Down = CheckNodeConnections(current);
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void GoingBack(Node previous, int newX, int newY)
        {
            
        }

        private bool FoundGoal(Node rootNode)
        {
            // traverse the graph here
            return true;
        }
    }
    
    class Node
    {
        //public Node[] Nodes { get; set; }
        public Node Up { get; set; }
        public Node Right { get; set; }
        public Node Down { get; set; }
        public Node Left { get; set; }
        // field converted to int[4]
        public int[] FieldConnections { get; set; }
        // X Y = field location in the labyrinth
        public int X { get; set; }
        public int Y { get; set; }

        public Node(int[] fieldCoonections, int x, int y)
        {
            this.FieldConnections = fieldCoonections;
            this.X = x;
            this.Y = y;

            //Nodes = new Node[4];
        }
    }
}
