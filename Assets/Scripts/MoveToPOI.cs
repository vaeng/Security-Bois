using UnityEngine;

public class MoveToPOI : MonoBehaviour
{

    public float speed = 1.0f;
    GameObject[] pointsOfInterest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsOfInterest = GameObject.FindGameObjectsWithTag("POI");
    }

    // Update is called once per frame
    void Update()
    {
        // Move the guest to the closest point of interest
        GameObject closestPOI = FindClosestPOI();
        if (closestPOI != null)
        {
            Vector3 directionToPOI = closestPOI.transform.position - transform.position;
            transform.Translate(directionToPOI.normalized * Time.deltaTime * speed, Space.World);
        }
    }

    //return closest point of interest
    private GameObject FindClosestPOI()
    {
        GameObject closestPOI = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject poi in pointsOfInterest)
        {
            Vector3 directionToPOI = poi.transform.position - currentPosition;
            float distance = directionToPOI.sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPOI = poi;
            }
        }
        return closestPOI;
    }

}
