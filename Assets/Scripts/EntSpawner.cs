﻿using System.Collections;
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

    }

    private void OnCollisionEnter(Collision collision)
    {
      Instantiate(spawnee, gameObject.transform.position, gameObject.transform.rotation);
      Destroy(gameObject);
    }
}
