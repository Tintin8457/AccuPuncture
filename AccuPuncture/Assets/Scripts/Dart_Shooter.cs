using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dart_Shooter : MonoBehaviour
{
    [SerializeField] private Dart_Selector selector = null;

    [SerializeField] private Transform dartSpawn = null;

    private int limit = 5;

    private GameObject dartType = null;
    //private Rigidbody projectile = null;

    [SerializeField] private bool ready = true; 

    [SerializeField] private List<GameObject> dartsFired = new List<GameObject>();

    public Text scoreText;
    public int score = 0;
    public Text winText;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            if (ready)
            {
                //As long as there is no current dartType, insantiate a non-projectile dart at the spawn location
                if (dartType == null)
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

                if (dartsFired.Count > limit)
                {
                    Destroy(dartsFired[0]);
                    dartsFired.Remove(dartsFired[0]);
                }
            }
        }

        scoreText.text = "Score: " + score.ToString();

        if (score == 5)
        {
            winText.enabled = true;
            gameOver = true;
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

    public void UpdateScore(int newScore)
    {
        score += newScore;
    }
}
