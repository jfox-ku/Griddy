using UnityEngine;

public class InputRaycaster : MonoBehaviour
{
    public Camera MainCam;

    public LayerMask ItemLayerMask;
    public LayerMask GridLayerMask;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
            
            if (RaycastToLayer(mousePos, ItemLayerMask, out RaycastHit2D itemHit))
            {
                Debug.DrawLine(mousePos, MainCam.transform.position, Color.blue, 1f);
                Debug.Log("Hit Item");
            }
            
            if (RaycastToLayer(mousePos, GridLayerMask, out RaycastHit2D gridHit))
            {
                Debug.DrawLine(mousePos, MainCam.transform.position, Color.cyan, 1f);
                Debug.Log("Hit Grid");
            }
        }
    }
    
    private bool RaycastToLayer(Vector2 origin, LayerMask layerMask, out RaycastHit2D hit)
    {
        hit = Physics2D.Raycast(origin, Vector2.zero, 0, layerMask);
        Debug.DrawLine(origin, MainCam.transform.position, Color.gray, 0.1f);
        return hit.collider != null;
    }
}