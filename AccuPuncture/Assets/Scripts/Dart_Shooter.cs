using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Shooter : MonoBehaviour
{
    [SerializeField] private Dart_Selector selector = null;

    [SerializeField] private Transform dartSpawn = null;

    private int limit = 5;

    private GameObject dartType = null;
    //private Rigidbody projectile = null;

    [SerializeField] private bool ready = true; 

    [SerializeField] private List<GameObject> dartsFired = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
        {
            //As long as there is no current dartType, insantiate a non-projectile dart at the spawn location
            if(dartType == null)
            {
                dartType = (GameObject)Instantiate(selector.GetCurrDart(), 
                    dartSpawn.position, dartSpawn.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject firedDart = null;

            //Set ready to false and destroy the preview dart
            ready = false;
            Destroy(dartType);

            //Spawn projectile
            firedDart = (GameObject)Instantiate(selector.GetCurrProjectile(), 
                dartSpawn.position, dartSpawn.rotation);
            dartsFired.Add(firedDart);
            firedDart.GetComponent<Rigidbody>().velocity = dartSpawn.forward * 15;

            //Destroy old projectiles
            
            if(dartsFired.Count > limit)
            {
                Destroy(dartsFired[0]);
                dartsFired.Remove(dartsFired[0]);
                ShiftFiredDarts();
            }
            
        }
    }

    public void SetReady()
    {
        ready = !ready;
    }

    void ShiftFiredDarts()
    {
        Debug.Log("Get Shifty");
    }
}
