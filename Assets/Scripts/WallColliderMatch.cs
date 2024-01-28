using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WallColliderMatch : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D boxCollider2D;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    void Update()
    {
        if (Application.isEditor && !Application.isPlaying && boxCollider2D != null && spriteRenderer != null)
        {
            if (spriteRenderer.drawMode == SpriteDrawMode.Sliced || spriteRenderer.drawMode == SpriteDrawMode.Tiled)
            {
                boxCollider2D.size = spriteRenderer.localBounds.size;
                boxCollider2D.offset = spriteRenderer.localBounds.center;
            }
            else if (spriteRenderer.drawMode == SpriteDrawMode.Simple)
            {
                float width = spriteRenderer.sprite.textureRect.width / spriteRenderer.sprite.pixelsPerUnit;
                float height = spriteRenderer.sprite.textureRect.height / spriteRenderer.sprite.pixelsPerUnit;
                boxCollider2D.size = new Vector2(width, height);
            }
        }
    }
}
