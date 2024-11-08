namespace Grid
{
    public class GridTileElement_Hover : GridTileElement
    {
        public GridItem.GridItem Value;
        
        public GridTileElement_Hover(GridItem.GridItem item, GridTile parent) : base(parent)
        {
            Value = item;
        }

        public override int ElementIndex { get => (int) GridTileElementID.Hover; }
    }
}