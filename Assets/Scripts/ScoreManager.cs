using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;          // Text für den aktuellen Score

    // Texts für die Highscore-Anzeige (5 Levels)
    public Text highScoreText1;
    public Text highScoreText2;
    public Text highScoreText3;
    public Text highScoreText4;
    public Text highScoreText5;

        
    public static int currentScore = 0;
    public static int currentLevel = 0;

    public int defaultPoints = 10;  // Standardpunkte für das Verlassen des Levels
    public double pointsPerSecond = 100; // Punkte pro Sekunde

    // Get highscores from PlayerPrefs, as an array of 5 integers, with default values of 0, if no highscore is saved
    // load each HighScore from PlayerPrefs to construct array, like "HighScore1" is the key for the first highscore, that corrsponds to the first element of the array
    public static int[] highScores =  new int[5];

    public static bool isHighScore()
    {
        return currentScore > highScores[currentLevel - 1];
    }

    // Make important class variables accessible from other classes and static
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
        highScores = new int[]{
            PlayerPrefs.GetInt("HighScoreLevel1", 0),
            PlayerPrefs.GetInt("HighScoreLevel2", 0),
            PlayerPrefs.GetInt("HighScoreLevel3", 0),
            PlayerPrefs.GetInt("HighScoreLevel4", 0),
            PlayerPrefs.GetInt("HighScoreLevel5", 0)
        };
        DontDestroyOnLoad(gameObject);
    }

    // Set the current score by the name of the Scene where this function is called
    public static void SetLevel()
    {
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "level1":
                currentLevel = 1;
                break;
            case "level2":
                currentLevel = 2;
                break;
            case "level3":
                currentLevel = 3;
                break;
            case "level4":
                currentLevel = 4;
                break;
            case "level5":
                currentLevel = 5;
                break;
            default:
                Debug.LogError("Scene name not found");
                break;
        }
        Debug.Log("Current scene name is: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Debug.Log("Current Level set to: " + currentLevel);
    }



    void Start()
    {
        // LoadScore();               // Highscores laden
        UpdateScoreText();          // Aktuellen Punktestand anzeigen
        // UpdateHighScoreText();      // Alle Highscores anzeigen
    }

    // Punkte zum aktuellen Score hinzufügen
    public void AddPoints(int points = 0)
    {
        currentScore += points == 0 ? defaultPoints : points;
        UpdateScoreText();
    }

    // Punkte pro übrig gebliebener Sekunde hinzufügen
    public void AddPointsPerSecond(double leftOverSeconds)
    {
        currentScore += (int)(leftOverSeconds * pointsPerSecond);
        UpdateScoreText();
    }

    // Den aktuellen Punktestand anzeigen
    public void UpdateScoreText()
    {
        scoreText.text = "Your Score: " + currentScore.ToString();
    }

    // Alle Highscore-Textfelder aktualisieren
    // public void UpdateHighScoreText()
    // {
    //     highScoreText1.text = "Highscore Level 1: " + highScoreLevel1.ToString();
    //     highScoreText2.text = "Highscore Level 2: " + highScoreLevel2.ToString();
    //     highScoreText3.text = "Highscore Level 3: " + highScoreLevel3.ToString();
    //     highScoreText4.text = "Highscore Level 4: " + highScoreLevel4.ToString();
    //     highScoreText5.text = "Highscore Level 5: " + highScoreLevel5.ToString();
    // }

    // Highscore speichern, wenn der aktuelle Punktestand höher ist
    public void SaveScore()
    {
        // Vergleiche und speichere den Highscore für das spezifische Level
        if (currentScore > highScores[currentLevel - 1])
        {
            highScores[currentLevel - 1] = currentScore;
            PlayerPrefs.SetInt("HighScoreLevel" + currentLevel, currentScore);
            PlayerPrefs.Save(); // Änderungen speichern
        }
        PlayerPrefs.Save(); // Änderungen speichern
    }


    // Beispielweise beim Beenden des Spiels oder einer Szene aufrufen
    void OnApplicationQuit()
    {
        SaveScore();  // Zum Beispiel den Highscore für Level 1 speichern
    }
}
