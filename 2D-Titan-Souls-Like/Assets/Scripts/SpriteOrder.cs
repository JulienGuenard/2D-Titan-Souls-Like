using UnityEngine;

[ExecuteInEditMode]
public class SpriteOrder : MonoBehaviour
{
    SpriteRenderer spriteR;
    public int offset;

    void Update()
    {
        if (spriteR == null) spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = Mathf.FloorToInt(-transform.position.y + offset);
    }
}
