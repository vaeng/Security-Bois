using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public float avoidanceRadius = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if this guest gameobject is within the avoidance radius of any player tagged object in the scene, move away from that player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < player.GetComponent<PlayerController>().shoutRadius)
            {
                // only consider x and z coordinates, ignore y. also don't use y axis in the movement
                Vector3 directionToPlayer = player.transform.position - transform.position;
                Vector3 directionToPlayerXZ = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);
                transform.Translate(-directionToPlayerXZ.normalized * Time.deltaTime * avoidanceRadius, Space.World);
            }
        }

    }
}
