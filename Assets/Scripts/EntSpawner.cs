using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntSpawner : MonoBehaviour
{
  public GameObject spawnee;
  public GameObject spawnLocation;
  private float random1;
  private float random2;
  public float pn;
    // Start is called before the first frame update
    // void Start()
    // {
    //
    // }

    // Update is called once per frame
    void Update()
    {
        random1 = Random.Range(-3f, 8f);
        random2 = Random.Range(-3f, 4f);
        if (Input.GetKeyDown(KeyCode.C))
        {
          Vector3 spawnPos = spawnLocation.transform.position;
          spawnPos.x += random1;
          spawnPos.z += random2;
          Instantiate(spawnee, spawnPos, Quaternion.identity);
        }
    }
}
