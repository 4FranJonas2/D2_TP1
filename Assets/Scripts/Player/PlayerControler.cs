using UnityEngine;

public class PlayerMovemment : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movimiento")]
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float deceleration = 10.0f;

    [Header("Rotacion")]
    [SerializeField] private float rotationSpeed = 10.0f;

    [Header("Disparo")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Shoot ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab,firePoint.position,Quaternion.identity);
        }
    }

    private void Movement()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");  
        float sideInput = Input.GetAxisRaw("Horizontal");   


        Vector3 inputDirection = new Vector3(sideInput, 0, forwardInput).normalized;

        if (inputDirection != Vector3.zero)
            currentVelocity += transform.TransformDirection(inputDirection) * acceleration * Time.deltaTime;

        else
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, deceleration * Time.deltaTime);

        currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxSpeed);

        transform.position += currentVelocity * Time.deltaTime;
    }

    private void Rotation()
    {

        float yaw = 0f;
        float pitch = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) yaw -= 1;
        if (Input.GetKey(KeyCode.RightArrow)) yaw += 1;

        if (Input.GetKey(KeyCode.UpArrow)) pitch -= 1;
        if (Input.GetKey(KeyCode.DownArrow)) pitch += 1;

        transform.Rotate(Vector3.up * yaw * rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * pitch * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
