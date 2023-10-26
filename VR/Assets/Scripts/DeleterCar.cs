using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarAI"))
        {
            Destroy(other.gameObject);
        }
    }
}
