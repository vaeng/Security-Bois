using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationAxis = new Vector3(0, 1, 0);
    public float rotationSpeed = 10.0f;
    public float rotationAngleRange = 45.0f;

    private Vector3 initialRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // let the object rotate around the rotationAxis from -rotationAngleRange to +rotationAngleRange
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * rotationAngleRange;
        transform.rotation = Quaternion.Euler(initialRotation + rotationAxis * rotationAngle);
    }
}
