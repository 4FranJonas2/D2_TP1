using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float timeAlive = 5.0f;

    private void Awake  ()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Logic(float speed)
    {
        rb.AddForce(transform.forward * speed);
        Destroy(gameObject, timeAlive);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}