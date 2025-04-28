
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] FloatDataSO healthVal;
    [SerializeField] IntDataSO scoreVal;

    [Header("Game UI")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text scoreText;


    private void Start()
    {
        //onPlayerDeath.AddListener(OnPlayerDeath);
    }

    private void FixedUpdate()
    {
        //Update UI
        healthText.text = $"Health: {healthVal.Value}/{healthVal.DefaultValue}";
        scoreText.text = $"Score: {scoreVal.Value}";
    }

    public void OnPlayerDeath()
    {
        print("Player Dead");
    }
}
