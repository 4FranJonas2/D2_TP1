using UnityEngine;

public class PlayerMovemment : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    // Update is called once per frame
    private void Update()
    {
        float movementY = 0;

        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), movementY, Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * (speed * Time.deltaTime));
    }
}
