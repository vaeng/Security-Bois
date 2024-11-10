using UnityEngine;

public class CharacterFootsteps : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip[] footstepSounds;
    public float footstepInterval = 0.5f; // Zeitintervall zwischen den Schritten
    private float footstepTimer;

    void Update()
    {
        // Prüfen, ob der Charakter sich bewegt
        if (IsCharacterMoving())
        {
            footstepTimer -= Time.deltaTime;

            // Schrittgeräusch abspielen, wenn der Timer abgelaufen ist
            if (footstepTimer <= 0f)
            {
                PlayFootstepSound();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            // Timer zurücksetzen, wenn der Charakter still steht
            footstepTimer = footstepInterval;
        }
    }

    private bool IsCharacterMoving()
    {
        // Überprüfen, ob der Charakter sich bewegt
        Rigidbody rb = GetComponent<Rigidbody>();
        return rb != null && rb.linearVelocity.magnitude > 0.1f;
    }

    private void PlayFootstepSound()
    {
        // Zufälligen Schrittgeräusch-Sound auswählen und abspielen
        if (footstepSounds.Length > 0)
        {
            AudioClip footstep = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepSource.PlayOneShot(footstep);
        }
    }
}
