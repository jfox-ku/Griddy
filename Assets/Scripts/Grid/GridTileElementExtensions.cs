using UnityEngine;

namespace Grid
{
    public static class GridTileElementExtensions
    {
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
                    tile.AddElement(new GridTileElement_Locked(), true);
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
                return;
            }
            tile.AddElement(new GridTileElement_Position(pos), true);
        }
    }
}