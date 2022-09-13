using UnityEngine;

[ExecuteInEditMode]
public class TreeMask : MonoBehaviour
{
    public GameObject player;
    public SpriteMask mask;
    public float offset;

    void Update()
    {
        if (player == null) return;
        if (transform.position.y > player.transform.position.y + offset)
        {
            mask.enabled = false;
        }
        else
        {
            mask.enabled = true;
        }
    }
}
