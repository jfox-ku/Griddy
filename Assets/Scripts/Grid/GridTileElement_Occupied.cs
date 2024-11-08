namespace Grid
{
    public class GridTileElement_Occupied : GridTileElement
    {
        public GridItem.GridItem Value;
        
        public GridTileElement_Occupied(GridItem.GridItem item, GridTile parent) : base(parent)
        {
            Value = item;
        }

        public override int ElementIndex => (int) GridTileElementID.Occupied;

        public override string ToString()
        {
            return base.ToString() + $" Occupied by {Value}";
        }
    }
}