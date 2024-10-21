using System;
using UnityEngine;

namespace Grid
{
    [Serializable]
    public class GridBase
    {
        public GridTile[,] Grid;
        
        public GridBase(int width, int height)
        {
            Grid = new GridTile[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Grid[x, y] = new GridTile();
                    Grid[x, y].AddElement(new GridTileElement_Position(new Vector2Int(x,y)));
                }
            }
        }
    }
}