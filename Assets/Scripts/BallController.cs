using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private bool canMove;
    private bool changeDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        canMove = false;
        changeDirection = true;
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            canMove = true;

            if (changeDirection)
            {
                changeDirection = false;
            }
            else if (!changeDirection)
            {
                changeDirection = true;
            }
        }
        
        if (canMove && changeDirection) // X-Axis Movement
        {
            transform.Translate(0.01f,0,0);
        }
        else if (canMove && !changeDirection) // Z-Axis Movement
        {
            transform.Translate(0,0,0.01f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            rb.useGravity = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            rb.useGravity = false;
        }
        
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            rb.useGravity = false;
        }
    }
}
