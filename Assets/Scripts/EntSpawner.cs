using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntSpawner : MonoBehaviour
{
  public GameObject spawnee;
  public float pn;
    // Start is called before the first frame update
    // void Start()
    // {
    //
    // }

    // Update is called once per frame
    void Update()
    {
        float random1 = Random.Range(-2f, 2f);
        float random2 = Random.Range(-2f, 2f);
        if (Input.GetKeyDown(KeyCode.C))
        {
          Vector3 spawnPos = GameObject.FindGameObjectWithTag("Tree").transform.position;
          spawnPos.x += random1;
          spawnPos.z += random2;
          Instantiate(spawnee, spawnPos, Quaternion.identity);
        }
    }
}
