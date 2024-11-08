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

        public static Vector3 GetWorldPosition(this GridTile tile)
        {
            return tile.GetView().transform.position;
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

        #region Occupant

        public static GridItem.GridItem GetOccupant(this GridTile tile)
        {
            var e = tile.GetElement<GridTileElement_Occupied>((int) GridTileElementID.Occupied);
            if (e == null)
            {
                return null;
            }
            return e.Value;
        }
        
        public static void SetOccupant(this GridTile tile, GridItem.GridItem occupant)
        {
            var e = tile.GetElement<GridTileElement_Occupied>((int) GridTileElementID.Occupied);
            if (e != null)
            {
                Debug.LogError("Tile already occupied.");
            }
            tile.AddElement(new GridTileElement_Occupied(occupant,tile), true);
        }

        #endregion

        #region Hover
        
        public static bool IsHovered(this GridTile tile)
        {
            var h = tile.GetElement<GridTileElement_Hover>((int) GridTileElementID.Hover);
            return h != null;
        }
        
        public static void SetHovered(this GridTile tile, GridItem.GridItem item)
        {
            var h = tile.GetElement<GridTileElement_Hover>((int)GridTileElementID.Hover);
            if (h == null)
            {
                tile.AddElement(new GridTileElement_Hover(item, tile));
            }
        }
        
        public static void RemoveHovered(this GridTile tile)
        {
            var h = tile.GetElement<GridTileElement_Hover>((int)GridTileElementID.Hover);
            if (h != null)
            {
                tile.RemoveElement(h);
            }
        }
        
        public static bool IsHoveredSameAsOccupant(this GridTile tile)
        {
            var h = tile.GetElement<GridTileElement_Hover>((int) GridTileElementID.Hover);
            var o = tile.GetElement<GridTileElement_Occupied>((int) GridTileElementID.Occupied);
            if (h == null || o == null)
            {
                return false;
            }
            return h.Value == o.Value;
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
                Debug.LogError("View element already exists in tile.");
            }

            var newViewRef = new GridTileElement_ViewRef(view, tile);
            tile.AddElement(newViewRef);
        }
        
        #endregion
    }
}