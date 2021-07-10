using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public int shootLimit = 1;

    private float verticalLook;
    public int lookSpeed = 5;

    // Start is called before the first frame update
    void Start()
    { 
       
    }

    // Update is called once per frame
    void Update()
    {
        //Look up and down
        verticalLook = Input.GetAxis("Mouse X") * lookSpeed;
        transform.Rotate(verticalLook, 0, 0);

        //Shoot bullets
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootLimit == 1)
            {
                //Input screenray = Camera.main.ScreenPointToRay();
                Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                shootLimit -= 1; //Lower shoot limit
            }             
        }
    }
}
