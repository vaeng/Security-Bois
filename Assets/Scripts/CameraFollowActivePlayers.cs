using UnityEngine;
using System.Collections.Generic;   

public class CameraFollowActivePlayers : MonoBehaviour
{
    public float offsetX = 0;
    public float offsetY = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get all objects, that have the tag "Player" and put them into a list
        List<GameObject> players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        // take only players with an active PlayerController component
        players.RemoveAll(player => !player.GetComponent<PlayerController>().enabled);

        // calculate the center of all active players
        Vector3 center = Vector3.zero;
        foreach (GameObject player in players)
        {
            center += player.transform.position;
        }
        center /= players.Count;

        // position the camera at the center of all active players, keep the y coordinate of the camera
        transform.position = new Vector3(center.x + offsetX, transform.position.y, center.z + offsetY);
    }
}
