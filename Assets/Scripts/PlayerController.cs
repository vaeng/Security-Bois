using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the player left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed, Space.World);
    }

    // if a gameobject with tag "Guest" collides with the player,
    //push the guest to the gameobject with the tag exit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guest"))
        {
            GameObject exit = GameObject.FindGameObjectWithTag("Exit");
            // apply force to the guest and push it to the exit
            Vector3 directionToExit = exit.transform.position - collision.gameObject.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(directionToExit.normalized * 1000);
        }
    }
}
