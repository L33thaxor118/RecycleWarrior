﻿using System.Collections;
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

  public int pn;
  public GameObject stage1Robot1;
  public GameObject stage1Robot2;

  public GameObject stage2Robot1;
  public GameObject stage2Robot2;

  public GameObject stage3Robot1;
  public GameObject stage3Robot2;

  private int stage1RobotsPerSpawn = 5;
  private int stage2RobotsPerSpawn = 5;
  private int stage3RobotsPerSpawn = 5;



  // public float lifetime == 10f;
    // Update is called once per frame
    void Start(){
    }

    void Update()
    {
    }


    public int SpawnStage1() {
      for (int i = 0; i < stage1RobotsPerSpawn; i++) {
        pn = Random.Range(1,6);
        if(pn == 1)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage1Robot2, spawnPos1, Quaternion.identity);
          } else {
            Instantiate(stage1Robot1, spawnPos1, Quaternion.identity);
          }
        }
        else if(pn == 2)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage1Robot2, spawnPos2, Quaternion.identity);
          } else {
            Instantiate(stage1Robot1, spawnPos2, Quaternion.identity);
          }
        }
        else if(pn == 3)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage1Robot2, spawnPos3, Quaternion.identity);
          } else {
            Instantiate(stage1Robot1, spawnPos3, Quaternion.identity);
          }
        }
        else if (pn == 4)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage1Robot2, spawnPos4, Quaternion.identity);
          } else {
            Instantiate(stage1Robot1, spawnPos4, Quaternion.identity);
          }
        }
        else if (pn == 5)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage1Robot2, spawnPos5, Quaternion.identity);
          } else {
            Instantiate(stage1Robot1, spawnPos5, Quaternion.identity);
          }
        } else 
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage1Robot2, spawnPos6, Quaternion.identity);
          } else {
            Instantiate(stage1Robot1, spawnPos6, Quaternion.identity);
          }
        }
      }
      return stage1RobotsPerSpawn;
    }

    public int SpawnStage2() {
      for (int i = 0; i < stage2RobotsPerSpawn; i++) {
        pn = Random.Range(1,6);
        if(pn == 1)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage2Robot2, spawnPos1, Quaternion.identity);
          } else {
            Instantiate(stage2Robot1, spawnPos1, Quaternion.identity);
          }
        }
        else if(pn == 2)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage2Robot2, spawnPos2, Quaternion.identity);
          } else {
            Instantiate(stage2Robot1, spawnPos2, Quaternion.identity);
          }
        }
        else if(pn == 3)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage2Robot2, spawnPos3, Quaternion.identity);
          } else {
            Instantiate(stage2Robot1, spawnPos3, Quaternion.identity);
          }
        }
        else if (pn == 4)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage2Robot2, spawnPos4, Quaternion.identity);
          } else {
            Instantiate(stage2Robot1, spawnPos4, Quaternion.identity);
          }
        }
        else if (pn == 5)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage2Robot2, spawnPos5, Quaternion.identity);
          } else {
            Instantiate(stage2Robot1, spawnPos5, Quaternion.identity);
          }
        } else 
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage2Robot2, spawnPos6, Quaternion.identity);
          } else {
            Instantiate(stage2Robot1, spawnPos6, Quaternion.identity);
          }
        }
      }
      return stage2RobotsPerSpawn;
    }

    public int SpawnStage3() {
      for (int i = 0; i < stage3RobotsPerSpawn; i++) {
        pn = Random.Range(1,6);
        if(pn == 1)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage3Robot2, spawnPos1, Quaternion.identity);
          } else {
            Instantiate(stage3Robot1, spawnPos1, Quaternion.identity);
          }
        }
        else if(pn == 2)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage3Robot2, spawnPos2, Quaternion.identity);
          } else {
            Instantiate(stage3Robot1, spawnPos2, Quaternion.identity);
          }
        }
        else if(pn == 3)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage3Robot2, spawnPos3, Quaternion.identity);
          } else {
            Instantiate(stage3Robot1, spawnPos3, Quaternion.identity);
          }
        }
        else if (pn == 4)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage3Robot2, spawnPos4, Quaternion.identity);
          } else {
            Instantiate(stage3Robot1, spawnPos4, Quaternion.identity);
          }
        }
        else if (pn == 5)
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage3Robot2, spawnPos5, Quaternion.identity);
          } else {
            Instantiate(stage3Robot1, spawnPos5, Quaternion.identity);
          }
        } else 
        {
          int prob = Random.Range(1,4);
          if (prob == 1) {
            Instantiate(stage3Robot2, spawnPos6, Quaternion.identity);
          } else {
            Instantiate(stage3Robot1, spawnPos6, Quaternion.identity);
          }
        }
      }
      return stage3RobotsPerSpawn;
    }
}
