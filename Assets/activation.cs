using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activation : MonoBehaviour
{
    bool enabled = false;
    // Start is called before the first frame update
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
