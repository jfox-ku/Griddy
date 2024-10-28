using NaughtyAttributes;
using UnityEngine;

namespace Grid
{
    public class GridTileView : MonoBehaviour
    {
        public SpriteRenderer BaseRenderer;
        public SpriteRenderer OverlayRenderer;
        
        [ReadOnly]
        public GridTile Tile;
    }
}