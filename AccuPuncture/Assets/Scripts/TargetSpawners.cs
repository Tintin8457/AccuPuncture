using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawners : MonoBehaviour
{
    [Header("Targets")]
    public GameObject[] targets;

    [Header("Target Spawner Update")]
    public List<bool> targetNum = new List<bool>();

    private Dart_Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        //Find player
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            shooter = player.GetComponent<Dart_Shooter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.gameOver == false)
        {
            //for (int i = 0; i < targets.Length; i++)
            //{
            //    switch (targets.Length)
            //    {
            //        case 0:
            //            targets[0].gameObject.SetActive(true);
            //            break;

            //        case 1:
            //            targets[1].gameObject.SetActive(true);
            //            break;

            //        default:
            //            break;
            //    }
            //}

            for (int i = 0; i < targetNum.Count; i++)
            {
                targetNum[shooter.score] = true;
                //Debug.Log("Current: " + targetNum[shooter.score]);
            }

            switch (shooter.score)
            {
                case 0:
                    targetNum[0] = true;
                    targets[0].gameObject.SetActive(true);
                    break;

                case 1:
                    targetNum[1] = true;
                    targets[1].gameObject.SetActive(true);
                    break;

                case 2:
                    targetNum[2] = true;
                    targets[2].gameObject.SetActive(true);
                    break;

                case 3:
                    targetNum[3] = true;
                    targets[3].gameObject.SetActive(true);
                    break;

                case 4:
                    targetNum[4] = true;
                    targets[4].gameObject.SetActive(true);
                    break;

                default:
                    targetNum[0] = true;
                    targets[0].gameObject.SetActive(true);
                    break;
            }
        }
    }
}
