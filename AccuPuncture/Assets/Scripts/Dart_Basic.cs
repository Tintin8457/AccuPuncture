using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Basic : MonoBehaviour
{
    Rigidbody rb;
    private Dart_Shooter shooter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Find player
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            shooter = player.GetComponent<Dart_Shooter>();
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (/*hit.gameObject.tag == "Patient" ||*/ hit.gameObject.tag == "Target")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            shooter.UpdateScore(1);
        }

        if (hit.gameObject.tag == "Patient")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
