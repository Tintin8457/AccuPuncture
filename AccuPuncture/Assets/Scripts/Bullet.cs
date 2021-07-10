using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody bulletRB;
    private Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();

        //bulletRB.rotation.eulerAngles = new Vector3(-90f, 0f, 0f);
        //transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            shooter = player.GetComponent<Shooter>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Bullet movement
        //transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
        //bulletRB.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
        //bulletRB.transform.localRotation = new Quaternion(-90f, 0f, 0f, 0f);
        bulletRB.AddForce(transform.forward * speed);
    }

    //Destroy bullet at dummy and adds another bullet to the player's bullet 
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Dummy")
        {
            Destroy(gameObject);
            shooter.shootLimit += 1;
        }
    }
}
