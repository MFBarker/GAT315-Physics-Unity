
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] FloatDataSO healthVal;
    [SerializeField] IntDataSO scoreVal;

    [Header("Game UI")]
    [SerializeField] GameObject GameUI;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject keyImage;

    [Header("Win/Loss UI")]
    [SerializeField] GameObject GOBaseUI;
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text LoseText;

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

    public void onDoorOpen()
    {
        //if have key, game over
        if (keyImage.activeSelf)
        { 
            //show ui
            //destroy player
        }
    }

    public void onRespawn()
    {
        if (keyImage.activeSelf) keyImage.SetActive(false);
    }
}
