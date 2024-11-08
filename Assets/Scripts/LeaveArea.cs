using UnityEngine;

public class LeaveArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if a gameobject with tag "Guest" collides with this object, the exit, destroy the guest
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guest"))
        {
            Destroy(collision.gameObject);
        }
    }
}
