using UnityEngine;

public class CameraMove : MonoBehaviour
{
#region Variables
    public float camSpeed;

    Player player;

    int x;
    int y;
    Vector3 camPos;
#endregion
#region Awake & Update
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        camPos = transform.position;
            }

    private void Update()
    {
        CheckPlayerPos();
        Move();
        MoveStop();
    }
#endregion
#region CheckPlayerPos
    private void CheckPlayerPos()
    {
        if (x == 0 && y == 0)
        {
            if (transform.position.x < player.transform.position.x - 8) x = 16;
            if (transform.position.x > player.transform.position.x + 8) x = -16;
            if (transform.position.y < player.transform.position.y - 5) y = 10;
            if (transform.position.y > player.transform.position.y + 5) y = -10;

            camPos = camPos + new Vector3(x, y, 0);
        }
    }
#endregion
#region Move
    private void Move()
    {
        if (transform.position.magnitude != camPos.magnitude)
        {
            player.SetControl(true);
            transform.position = Vector3.Lerp(transform.position, camPos, camSpeed);
        }
    }

    private void MoveStop()
    {
        if (transform.position.magnitude < camPos.magnitude + 0.05f && transform.position.magnitude > camPos.magnitude - 0.05f)
        {
            x = 0;
            y = 0;
            player.SetControl(false);
        }
    }
#endregion
}
