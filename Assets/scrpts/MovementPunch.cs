using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 7f;              // Velocidad horizontal (más rápido = salto más largo)
    public float jumpForce = 14f;         // Fuerza del salto (más alto)
    private float horizontalMovement;
    private Rigidbody2D rb;
    private bool lookingRight = true;
    private bool inFloor = true;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);

        // Animación caminar/idle
        animator.SetFloat("movement", Mathf.Abs(horizontalMovement));

        // Girar sprite
        if (horizontalMovement > 0 && !lookingRight) TurnAround();
        else if (horizontalMovement < 0 && lookingRight) TurnAround();

        // Salto
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && inFloor)
        {
            inFloor = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            inFloor = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            inFloor = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            inFloor = false;
            animator.SetBool("isJumping", true);
        }
    }
    void TurnAround()
    {
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}