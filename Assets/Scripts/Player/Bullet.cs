using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake  ()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Logic(float speed)
    {
        rb.AddForce(transform.forward * speed);
    }
}