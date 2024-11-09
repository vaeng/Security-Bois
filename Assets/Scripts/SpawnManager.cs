using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int numberOfGuests = 10;

    public GameObject guestPrefab;
    private GameObject levelArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelArea = GameObject.Find("LevelArea");
        Object.FindFirstObjectByType<GameManager>().guestsInTheArea = numberOfGuests;
        // instantiate numberOfGuests guests
        for (int i = 0; i < numberOfGuests; i++)
        {
            // get a random position within the level area

            // TODO: seems wrong, spawns too far inside the level area?
            float x = Random.Range(levelArea.transform.position.x - levelArea.transform.localScale.x / 2, levelArea.transform.position.x + levelArea.transform.localScale.x / 2);
            float z = Random.Range(levelArea.transform.position.z - levelArea.transform.localScale.z / 2, levelArea.transform.position.z + levelArea.transform.localScale.z / 2);
            // instantiate the guest at the random position
            Instantiate(guestPrefab, new Vector3(x, 0.5f, z), guestPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
