using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public bool gameWon = false;
    public int totalTimeInSeconds = 60;
    public float secondsLeft;
    int activePlayerIndex = 0;

    public bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // activate the first player's PlayerController Script
        players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;
        secondsLeft = totalTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            players[activePlayerIndex].GetComponent<PlayerController>().enabled = false;
            activePlayerIndex++;
            if (activePlayerIndex >= players.Length)
            {
                activePlayerIndex = 0;
            }
            players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;
        }
        // count guests in the scene, if zero, game is won
        if (GameObject.FindGameObjectsWithTag("Guest").Length == 0)
        {
            gameWon = true;
            Debug.Log("Game Won!");
        }

        // count down the time in seconds:
        secondsLeft -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            isPaused = !isPaused;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
