﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{   
    private int level;
    // Start is called before the first frame update
    void Start()
    {  
        this.level = 1;
        
    }

    // Update is called once per frame
    void Update()
    {     
    }

    public void LevelUp() {
        this.level += 1;
        string path = "10Terrains/T" + this.level.ToString() ;
        Debug.Log(path);
        TerrainData next = Resources.Load<TerrainData>(path);
        Terrain actiavet = Terrain.activeTerrain;
        Terrain[] activate = Terrain.activeTerrains;
        activate[activate.Length - 1].enabled = false;
        Debug.Log(activate.Length);
        // Debug.Log(Terrain.activeTerrains);
        // actiavet.enabled = false;
        
        GameObject tnext = Terrain.CreateTerrainGameObject(next);
        tnext.transform.position = new Vector3(-50, 0 ,-50);
       //Instantiate(tnext,new Vector3(-50,0,-50), Quaternion.identity);
    }
}