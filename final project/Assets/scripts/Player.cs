using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 8f;
    private float Horizintal;
    private float jumpforce = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Horizintal = Input.GetAxisRaw("Horizontal");

        if (Horizintal == 0f)
        {
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", true);
        }
        if (!IsGrounded())
        {
            animator.SetBool("jump", true);

        }
        else
        {
            animator.SetBool("jump", false);
        }
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Horizintal * speed, rb.linearVelocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }
}
