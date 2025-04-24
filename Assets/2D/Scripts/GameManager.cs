using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] EventChannelSO onPlayerDeath;

    private void Start()
    {
        //onPlayerDeath.AddListener(OnPlayerDeath);
    }

    public void OnPlayerDeath()
    {
        print("Player Dead");
    }
}
