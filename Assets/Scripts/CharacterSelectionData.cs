using UnityEngine;

public class CharacterSelectionData : MonoBehaviour
{
    public static GameObject player1Character;
    public static GameObject player2Character;    
    public static CharacterSelectionData Instance;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
