using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public Image characterImage;     
    public Sprite[] characterSprites;
    public int currentCharacterIndex = 0;

    public void NextCharacter()
    {
        currentCharacterIndex++;
        if (currentCharacterIndex >= characterSprites.Length)
        {
            currentCharacterIndex = 0; 
        }
        UpdateCharacterImage();
    }

    public void PreviousCharacter()
    {
        currentCharacterIndex--;
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characterSprites.Length - 1; 
        }
        UpdateCharacterImage();
    }

    private void UpdateCharacterImage()
    {
        characterImage.sprite = characterSprites[currentCharacterIndex];
    }
}
