using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float moveDir;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 7.5f;
    private bool isFacingRight = true;

    private void Update()
    {
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);

        if (!isFacingRight && moveDir > 0f)
        {
            Flip();
        }
        else if (isFacingRight && moveDir < 0f)
        {
            Flip();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() && context.performed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.8f, 0.2f), 0, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(0.8f, 0.2f));
    }
}
