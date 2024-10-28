using UnityEngine;

namespace Grid
{
    public static class GridTileElementExtensions
    {
        #region Locked
        public static bool IsLocked(this GridTile tile)
        {
            var l = tile.GetElement<GridTileElement_Locked>((int) GridTileElementID.Locked);
            return l != null;
        }
        
        public static void SetLocked(this GridTile tile, bool locked)
        {
            var l = tile.GetElement<GridTileElement_Locked>((int)GridTileElementID.Locked);
            if (locked)
            {
                if (l == null)
                {
                    tile.AddElement(new GridTileElement_Locked(tile), true);
                }
            }
            else
            {
                if (l != null)
                {
                    tile.RemoveElement(l);
                }
            }
        }
        #endregion

        #region Position
        public static Vector2Int GetPosition(this GridTile tile)
        {
            var e = tile.GetElement<GridTileElement_Position>((int) GridTileElementID.Position);
            if (e == null)
            {
                Debug.LogError("Position element not found in tile.");
            }
            return e.Value;
        }
        
        public static void SetPosition(this GridTile tile, Vector2Int pos)
        {
            var e = tile.GetElement<GridTileElement_Position>((int) GridTileElementID.Position);
            if (e != null)
            {
                e.Value = pos;
                e.Parent = tile;
                return;
            }
            tile.AddElement(new GridTileElement_Position(pos,tile), true);
        }
        #endregion

        #region ViewRef
        
        public static GridTileView GetView(this GridTile tile)
        {
            var e = tile.GetElement<GridTileElement_ViewRef>((int) GridTileElementID.ViewRef);
            if (e == null)
            {
                Debug.LogError("View element not found in tile.");
            }
            return e.View;
        }
        
        public static void SetView(this GridTile tile, GridTileView view)
        {
            var e = tile.GetElement<GridTileElement_ViewRef>((int) GridTileElementID.ViewRef);
            if (e != null)
            {
                e.View = view;
                view.Tile = tile;
                return;
            }
            tile.AddElement(new GridTileElement_ViewRef(view,tile), true);
        }
        

        #endregion
    }
}