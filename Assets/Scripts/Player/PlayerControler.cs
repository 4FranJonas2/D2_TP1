using UnityEngine;

public class PlayerMovemment : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movimiento")]
    [SerializeField] private float maxSpeed = 10;

    [Header("Rotacion")]
    [SerializeField] private float rotationSpeed = 10.0f;
    private Vector3 movment;
    private Vector3 rotation;

    [Header("Disparo")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private Vector3 currentVelocity = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void Movement()
    {
        float movementY = 0f;

        if (Input.GetKey(KeyCode.Space)) movementY += 1;
        if (Input.GetKey(KeyCode.LeftControl)) movementY -= 1;

        float rotationInput = 0;
        if (Input.GetKey(KeyCode.Q)) rotationInput -= 1;
        if (Input.GetKey(KeyCode.E)) rotationInput += 1;

        movment = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal") + Vector3.up * movementY;
        transform.Translate(movment * (maxSpeed * Time.deltaTime));
        
        rotation = new  Vector3(0, rotationInput, 0);
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);

    }
}
