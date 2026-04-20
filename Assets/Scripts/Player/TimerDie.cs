using UnityEngine;

public class TimerDie : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }
}