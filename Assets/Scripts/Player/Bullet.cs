using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject explosionEffect;

    private void Awake  ()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Logic(float speed)
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        var bullet = Instantiate(explosionEffect, transform.position, Quaternion.identity);
       // Destroy(bullet.gameObject, 2f);
        Destroy(gameObject);
    }
}