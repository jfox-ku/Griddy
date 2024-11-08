using System;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Grid
{
    [SelectionBase]
    public class GridTileView : MonoBehaviour
    {
        public SpriteRenderer BaseRenderer;
        public SpriteRenderer OverlayRenderer;
        
        private GridTile _tile;
        
        public void AssignTile(GridTile tile)
        {
            _tile = tile;
            SetupListeners();
        }

        public void SetupListeners()
        {
            RemoveListeners();
            _tile.OnElementAdded += OnElementAdded;
            _tile.OnElementRemoved += OnElementRemoved;
        }

        public void RemoveListeners()
        {
            _tile.OnElementAdded -= OnElementAdded;
            _tile.OnElementRemoved -= OnElementRemoved;
        }

        private void OnElementRemoved(GridTileElement obj)
        {
            if (obj is GridTileElement_Locked locked)
            {
                SetOverlayColor(Color.white);
                return;
            }
        }

        private void OnElementAdded(GridTileElement obj)
        {
            if (obj is GridTileElement_Position pos)
            {
                transform.localPosition = new Vector3(pos.Value.x,pos.Value.y);
                return;
            }
            
            if (obj is GridTileElement_Locked locked)
            {
                SetOverlayColor(Color.gray);
                return;
            }
        }

        public void SetOverlayColor(Color color)
        {
            OverlayRenderer.color = color;
        }
        
        
#if UNITY_EDITOR
        [Button()]
        public void PrintTileInfo()
        {
            Debug.Log(_tile.ToStringWithColor());
        }

        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying) return;
            Handles.Label(transform.position, _tile.ToString(), GridConfig.Instance.TileStyle);
        }

#endif
    }
}