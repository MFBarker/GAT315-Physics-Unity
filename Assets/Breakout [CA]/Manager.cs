using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;

public class Manager : Singleton<Manager>
{
    [Header("UI")]
    [SerializeField] GameObject titleUI;

    [SerializeField] GameObject gameUI;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text livesText;

    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;
    //Player
    [Header("Game")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;

    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform ballSpawn;

    [SerializeField] GameObject bricksPrefab;
    [SerializeField] GameObject bricksInWorld;

    [Header("Input")]
    [SerializeField] InputActionReference resetAction;

    private bool canMove = false;

    //Variables
    public bool GetcanMove()
    {
        return canMove;
    }

    //Variables
    private void SetcanMove(bool value)
    {
        canMove = value;
    }

    int score = 0;
    int lives = 3;

    //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //firstRun = true
        ToTitle(true);

        //Debug.Log(Physics2D.GetIgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("StaticStuff")));
    }

    // Update is called once per frame
    void Update()
    {
        if (resetAction.action.IsPressed())
        {
            //reset position
            OnRespawn(true);
        }
    }

    public void OnStart()
    { 
        titleUI.SetActive(false);
        gameUI.SetActive(true);

        livesText.text = $"Lives: {lives:00}";
        scoreText.text = string.Format("Score: {0:0000}", score);

        SetcanMove(true);
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = string.Format("Score: {0:0000}", score);
    }

    public void Dead() 
    {
        lives--;
        livesText.text = $"Lives: {lives:00}";
        if (lives < 0) Lose();
    }

    public void Win()
    {
        //win
        SetcanMove(false);

        gameUI.SetActive(false);
        winUI.SetActive(true);
    }

    public void Lose()
    {
        //lose
        SetcanMove(false);
        gameUI.SetActive(false);
        loseUI.SetActive(true);
    }

    public void OnReset()
    {
        lives = 3;
        score = 0;

        OnRespawn(true);

        if (loseUI.activeSelf || winUI.activeSelf)
        {
            //hide win/lose screen, show game UI (values have already been reset)
            loseUI.SetActive(false);
            winUI.SetActive(false);
            gameUI.SetActive(true);

            livesText.text = $"Lives: {lives:00}";
            scoreText.text = string.Format("Score: {0:0000}", score);

            //Reset Bricks (Destroy Current, Spawn New Ones, Set variable)
            Destroy(bricksInWorld.gameObject);
            bricksInWorld = GameObject.Instantiate(bricksPrefab);
        }
    }

    public void OnRespawn(bool fullRespawn)
    {
        if (fullRespawn)
        {
            //player has restarted or is below the kill zone
            player.transform.position = playerSpawn.position;
            ball.transform.position = ballSpawn.position;
            canMove = true;
        }
        else
        {
            //ball has fallen
            Vector3 pp = player.gameObject.transform.position;
            ball.transform.position = new Vector3(pp.x,pp.y + 2, pp.z);
            Dead();
        }
    }

    public void ToTitle(bool firstRun)
    {
        if(!firstRun) OnReset();
        //UI Handling
        if (gameUI.activeSelf) gameUI.SetActive(false);
        if (winUI.activeSelf) winUI.SetActive(false);
        if (loseUI.activeSelf) loseUI.SetActive(false);
        titleUI.SetActive(true);
    }
}
