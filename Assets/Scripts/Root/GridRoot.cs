using System;
using Grid;
using UnityEngine;

namespace Root
{
    public class GridRoot : MonoBehaviour
    {
        GridConfig config;
        
        private void Awake()
        {
            config = GridConfig.Instance;
            Grid.GridBase grid = new Grid.GridBase(config.MaxGridBounds.x, config.MaxGridBounds.y);
            var centerCoor = grid.CenterCoordinate;
            for (int i = 0; i < config.MaxGridBounds.x; i++)
            {
                for (int j = 0; j < config.MaxGridBounds.y; j++)
                {
                    if (centerCoor.x + i < config.MaxGridBounds.x && centerCoor.y + j < config.MaxGridBounds.y)
                    {
                        
                    }
                        
                }
            }
        }
    }
}