using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int numberOfGuests = 10;

    public GameObject guestPrefab;
    private GameObject levelArea;

    public Material[] birbSkins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelArea = GameObject.Find("LevelArea");
        Object.FindFirstObjectByType<GameManager>().guestsInTheArea = numberOfGuests;
        // instantiate numberOfGuests guests
        for (int i = 0; i < numberOfGuests; i++)
        {
            // get a random position within the level area, take limits from bounds of the level area's box collider
            float x = Random.Range(levelArea.GetComponent<Collider>().bounds.min.x, levelArea.GetComponent<Collider>().bounds.max.x);
            float z = Random.Range(levelArea.GetComponent<Collider>().bounds.min.z, levelArea.GetComponent<Collider>().bounds.max.z);
            
            // instantiate the guest at the random position, realtive to the level area center
            Vector3 randomSpawnPoint = new Vector3(levelArea.transform.position.x + x, 0.5f, + levelArea.transform.position.z + z);
            GameObject birb = Instantiate(guestPrefab, randomSpawnPoint, guestPrefab.transform.rotation);
            
            // set a random skin for the guest
            birb.GetComponentInChildren<SkinnedMeshRenderer>().material = birbSkins[Random.Range(0, birbSkins.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
