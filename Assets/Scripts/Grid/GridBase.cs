using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    [Serializable]
    public class GridBase : IEnumerable<(int x, int y, GridTile tile)>
    {
        public static Vector2Int[] NeighbourOffsets = new Vector2Int[]
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };
        
        public GridTile[,] Grid;
        public Vector2Int CenterCoordinate => new Vector2Int(Grid.GetLength(0) / 2, Grid.GetLength(1) / 2);

        public GridBase(int width, int height)
        {
            Grid = new GridTile[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Grid[x, y] = new GridTile();
                }
            }
        }
        
        public GridTile GetNeighbour(Vector2Int origin, Vector2Int offset)
        {
            var neighPos = origin + offset;
            if (IsValidPosition(neighPos))
            {
                return Grid[neighPos.x, neighPos.y];
            }
            else return null;
        }

        public IEnumerable<GridTile> GetAdjacentNeighbours(Vector2Int origin)
        {
            foreach (var offset in NeighbourOffsets)
            {
                var neigh = GetNeighbour(origin, offset);
                if (neigh != null)
                {
                    yield return neigh;
                }
            }
        }

        public bool IsValidPosition(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < Grid.GetLength(0) && pos.y >= 0 && pos.y < Grid.GetLength(1);
        }
        
        // Custom iterator
        public IEnumerator<(int x, int y, GridTile tile)> GetEnumerator()
        {
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.GetLength(1); y++)
                {
                    yield return (x, y, Grid[x, y]);
                }
            }
        }

        // Required for non-generic IEnumerator implementation
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}