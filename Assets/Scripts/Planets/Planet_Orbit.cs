using UnityEngine;

public class Orbit: MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Transform Sun;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Sun != null)
        {
            Vector3 sunPos = Sun.position;
            transform.RotateAround(sunPos, Vector3.up, speed * Time.deltaTime);
        }
         transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}