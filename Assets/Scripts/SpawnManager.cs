using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int numberOfGuests = 10;

    public GameObject guestPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // instantiate numberOfGuests guests
        for (int i = 0; i < numberOfGuests; i++)
        {
            Instantiate(guestPrefab, transform.position, guestPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
