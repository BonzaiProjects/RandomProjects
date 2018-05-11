using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGameBlockMover
{
    //public enum TerrainType
    //{
    //    Player = 0, // start position
    //    Goal = 1,
    //    Wall = 2,
    //    Empty = 3,
    //    MoveableBlock = 4
    //}

    //public enum Directon
    //{
    //    Right,
    //    Left,
    //    Up,
    //    Down
    //}

    class MapMakerBackup
    {
        //    public int[,] map2darray { get; set; }
        //    public int[] MapArray { get; set; }

        //    private Dictionary<Tuple<int, int>, int> mapLocator;

        //    public MapMakerBackup()
        //    {
        //        mapLocator = new Dictionary<Tuple<int, int>, int>();
        //        CreateEmptyMap(1, 1);
        //        //OnMapChange(2);
        //    }

        //    public void CreateEmptyMap(int columns, int rows)
        //    {
        //        map2darray = new int[columns + 2, rows + 2];
        //        MapArray = new int[(columns + 2) * (rows + 2)];
        //        mapLocator = new Dictionary<Tuple<int, int>, int>();

        //        // create the real labyrinth
        //        int a = 0;
        //        for (int i = 0; i < columns; i++)
        //        {
        //            for (int j = 0; j < rows; j++)
        //            {
        //                if (i == 0 || j == 0 || i == columns - 1 || j == rows - 1)
        //                {
        //                    map2darray[i, j] = (int)TerrainType.Wall;
        //                    MapArray[a] = (int)TerrainType.Wall;
        //                }
        //                else
        //                {
        //                    map2darray[i, j] = (int)TerrainType.Empty;
        //                    MapArray[a] = (int)TerrainType.Empty;
        //                }
        //                mapLocator[new Tuple<int, int>(i, j)] = a;
        //                a++;
        //            }
        //        }
        //    }

        //    public void LoadMapFromArray(int[] map, int columns, int rows)
        //    {
        //        if (columns*rows != map.Length)
        //        {
        //            throw new Exception("Data doesn't match");
        //        }

        //        map2darray = new int[columns + 2, rows + 2];
        //        MapArray = new int[(columns + 2) * (rows + 2)];
        //        mapLocator = new Dictionary<Tuple<int, int>, int>();

        //        int mapdata = 0;
        //        for (int i = 0; i < columns; i++)
        //        {
        //            for (int j = 0; j < rows; j++)
        //            {
        //                if (i == 0 || j == 0 || i == columns - 1 || j == rows - 1)
        //                {
        //                    map2darray[i, j] = (int)TerrainType.Wall;
        //                    MapArray[mapdata] = (int)TerrainType.Wall;
        //                }
        //                else
        //                {
        //                    map2darray[i, j] = map[mapdata];
        //                    MapArray[mapdata] = map[mapdata];
        //                }
        //                mapLocator[new Tuple<int, int>(i, j)] = mapdata;
        //                mapdata++;
        //            }
        //        }
        //    }

        //    public int GetLocationArray(int x, int y)
        //    {
        //        return mapLocator[new Tuple<int, int>(x, y)];
        //    }

        //    private Tuple<int, int> GetPlayerLocation()
        //    {
        //        int w = map2darray.GetLength(0);
        //        int h = map2darray.GetLength(1);

        //        for (int i = 0; i < h; i++)
        //        {
        //            for (int j = 0; j < h; j++)
        //            {
        //                if (map2darray[i,j].Equals((int)TerrainType.Player))
        //                {
        //                    return new Tuple<int, int>(i, j);
        //                }
        //            }
        //        }
        //        throw new Exception("No player found");
        //    }

        //    public bool MovePlayer(Directon direction)
        //    {
        //        Tuple<int, int> t = GetPlayerLocation();

        //        switch (direction)
        //        {
        //            case Directon.Right:
        //                if (map2darray[t.Item1, t.Item2 + 1] == (int)TerrainType.MoveableBlock)
        //                {
        //                    if (CheckMove(Directon.Right, t.Item1, t.Item2 + 1))
        //                    {
        //                        Move(Directon.Right, t.Item1, t.Item2 + 1);
        //                        Move(Directon.Right, t.Item1, t.Item2);
        //                        return true;
        //                    }
        //                }
        //                else if (CheckMove(Directon.Right, t.Item1, t.Item2))
        //                {
        //                    Move(Directon.Right, t.Item1, t.Item2);
        //                    return true;
        //                }
        //                break;
        //            case Directon.Left:
        //                if (map2darray[t.Item1, t.Item2 - 1] == (int)TerrainType.MoveableBlock)
        //                {
        //                    if (CheckMove(Directon.Left, t.Item1, t.Item2 - 1))
        //                    {
        //                        Move(Directon.Left, t.Item1, t.Item2 - 1);
        //                        Move(Directon.Left, t.Item1, t.Item2);
        //                        return true;
        //                    }
        //                }
        //                else if (CheckMove(Directon.Left, t.Item1, t.Item2))
        //                {
        //                    Move(Directon.Left, t.Item1, t.Item2);
        //                    return true;
        //                }
        //                break;
        //            case Directon.Up:
        //                if (map2darray[t.Item1 - 1, t.Item2] == (int)TerrainType.MoveableBlock)
        //                {
        //                    if (CheckMove(Directon.Up, t.Item1 - 1, t.Item2))
        //                    {
        //                        Move(Directon.Up, t.Item1 - 1, t.Item2);
        //                        Move(Directon.Up, t.Item1, t.Item2);
        //                        return true;
        //                    }
        //                }
        //                else if (CheckMove(Directon.Up, t.Item1, t.Item2))
        //                {
        //                    Move(Directon.Up, t.Item1, t.Item2);
        //                    return true;
        //                }
        //                break;
        //            case Directon.Down:
        //                if (map2darray[t.Item1 + 1, t.Item2] == (int)TerrainType.MoveableBlock)
        //                {
        //                    if (CheckMove(Directon.Down, t.Item1 + 1, t.Item2))
        //                    {
        //                        Move(Directon.Down, t.Item1 + 1, t.Item2);
        //                        Move(Directon.Down, t.Item1, t.Item2);
        //                        return true;
        //                    }
        //                }
        //                else if (CheckMove(Directon.Down, t.Item1, t.Item2))
        //                {
        //                    Move(Directon.Down, t.Item1, t.Item2);
        //                    return true;
        //                }
        //                break;
        //        }
        //        return false;
        //    }

        //    private bool CheckMove(Directon direction, int x, int y)
        //    {
        //        // check in front of position
        //        switch (direction)
        //        {
        //            case Directon.Right:
        //                if (map2darray[x, y + 1] == (int)TerrainType.Empty)
        //                {
        //                    return true;
        //                }
        //                break;
        //            case Directon.Left:
        //                if (map2darray[x, y - 1] == (int)TerrainType.Empty)
        //                {
        //                    return true;
        //                }
        //                break;
        //            case Directon.Up:
        //                if (map2darray[x - 1, y] == (int)TerrainType.Empty)
        //                {
        //                    return true;
        //                }
        //                break;
        //            case Directon.Down:
        //                if (map2darray[x + 1, y] == (int)TerrainType.Empty)
        //                {
        //                    return true;
        //                }
        //                break;
        //        }
        //        return false;
        //    }

        //    private void Move(Directon direction, int x, int y)
        //    {
        //        switch (direction)
        //        {
        //            case Directon.Right:
        //                map2darray[x, y + 1] = map2darray[x, y];
        //                int i1 = GetLocationArray(x, y + 1);
        //                MapArray[i1] = map2darray[x, y];
        //                break;
        //            case Directon.Left:
        //                map2darray[x, y - 1] = map2darray[x, y];
        //                int i2 = GetLocationArray(x, y - 1);
        //                MapArray[i2] = map2darray[x, y];
        //                break;
        //            case Directon.Up:
        //                map2darray[x - 1, y] = map2darray[x, y];
        //                int i3 = GetLocationArray(x - 1, y);
        //                MapArray[i3] = map2darray[x, y];
        //                break;
        //            case Directon.Down:
        //                map2darray[x + 1, y] = map2darray[x, y];
        //                int i4 = GetLocationArray(x + 1, y);
        //                MapArray[i4] = map2darray[x, y];
        //                break;
        //            default:
        //                break;
        //        }
        //        map2darray[x, y] = (int)TerrainType.Empty;
        //        int i = GetLocationArray(x, y);
        //        MapArray[i] = (int)TerrainType.Empty;
        //    }

        //    public delegate int[] Action(int i);

        //    public event Action OnMapChange;
        //}

        //internal class Map
        //{
        //    public string Name { get; set; }
        //    public int Columns { get; private set; }
        //    public int Rows { get; private set; }
        //    public int[] MapArray { get; private set; }

        //    public Map(string name, int columns, int rows, int[] mapArray)
        //    {
        //        Name = name;
        //        Columns = columns;
        //        Rows = rows;
        //        MapArray = mapArray;
        //    }

        //    public void SetMap(int columns, int rows, int[] mapArray)
        //    {
        //        Columns = columns;
        //        Rows = rows;
        //        MapArray = mapArray;
        //    }
    }
}
