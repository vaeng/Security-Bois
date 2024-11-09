using System.Collections;
using UnityEngine;

public class LeaveArea : MonoBehaviour
{
    public ScoreManager scoreManager;

    public GameObject[] pathPoints;
    public float exitSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = Object.FindFirstObjectByType<ScoreManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // if a gameobject with tag "Guest" collides with this object, the exit, move the guests out along a path and count points
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guest"))
        {
            // start coroutine to move the guest along the path
            StartCoroutine(MoveGuest(collision.gameObject));

            scoreManager.AddPoints(10);
            scoreManager.UpdateScoreText();
            scoreManager.UpdateHighScoreText();

        }
    }

    // Coroutine to move the guest along a path and destroy it when it reaches the end
    IEnumerator MoveGuest(GameObject guest)
    {
        // radius that the guest can be from the path point, to be considered on point to proceed to the next
        float deltaDistance = 0.5f;

        // Deactivate guest's MoveToPOI script  so it doesn't try to move to a new POI, they are now considered outside the game
        guest.GetComponent<MoveToPOI>().enabled = false;
        // also deactivate the PreventFromLeavingLevelArea script so they can actually leave
        guest.GetComponent<PreventFromLeavingLevelArea>().enabled = false;
        // and finally the AvoidPlayer script so they don't try to avoid the player any longer
        guest.GetComponent<AvoidPlayer>().enabled = false;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            while (Vector3.Distance(guest.transform.position, pathPoints[i].transform.position) > deltaDistance)
            {
                guest.transform.position = Vector3.MoveTowards(guest.transform.position, pathPoints[i].transform.position, exitSpeed * Time.deltaTime);
                yield return null;
            }
        }
        // check if they are at the last path point, if so, destroy the guest
        Destroy(guest);
    }

}
