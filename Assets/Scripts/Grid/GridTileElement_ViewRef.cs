namespace Grid
{
    public class GridTileElement_ViewRef : GridTileElement
    {
        public override int ElementIndex => (int) GridTileElementID.ViewRef;
        public GridTileView View;
        
        public GridTileElement_ViewRef(GridTileView view, GridTile parent) : base(parent)
        {
            View = view;
            View.AssignTile(parent);
            Parent = parent;
        }
    }
}