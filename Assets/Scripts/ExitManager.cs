using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
            // Stoppt das Spiel im Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Schließt das Spiel in der erstellten Anwendung
            Application.Quit();
        #endif
    }
}
