using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] players;

    public bool gameWon = false;
    public int totalTimeInSeconds = 60;
    public float secondsLeft;
    int activePlayerIndex = 0;

    // needs to be initialized or the game will be won immediately
    public int guestsInTheArea = 23;

    public bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    // Erster Spieler wird aktiviert, wenn er nicht null ist
    if (players[activePlayerIndex] != null)
    {
        players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;

        // Überprüfe, ob player1Character existiert und einen MeshRenderer hat
        if (SingleCharacterSelectionData.player1Character.GetComponentInChildren<MeshRenderer>.material != null && 
            SingleCharacterSelectionData.player1Character.GetComponent<MeshRenderer>().material != null)
        {
            // Material auf den bereits existierenden Spieler setzen
            players[activePlayerIndex].GetComponent<MeshRenderer>().material = 
                SingleCharacterSelectionData.player1Character.GetComponent<MeshRenderer>().material;
        }
        else
        {
            Debug.LogWarning("player1Character oder dessen MeshRenderer ist null.");
        }
    }
    
    secondsLeft = totalTimeInSeconds;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            // Aktiven Spieler deaktivieren und auf idle setzen
            players[activePlayerIndex].GetComponent<PlayerController>().enabled = false;
            players[activePlayerIndex].GetComponent<Animator>().SetBool("walk_b", false);
            
            // Nächsten Spieler aktivieren
            activePlayerIndex = (activePlayerIndex + 1) % players.Length;
            if (players[activePlayerIndex] != null)
            {
                players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;
            }
        }
        // count guests in the scene, if zero, game is won
        if (guestsInTheArea <= 0)
        {
            gameWon = true;
            Debug.Log("Game Won!");
            Debug.Log("Time left: " + secondsLeft);
            // PauseGame();
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
