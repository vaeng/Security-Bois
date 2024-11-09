using UnityEngine;

public class LeaveArea : MonoBehaviour
{
    public ScoreManager scoreManager;
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

    // if a gameobject with tag "Guest" collides with this object, the exit, destroy the guest and count points
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guest"))
        {
            Destroy(collision.gameObject);
            scoreManager.AddPoints(10);
            scoreManager.UpdateScoreText();
            scoreManager.UpdateHighScoreText();
            
        }
    }
}
