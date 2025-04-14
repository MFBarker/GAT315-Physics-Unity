using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpheight = 2;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    Rigidbody2D rb;
    Vector2 force;
    Vector2 direction;

    #region InputActions
    public void OnMove(Vector2 v) => direction = v;
    public void OnJump() 
    {
        rb.AddForce(Vector2.up * Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpheight), ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }
    public void OnAttack() { }
    public void OnDeath() { }
    public void OnHit() { }
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Vector2 direction = Vector2.zero;
        //direction.x = Input.GetAxis("Horizontal");
        force = direction * speed;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    
        //}

        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        //flip sprite
        if (direction.x > 0.05) spriteRenderer.flipX = false;
        else if (direction.x < 0) spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(force.x, rb.linearVelocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
