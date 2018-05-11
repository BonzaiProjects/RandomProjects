using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockMoverGameFiles
{
    

    public class MapMaker
    {
        Map currentMap;

        public MapMaker()
        {
            //mapLocator = new Dictionary<Tuple<int, int>, int>();
        }

        public TerrainType[,] CreateEmptyTerrainMap(int columns, int rows)
        {
            TerrainType[,] map2darray = new TerrainType[columns + 2, rows + 2];
            //int[] MapArray = new int[(columns + 2) * (rows + 2)];
            //mapLocator = new Dictionary<Tuple<int, int>, int>();

            // create the real labyrinth
            //int a = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i == 0 || j == 0 || i == columns - 1 || j == rows - 1)
                    {
                        map2darray[i, j] = TerrainType.Wall;
                        //MapArray[a] = (int)TerrainType.Wall;
                    }
                    else
                    {
                        map2darray[i, j] = TerrainType.Empty;
                        //MapArray[a] = (int)TerrainType.Empty;
                    }
                    //mapLocator[new Tuple<int, int>(i, j)] = a;
                    //a++;
                }
            }
            return map2darray;
        }

        public TerrainType[,] LoadMapFromArray(int[] map, int columns, int rows)
        {
            if (columns*rows != map.Length)
            {
                throw new Exception("Data doesn't match");
            }

            TerrainType[,] map2darray = new TerrainType[columns + 2, rows + 2];
            //int [] MapArray = new int[(columns + 2) * (rows + 2)];
            //mapLocator = new Dictionary<Tuple<int, int>, int>();

            int mapdata = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i == 0 || j == 0 || i == columns - 1 || j == rows - 1)
                    {
                        map2darray[i, j] = TerrainType.Wall;
                        //MapArray[mapdata] = (int)TerrainType.Wall;
                    }
                    else
                    {
                        map2darray[i, j] = (TerrainType)map[mapdata];
                        //MapArray[mapdata] = map[mapdata];
                    }
                    //mapLocator[new Tuple<int, int>(i, j)] = mapdata;
                    mapdata++;
                }
            }
            return map2darray;
        }
    }
}
