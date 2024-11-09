    using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private bool player1Confirmed = false;
    private bool player2Confirmed = false;

    public void ConfirmPlayer1(GameObject selectedCharacter)
    {
        CharacterSelectionData.player1Character = selectedCharacter;
        player1Confirmed = true;
        CheckBothPlayersConfirmed();
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
