using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grown : MonoBehaviour
{
    bool enabled = false;

    void Start()    
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.enabled = enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)){
            enabled = !enabled;
        }
        Terrain terrain = GetComponent<Terrain>();
        terrain.enabled = enabled;
    }
}

