using System;

namespace Grid
{
    public abstract class GridTileElement
    {
        public abstract int ElementIndex { get; }
        public GridTile Parent { get; set; }
        
        protected GridTileElement(GridTile parent)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent), "Parent GridTile cannot be null.");
        }

        public override string ToString()
        {
            GridTileElementID Type = (GridTileElementID) ElementIndex;
            return Type.ToString();
        }
    }
}