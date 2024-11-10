using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public bool gameWon = false;
    public bool gameLost = false;
    public int totalTimeInSeconds = 60;
    public float secondsLeft;
    int activePlayerIndex = 0;

    // needs to be initialized or the game will be won immediately
    public int guestsInTheArea = 23;

    public bool isPaused = false;

    void Start()
    {
        // Erster Spieler wird aktiviert, wenn er nicht null ist
        if (players[activePlayerIndex] != null)
        {
            players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;
        }

        secondsLeft = totalTimeInSeconds;
        // Set the current level in ScoreManager
        ScoreManager.SetLevel();
        // find the object of name "Score" in the scene and assign it's Text component to the scoreText variable in ScoreManager
        ScoreManager.scoreText  = GameObject.Find("Score").GetComponent<Text>();
        if (ScoreManager.scoreText == null)
        {
            Debug.LogError("Score Text not found in the scene.");
        }
    }

    void Update()
    {
        // Umschaltung des aktiven Spielers
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            players[activePlayerIndex].GetComponent<PlayerController>().enabled = false;
            players[activePlayerIndex].GetComponent<Animator>().SetBool("walk_b", false);

            activePlayerIndex = (activePlayerIndex + 1) % players.Length;
            if (players[activePlayerIndex] != null)
            {
                players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;
            }
        }

        // Gewonnenes Spiel
        if (guestsInTheArea <= 0)
        {
            // add seconds left to score
            gameWon = true;
            ScoreManager.AddPointsPerSecond(secondsLeft);
            Debug.Log("Game Won!");
            Debug.Log("Time left: " + secondsLeft);
            if(ScoreManager.isHighScore())
            {
                SceneManager.LoadScene("winningHighscoreScene");
            } else {
                SceneManager.LoadScene("winningScene");
            }
        }

        // Verlorenes Spiel
        if (secondsLeft <= 0)
        {
            gameLost = true;
            Debug.Log("Game Lost!");
            SceneManager.LoadScene("loosingScene");
        }

        // Zeit herunterzählen
        secondsLeft -= Time.deltaTime;

        // Pause-Toggle
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (isPaused)
            {
                // Wenn das Spiel pausiert ist, fortsetzen
                ResumeGame();
            }
            else
            {
                // Wenn das Spiel nicht pausiert ist, Pause aktivieren
                PauseGame();
            }
            isPaused = !isPaused;
        }
    }

    public void PauseGame()
    {
        // Pausiert das Spiel und lädt die Pausenszene nur einmal
        Time.timeScale = 0;

        if (!SceneManager.GetSceneByName("pauseScene").isLoaded) // Überprüfen, ob die Pausenszene schon geladen ist
        {
            SceneManager.LoadScene("pauseScene", LoadSceneMode.Additive);
        }
    }

    public void ResumeGame()
    {
        // Spiel fortsetzen und Pausenszene entladen
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("pauseScene");
    }
}
