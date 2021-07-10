using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public int shootLimit = 1;
    
    // Start is called before the first frame update
    void Start()
    { 
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootLimit == 1)
            {
                //Input screenray = Camera.main.ScreenPointToRay();
                Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                shootLimit -= 1;
            }             
        }
    }
}
