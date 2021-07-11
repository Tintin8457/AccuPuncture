using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Basic : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Patient")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            
        }
    }
}
