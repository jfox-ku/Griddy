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

        public Transform TilesParent;
        
        private void Awake()
        {
            config = GridConfig.Instance;
            
            GridTile.OnElementAddedGlobal = null;
            GridTile.OnElementRemovedGlobal = null;
            
            GameEvents.OnGameInitialized.AddListener(Order.EARLY, CreateGrid);
            GameEvents.OnGameInitialized.AddListener(Order.DEFAULT_ORDER, SetupGridTileViews);
            GameEvents.OnGameInitialized.AddListener(Order.LATE, SetUpLocked);
        }

        private void CreateGrid()
        {
            grid = new Grid.GridBase(config.MaxGridBounds.x, config.MaxGridBounds.y);
            Debug.Log("Grid created! Center coordinate: " + grid.CenterCoordinate.ToString());
            
            
        }

        private void SetupPositions()
        {
            foreach (var (x, y, tile) in grid)
            {
               tile.SetPosition(new Vector2Int(x,y));
            }
        }

        private void SetupGridTileViews()
        {
            foreach (var (x, y, tile) in grid)
            {
                var newObj = Instantiate(config.GridTilePrefab, TilesParent);
                var tileView = newObj.GetComponent<GridTileView>();
                grid.Grid[x, y].SetView(tileView);
            }
        }

        private void SetUpLocked()
        {
            var centerCoor = grid.CenterCoordinate;
            var unlockedLowerBounds = centerCoor - (config.StartingBounds/2);
            var unlockedUpperBounds = centerCoor + (config.StartingBounds/2);
            
            foreach (var (x, y, tile) in grid)
            {
                var inXBounds = x > unlockedLowerBounds.x && x < unlockedUpperBounds.x;
                var inYBounds = y > unlockedLowerBounds.y && y < unlockedUpperBounds.y;
                if(inXBounds && inYBounds)
                {
                    grid.Grid[x, y].SetLocked(false);
                }
                else
                {
                    grid.Grid[x, y].SetLocked(true);
                }
            }
        }
    }
}