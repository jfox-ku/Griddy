using UnityEngine;

namespace Grid
{
    public class GridTileElement_Position : GridTileElement
    {
        public override int ElementIndex => (int) GridTileElementID.Position;

        public Vector2Int Value;
        
        public GridTileElement_Position(Vector2Int pos, GridTile parent) : base(parent)
        {
            Value = pos;
        }
        
    }
}