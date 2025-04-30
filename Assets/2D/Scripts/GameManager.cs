
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
    [SerializeField] GameObject keyImage;


    private void Start()
    {
        //onPlayerDeath.AddListener(OnPlayerDeath);
        if(keyImage.activeSelf) keyImage.SetActive(false);
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

    public void onKeyGet()
    { 
        keyImage.SetActive(true);
    }

    public void onRespawn()
    {
        if (keyImage.activeSelf) keyImage.SetActive(false);
    }
}
