using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioSource; 
    public AudioClip hoverSound;   

    public AudioClip clickSound; 

    void Start()
    {
        // Button-Komponente abrufen
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Hinzufügen einer Methode für den Klicksound zum OnClick-Event des Buttons
            button.onClick.AddListener(PlayClickSound);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);
    }

    void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}