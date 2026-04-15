using UnityEngine;

public class Moon_Orbit : MonoBehaviour
{
    [SerializeField] private Transform Earth;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    private void Update()
    {
        if (Earth != null)
        {
            Vector3 sunPos = Earth.position;
            transform.RotateAround(sunPos, Vector3.up, speed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}