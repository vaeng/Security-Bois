using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    int activePlayerIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Take players that are already in the scene
        Debug.Log("Number of players: " + players.Length);
        // activate the first player's PlayerController Script
        players[activePlayerIndex].GetComponent<PlayerController>().enabled = true;
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
    }
}
