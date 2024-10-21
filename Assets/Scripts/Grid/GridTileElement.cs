namespace Grid
{
    public abstract class GridTileElement
    {
        public abstract int ElementIndex { get; }
        public GridTile Parent { get; set; }
    }
}