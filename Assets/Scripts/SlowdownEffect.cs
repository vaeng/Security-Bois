using UnityEngine;

public class SlowdownEffect : MonoBehaviour
{
    public float slowdownFactor = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if a gameobject with tag "Player" or "Guest" enters this object's collider, slow down Player's speed by slowDownFactor
    // for guests the MoveToPOI component's speed has to be adjusted, and their mass has to be adjusted as well, to make shouting at them less effective
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().speed *= slowdownFactor;
        } else if (other.gameObject.CompareTag("Guest"))
        {
            other.GetComponent<MoveToPOI>().speed *= slowdownFactor;
            other.GetComponent<AvoidPlayer>().avoidanceRadius *= slowdownFactor;
        }
    }

    // if a gameobject with tag "Player" or "Guest" exits this object's collider, reset their speed
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().speed /= slowdownFactor;
        } else if (other.gameObject.CompareTag("Guest"))
        {
            other.GetComponent<MoveToPOI>().speed /= slowdownFactor;
            other.GetComponent<AvoidPlayer>().avoidanceRadius /= slowdownFactor;
        }
    }
}
