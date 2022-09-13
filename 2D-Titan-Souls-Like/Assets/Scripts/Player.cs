using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    #region Variables
    public TilemapCollider2D waterCollider;
    public TilemapCollider2D waterKillerCollider;
    public float speed, sprintSpeed, rollSpeed;
    float x, y;

    Vector2 vel = new Vector2();

    bool controlLocked, isSprinting, isRolling;

    Rigidbody2D rb;
    Animator animator;
#endregion
#region Awake & Update
    void Awake()
    {
        rb          = GetComponent<Rigidbody2D>();
        animator    = GetComponent<Animator>();
    }

    void Update()
    {
        Inputs();
        Direction();
        Animation();
        Move();
    }
    #endregion
#region Public Methods
    public void SetControl(bool state) { controlLocked = state; }
#endregion
#region Inputs
    void Inputs()
    {
        if (controlLocked) return;

        InputMove();
        InputSprint();
        InputRoll();
    }

    void InputMove()
    {
        if (!isRolling) x = Input.GetAxisRaw("Horizontal");
        if (!isRolling) y = Input.GetAxisRaw("Vertical");
    }

    void InputSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { isSprinting = true; }
        else { isSprinting = false; }
    }

    void InputRoll()
    {
        if (Input.GetKeyDown(KeyCode.E)) { Roll(); }
    }
    #endregion
#region Direction
    void Direction()
    {
        if (!isRolling) vel = new Vector2(x, y);
    }
#endregion
#region Animation
    void Animation()
    {
        AnimationMove();
        AnimationSprint();
    }

    void AnimationMove()
    {
        if (vel.magnitude != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void AnimationSprint()
    {
        if (isSprinting) animator.SetBool("isSprinting", true);
        else animator.SetBool("isSprinting", false);
    }
    #endregion
#region Move
    void Move()
    {
        // Sprint
        if (!isSprinting) rb.velocity = vel * speed;
        if (isSprinting) rb.velocity = vel * sprintSpeed;

        // Camera Change Zone : Lock Run / Sprint
        if (controlLocked) rb.velocity = new Vector2(0, 0);

        // Roll
        if (isRolling) rb.velocity = vel * rollSpeed;
    }
#endregion
#region Roll
    void Roll()
    {
        if (!isSprinting) return;

        waterCollider.enabled = false;
        waterKillerCollider.enabled = false;
        animator.SetBool("isRolling", true);
        isRolling = true;
    }

    public void RollEnd()
    {
        isRolling = false;
        animator.SetBool("isRolling", false);
        waterCollider.enabled = true;
        waterKillerCollider.enabled = true;
    }
    #endregion
}
