using UnityEngine;
using System;
using System.Collections.Generic;

public class BackgroundScroller : MonoBehaviour
{
    public List<ScrollLayer> Layers;
    private Camera mainCamera;

    [SerializeField]
    private float RepositionThreshold;

    private void Start()
    {
        mainCamera = Camera.main;
        UpdateRepositionThreshold();
    }

    private void Update()
    {
        
        foreach (var layer in Layers)
        {
            foreach (var sprite in layer.Sprites)
            {
                // Move the sprite down based on scroll speed.
                sprite.transform.position += Vector3.down * layer.ScrollSpeed * Time.deltaTime;

                // If the sprite's y-position is less than the threshold, reposition it at the top.
                if (sprite.transform.position.y < RepositionThreshold)
                {
                    RepositionSprite(layer);
                }
            }
        }
    }

    private void UpdateRepositionThreshold()
    {
        // Get the bottom of the camera view in world space
        float cameraHeight = mainCamera.orthographicSize * 2f;
        RepositionThreshold = mainCamera.transform.position.y - (cameraHeight * 1.5f);
    }

    private void RepositionSprite(ScrollLayer layer)
    {
        // Find the highest sprite (the one at the top) in the layer.
        SpriteRenderer highestSprite = layer.Sprites[0];
        foreach (var sprite in layer.Sprites)
        {
            if (sprite.transform.position.y > highestSprite.transform.position.y)
            {
                highestSprite = sprite;
            }
        }

        // Reposition the bottom-most sprite to just above the highest sprite.
        float spriteHeight = highestSprite.bounds.size.y;
        foreach (var sprite in layer.Sprites)
        {
            if (sprite.transform.position.y < RepositionThreshold)
            {
                // Snap position to the nearest 0.1f value to avoid floating point issues
                float newYPosition = highestSprite.transform.position.y + spriteHeight;
                newYPosition = Mathf.Floor(newYPosition * 10) / 10f; // Snap to the nearest 0.1f

                var position = sprite.transform.position;
                position = new Vector3(
                    position.x,
                    newYPosition,
                    position.z
                );
                sprite.transform.position = position;

                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(-10,RepositionThreshold,0), new Vector3(10,RepositionThreshold,0));
    }

    [Serializable]
    public class ScrollLayer
    {
        public float ScrollSpeed;
        public List<SpriteRenderer> Sprites;
    }
}