using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody rb;

    private float fallInterval = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("DestroyPlatform", fallInterval);
        }
    }

    private void DestroyPlatform()
    {
        rb.useGravity = true;
        Destroy(rb.gameObject, 2);
    }
}
