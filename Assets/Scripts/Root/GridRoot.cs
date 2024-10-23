using System;
using Features.OrderedEvents;
using Grid;
using UnityEngine;

namespace Root
{
    public class GridRoot : MonoBehaviour
    {
        GridConfig config;
        GridBase grid;
        
        private void Awake()
        {
            config = GridConfig.Instance;
            
            GameEvents.OnGameInitialized.AddListener(Order.EARLY, CreateGrid);
            GameEvents.OnGameInitialized.AddListener(Order.LATE, SetUpLocked);
        }

        private void CreateGrid()
        {
            grid = new Grid.GridBase(config.MaxGridBounds.x, config.MaxGridBounds.y);
            Debug.Log("Grid created! Center coordinate: " + grid.CenterCoordinate.ToString());
        }

        private void SetUpLocked()
        {
            var centerCoor = grid.CenterCoordinate;
            var unlockedLowerBounds = centerCoor - (config.StartingBounds/2);
            var unlockedUpperBounds = centerCoor + (config.StartingBounds/2);
            for (int i = 0; i < config.MaxGridBounds.x; i++)
            {
                for (int j = 0; j < config.MaxGridBounds.y; j++)
                {
                    if(i>unlockedLowerBounds.x && i<unlockedUpperBounds.x && j>unlockedLowerBounds.y && j<unlockedUpperBounds.y)
                    {
                        grid.Grid[i, j].AddElement(new GridTileElement_Locked());
                    }
                }
            }
        }
    }
}