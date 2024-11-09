using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;          // Text für den aktuellen Score
    public int score;               // Aktueller Punktestand

    // Texts für die Highscore-Anzeige (5 Levels)
    public Text highScoreText1;
    public Text highScoreText2;
    public Text highScoreText3;
    public Text highScoreText4;
    public Text highScoreText5;

    // Highscores für verschiedene Levels
    public int highScoreLevel1;
    public int highScoreLevel2;
    public int highScoreLevel3;
    public int highScoreLevel4;
    public int highScoreLevel5;

    void Start()
    {
        LoadScore();               // Highscores laden
        UpdateScoreText();          // Aktuellen Punktestand anzeigen
        // UpdateHighScoreText();      // Alle Highscores anzeigen
    }

    // Punkte zum aktuellen Score hinzufügen
    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();         // Punktestand aktualisieren
    }

    // Den aktuellen Punktestand anzeigen
    public void UpdateScoreText()
    {
        // scoreText.text = "Score: " + score.ToString();
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
    public void SaveScore(int level)
    {
        // Vergleiche und speichere den Highscore für das spezifische Level
        switch (level)
        {
            case 1:
                if (score > highScoreLevel1)
                {
                    highScoreLevel1 = score;
                    PlayerPrefs.SetInt("HighScoreLevel1", highScoreLevel1);
                }
                break;

            case 2:
                if (score > highScoreLevel2)
                {
                    highScoreLevel2 = score;
                    PlayerPrefs.SetInt("HighScoreLevel2", highScoreLevel2);
                }
                break;

            case 3:
                if (score > highScoreLevel3)
                {
                    highScoreLevel3 = score;
                    PlayerPrefs.SetInt("HighScoreLevel3", highScoreLevel3);
                }
                break;

            case 4:
                if (score > highScoreLevel4)
                {
                    highScoreLevel4 = score;
                    PlayerPrefs.SetInt("HighScoreLevel4", highScoreLevel4);
                }
                break;

            case 5:
                if (score > highScoreLevel5)
                {
                    highScoreLevel5 = score;
                    PlayerPrefs.SetInt("HighScoreLevel5", highScoreLevel5);
                }
                break;

            default:
                Debug.LogError("Invalid level!");
                break;
        }
        PlayerPrefs.Save(); // Änderungen speichern
    }

    // Highscores für alle Level laden
    public void LoadScore()
    {
        highScoreLevel1 = PlayerPrefs.GetInt("HighScoreLevel1", 0);  // Standardwert: 0
        highScoreLevel2 = PlayerPrefs.GetInt("HighScoreLevel2", 0);
        highScoreLevel3 = PlayerPrefs.GetInt("HighScoreLevel3", 0);
        highScoreLevel4 = PlayerPrefs.GetInt("HighScoreLevel4", 0);
        highScoreLevel5 = PlayerPrefs.GetInt("HighScoreLevel5", 0);
        // UpdateHighScoreText(); // Highscore-Textfelder aktualisieren
    }

    // Beispielweise beim Beenden des Spiels oder einer Szene aufrufen
    void OnApplicationQuit()
    {
        SaveScore(1);  // Zum Beispiel den Highscore für Level 1 speichern
    }
}
