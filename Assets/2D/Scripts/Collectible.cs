using UnityEngine;

enum eType
{ 
    Coin,
    Gem
}

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    [SerializeField] eType type;
    [SerializeField] IntDataSO Score;
    [SerializeField] int val = 0;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (type)
        {
            case eType.Coin:
                Score.Value += val;
                break;
            case eType.Gem:
                Score.Value += val;
                break;
        }

        Destroy(this.gameObject);
    }

}
