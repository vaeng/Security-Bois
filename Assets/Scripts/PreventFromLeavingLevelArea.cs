using UnityEngine;

public class PreventFromLeavingLevelArea : MonoBehaviour
{
    public GameObject levelArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelArea = GameObject.Find("LevelArea");
    }


    // If a gameobject with the tag Guest or Player exits the trigger, move them back to the last okay position
    void Update()
    {
        // Get the bounds of the level area
        Bounds bounds = levelArea.GetComponent<Collider>().bounds;

        // Clamp the object's position to the bounds of the level area
        float boundx = Mathf.Clamp(transform.position.x, bounds.min.x, bounds.max.x);
        float boundz = Mathf.Clamp(transform.position.z, bounds.min.z, bounds.max.z);

        // Update the object's position
        transform.position = new Vector3(boundx, transform.position.y, boundz);	
        
    }


}
