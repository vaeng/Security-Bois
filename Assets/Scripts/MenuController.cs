using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button defaultButton;  // Der Button, der beim Start vorausgewählt sein soll

    void Start()
    {
        // Setzt den Standard-Button, wenn die Szene startet
        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
    }
}