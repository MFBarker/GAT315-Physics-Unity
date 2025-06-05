using UnityEngine;

public class WinLose : MonoBehaviour
{
    enum Type
    { 
        Win,
        Lose
    }

    [SerializeField] Type type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (type == Type.Win)
            {
                Manager.Instance.Win();
            }
            else if (type == Type.Lose)
            {
                //Kill Zone
                Manager.Instance.Dead();
                Manager.Instance.OnRespawn(true);
            }
        }
        else if (collision.gameObject.CompareTag("Ball") && type == Type.Lose)
        {
            //Ball in kill zone

            Manager.Instance.OnRespawn(false);
        }
    }
}
