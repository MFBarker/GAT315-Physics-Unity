using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedMultiplier = 5.0f;

    [SerializeField]Vector2 direction;

    public void OnMove(Vector2 v) => direction = v;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Manager.Instance.GetcanMove())
        {
            Vector2 moveDelta = direction * speedMultiplier * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveDelta);
        }
    }

    

    public void resetMove()
    { 
        //reset velocity of player (somehow sets the causes the player to freeze up entirely)
        rb.linearVelocity = Vector2.zero;
        rb.WakeUp();
    }
}
