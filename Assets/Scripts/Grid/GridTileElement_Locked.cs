namespace Grid
{
    public class GridTileElement_Locked : GridTileElement
    {
        public override int ElementIndex => (int) GridTileElementID.Locked;
        
        public GridTileElement_Locked(GridTile parent) : base(parent)
        {
          
        }
        
    }
}