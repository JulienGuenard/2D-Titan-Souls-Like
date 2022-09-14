using UnityEngine;

public class PlayerOutline : MonoBehaviour
{
    SpriteRenderer spriteR;
    public SpriteRenderer spriteRparent;

    void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        SpriteReplika();
    }

    void SpriteReplika()
    {
        spriteR.sprite = spriteRparent.sprite;
    }
}
