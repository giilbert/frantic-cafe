using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;
    Animator animator;
    Renderer spriteRenderer;

    Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        animator.enabled = velocity.magnitude != 0;
    }

    void FixedUpdate()
    {
        if (velocity.x != 0)
            spriteRenderer.transform.localScale = new Vector3(Mathf.RoundToInt(velocity.x), 1, 1);

        rb.MovePosition(rb.position + velocity.normalized * Time.deltaTime * moveSpeed);
    }
}
