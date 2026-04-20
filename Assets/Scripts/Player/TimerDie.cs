using UnityEngine;

public class TimerDie : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}