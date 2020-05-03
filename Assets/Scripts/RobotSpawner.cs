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
  public Vector3 spawnPos6;
  public Vector3 spawnPos7;
  public Vector3 spawnPos8;
  public int pn;
  public GameObject spawnee;


  // public float lifetime == 10f;
    // Update is called once per frame
    void Start(){
      spawnPos1 = new Vector3(50.0f, 0.0f, 100.0f); // t
      spawnPos2 = new Vector3(85.355f, 0.0f, 85.355f); // tr
      spawnPos3 = new Vector3(100f, 0.0f, 50.0f); // r
      spawnPos4 = new Vector3(85.355f, 0.0f, 14.645f); // br
      spawnPos5 = new Vector3(50.0f, 0.0f, 0f); // b
      spawnPos6 = new Vector3(14.645f, 0.0f, 14.645f); // bl
      spawnPos7 = new Vector3(0.0f, 0.0f, 50.0f); // l
      spawnPos8 = new Vector3(14.645f, 0.0f, 85.355f); // tl
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
          else if(pn == 5)
          {
            Instantiate(spawnee, spawnPos5, Quaternion.identity);
          }
          else if(pn == 6)
          {
            Instantiate(spawnee, spawnPos6, Quaternion.identity);
          }
          else if(pn == 7)
          {
            Instantiate(spawnee, spawnPos7, Quaternion.identity);
          }
          else
          {
            Instantiate(spawnee, spawnPos8, Quaternion.identity);
          }
        }
    }
}
