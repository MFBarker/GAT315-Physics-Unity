using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Vector2 direction;
    Rigidbody2D rb;

    public void OnMove(Vector2 v) => direction = v;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
