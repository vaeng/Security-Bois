using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private Renderer characterRenderer; 
    public Material[] characterMaterials;
    public int currentMaterialIndex = 0;

    void Start()
    {
        UpdateCharacterMaterial();
    }

    public void NextCharacter()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % characterMaterials.Length;
        UpdateCharacterMaterial();
    }

    public void PreviousCharacter()
    {
        currentMaterialIndex = (currentMaterialIndex - 1 + characterMaterials.Length) % characterMaterials.Length;
        UpdateCharacterMaterial();
    }

    private void UpdateCharacterMaterial()
    {
        characterRenderer.material = characterMaterials[currentMaterialIndex];
    }
}
