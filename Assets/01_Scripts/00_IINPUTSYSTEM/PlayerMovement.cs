using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("움직임 세팅")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;

    [Header("땅 체크")]
    [SerializeField] private Transform groundCheck;
   
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private bool isGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(playerInput.HorizontalInput * moveSpeed, rb.linearVelocity.y);
    }



    private void Jump()
    {
        if (playerInput.JumpInputPressed && isGround)
        {
            isGround = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            rb.gravityScale = 1f;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            isGround = false;
            rb.gravityScale = 0f;
            rb.AddForce(Vector2.up * 3, ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = true;
        rb.gravityScale = 1f;
    }
}
