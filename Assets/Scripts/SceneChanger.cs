    using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Lade die UIScene nur, wenn der sceneName mit "level" beginnt und genau 6 Zeichen lang ist
        if (sceneName.StartsWith("level") && sceneName.Length == 6)
        {
            LoadUISceneIfNeeded();
        }
        
        // Lade die eigentliche Szene
        SceneManager.LoadScene(sceneName);
    }

    private void LoadUISceneIfNeeded()
    {
        // Überprüfen, ob die UI-Szene bereits geladen ist
        if (!SceneManager.GetSceneByName("UIScene").isLoaded)
        {
            // Lade die UI-Szene additiv
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
        }
    }

    private bool player1Confirmed = false;
    private bool player2Confirmed = false;

    public void ConfirmPlayer1(GameObject selectedCharacter)
    {
        SingleCharacterSelectionData.player1Character = selectedCharacter;
        player1Confirmed = true;
        // CheckBothPlayersConfirmed();
        LoadScene("levelSelection");
    }
        public void ConfirmPlayer2(GameObject selectedCharacter)
    {
        CharacterSelectionData.player2Character = selectedCharacter;
        player2Confirmed = true;
        CheckBothPlayersConfirmed();
    }
        private void CheckBothPlayersConfirmed()
    {
        if (player1Confirmed && player2Confirmed)
        {
            // Beide Spieler haben bestätigt – Szene wechseln
            LoadScene("levelSelection");
        }
    }
}
