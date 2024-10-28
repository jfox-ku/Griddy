using DefaultNamespace.Helpers;
using UnityEngine;

namespace Grid
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Config/GridConfig", order = 0)]
    public class GridConfig : ConfigSingleton<GridConfig>
    {
        public Vector2Int MaxGridBounds;
        public Vector2Int StartingBounds;
        
        public GameObject GridTilePrefab;

        public Color EmptyTileColor;
        public Color UsedTileColor;
        
    }
}