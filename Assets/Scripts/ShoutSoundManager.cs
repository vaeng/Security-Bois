using UnityEngine;

public class CharacterShout : MonoBehaviour
{
    public AudioSource shoutSource; // AudioSource für das Shouting
    public AudioClip[] shoutSounds; // Array mit den Shouting-Audiodateien

    void Update()
    {
        // Prüfen, ob die Leertaste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayRandomShout();
        }
    }

    private void PlayRandomShout()
    {
        if (shoutSounds.Length > 0)
        {
            // Zufälligen Shouting-Sound auswählen und abspielen
            AudioClip shout = shoutSounds[Random.Range(0, shoutSounds.Length)];
            shoutSource.PlayOneShot(shout);
        }
    }
}
