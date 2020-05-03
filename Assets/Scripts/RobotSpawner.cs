using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotSpawner : MonoBehaviour
{
  public Vector3 spawnPos1;
  public Vector3 spawnPos2;
  public Vector3 spawnPos3;
  public Vector3 spawnPos4;
  public Vector3 spawnPos5;
  public int pn;
  public GameObject spawnee;


  // public float lifetime == 10f;
    // Update is called once per frame
    void Start(){
    }

    void Update()
    {


        pn = Random.Range(1,8);
        if (Input.GetKeyDown(KeyCode.N))
        {
          if(pn == 1)
          {
            Instantiate(spawnee, spawnPos1, Quaternion.identity);
          }
          else if(pn == 2)
          {
            Instantiate(spawnee, spawnPos2, Quaternion.identity);
          }
          else if(pn == 3)
          {
            Instantiate(spawnee, spawnPos3, Quaternion.identity);
          }
          else if(pn == 4)
          {
            Instantiate(spawnee, spawnPos4, Quaternion.identity);
          }
          else
          {
            Instantiate(spawnee, spawnPos5, Quaternion.identity);
          }
        }
    }
}
