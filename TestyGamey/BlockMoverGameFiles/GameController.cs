using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockMoverGameFiles
{
    public enum Directon
    {
        Right,
        Left,
        Up,
        Down
    }

    public enum TerrainType
    {
        Player = 0, // start position
        Goal = 1,
        Wall = 2,
        Empty = 3,
        MoveableBlock = 4
    }

    public class GameController
    {
        public List<Map> MapList;
        public TerrainType[,] map2darray { get; set; }
        public TerrainType[] MapArray { get; set; }

        private Dictionary<Tuple<int, int>, int> mapLocator;

        public delegate int[] UpdateMap2D(TerrainType[,] changedMap);
        public event UpdateMap2D OnMapChange2D;

        public delegate int[] UpdateMap(TerrainType[] changedMap);
        public event UpdateMap OnMapChange;

        public int GetLocationArray(int x, int y)
        {
            //TerrainType[] t = new TerrainType[4];
            //OnMapChange(t);
            return mapLocator[new Tuple<int, int>(x, y)];
        }

        private Tuple<int, int> GetPlayerLocation()
        {
            int w = map2darray.GetLength(0);
            int h = map2darray.GetLength(1);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (map2darray[i, j].Equals((int)TerrainType.Player))
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            throw new Exception("No player found");
        }

        public bool MovePlayer(Directon direction)
        {
            Tuple<int, int> t = GetPlayerLocation();

            switch (direction)
            {
                case Directon.Right:
                    if (map2darray[t.Item1, t.Item2 + 1] == TerrainType.MoveableBlock)
                    {
                        if (CheckMove(Directon.Right, t.Item1, t.Item2 + 1))
                        {
                            Move(Directon.Right, t.Item1, t.Item2 + 1);
                            Move(Directon.Right, t.Item1, t.Item2);
                            return true;
                        }
                    }
                    else if (CheckMove(Directon.Right, t.Item1, t.Item2))
                    {
                        Move(Directon.Right, t.Item1, t.Item2);
                        return true;
                    }
                    break;
                case Directon.Left:
                    if (map2darray[t.Item1, t.Item2 - 1] == TerrainType.MoveableBlock)
                    {
                        if (CheckMove(Directon.Left, t.Item1, t.Item2 - 1))
                        {
                            Move(Directon.Left, t.Item1, t.Item2 - 1);
                            Move(Directon.Left, t.Item1, t.Item2);
                            return true;
                        }
                    }
                    else if (CheckMove(Directon.Left, t.Item1, t.Item2))
                    {
                        Move(Directon.Left, t.Item1, t.Item2);
                        return true;
                    }
                    break;
                case Directon.Up:
                    if (map2darray[t.Item1 - 1, t.Item2] == TerrainType.MoveableBlock)
                    {
                        if (CheckMove(Directon.Up, t.Item1 - 1, t.Item2))
                        {
                            Move(Directon.Up, t.Item1 - 1, t.Item2);
                            Move(Directon.Up, t.Item1, t.Item2);
                            return true;
                        }
                    }
                    else if (CheckMove(Directon.Up, t.Item1, t.Item2))
                    {
                        Move(Directon.Up, t.Item1, t.Item2);
                        return true;
                    }
                    break;
                case Directon.Down:
                    if (map2darray[t.Item1 + 1, t.Item2] == TerrainType.MoveableBlock)
                    {
                        if (CheckMove(Directon.Down, t.Item1 + 1, t.Item2))
                        {
                            Move(Directon.Down, t.Item1 + 1, t.Item2);
                            Move(Directon.Down, t.Item1, t.Item2);
                            return true;
                        }
                    }
                    else if (CheckMove(Directon.Down, t.Item1, t.Item2))
                    {
                        Move(Directon.Down, t.Item1, t.Item2);
                        return true;
                    }
                    break;
            }
            return false;
        }

        private bool CheckMove(Directon direction, int x, int y)
        {
            // check in front of position
            switch (direction)
            {
                case Directon.Right:
                    if (map2darray[x, y + 1] == TerrainType.Empty)
                    {
                        return true;
                    }
                    break;
                case Directon.Left:
                    if (map2darray[x, y - 1] == TerrainType.Empty)
                    {
                        return true;
                    }
                    break;
                case Directon.Up:
                    if (map2darray[x - 1, y] == TerrainType.Empty)
                    {
                        return true;
                    }
                    break;
                case Directon.Down:
                    if (map2darray[x + 1, y] == TerrainType.Empty)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        private void Move(Directon direction, int x, int y)
        {
            switch (direction)
            {
                case Directon.Right:
                    map2darray[x, y + 1] = map2darray[x, y];
                    int i1 = GetLocationArray(x, y + 1);
                    MapArray[i1] = map2darray[x, y];
                    break;
                case Directon.Left:
                    map2darray[x, y - 1] = map2darray[x, y];
                    int i2 = GetLocationArray(x, y - 1);
                    MapArray[i2] = map2darray[x, y];
                    break;
                case Directon.Up:
                    map2darray[x - 1, y] = map2darray[x, y];
                    int i3 = GetLocationArray(x - 1, y);
                    MapArray[i3] = map2darray[x, y];
                    break;
                case Directon.Down:
                    map2darray[x + 1, y] = map2darray[x, y];
                    int i4 = GetLocationArray(x + 1, y);
                    MapArray[i4] = map2darray[x, y];
                    break;
                default:
                    break;
            }
            map2darray[x, y] = TerrainType.Empty;
            int i = GetLocationArray(x, y);
            MapArray[i] = TerrainType.Empty;
        }

        internal void SaveMap()
        {
            
        }
    }

    public class Map
    {
        public string Name { get; private set; }
        public TerrainType[,] MapArray { get; private set; }

        internal Map(string name, TerrainType[,] mapArray)
        {
            Name = name;
            MapArray = mapArray;
        }

        internal void ChangeMap(int columns, int rows, TerrainType[,] mapArray)
        {
            MapArray = mapArray;
        }

        internal void ChangeMapName(string name)
        {
            Name = name;
            
        }
    }
}
