using System;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Grid
{
    [SelectionBase]
    public class GridTileView : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerMoveHandler, IPointerUpHandler 
    {
        public SpriteRenderer BaseRenderer;
        public SpriteRenderer OverlayRenderer;
        
        private GridTile Tile;
        
        public void AssignTile(GridTile tile)
        {
            Tile = tile;
            SetupListeners();
        }

        public void SetupListeners()
        {
            RemoveListeners();
            Tile.OnElementAdded += OnElementAdded;
            Tile.OnElementRemoved += OnElementRemoved;
        }

        public void RemoveListeners()
        {
            Tile.OnElementAdded -= OnElementAdded;
            Tile.OnElementRemoved -= OnElementRemoved;
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

        

        private float _pointerHoldDuration;
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer Down on tile" + Tile.GetPosition());
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Pointer Click on tile" + Tile.GetPosition());
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            Debug.Log("Pointer Move on tile" + Tile.GetPosition() + " Position " + eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Pointer Up on tile" + Tile.GetPosition());
        }
        
#if UNITY_EDITOR
        [Button()]
        public void PrintTileInfo()
        {
            Debug.Log(Tile.ToStringWithColor());
        }

        private void OnDrawGizmosSelected()
        {
            
            Handles.Label(transform.position, Tile.ToString(), GridConfig.Instance.TileStyle);
        }

#endif
    }
}