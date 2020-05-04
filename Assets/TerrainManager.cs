using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainManager : MonoBehaviour
{   
    private int level;
    public Transform grassManager;
    // Start is called before the first frame update
    void Start()
    {  
        this.level = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) {
            this.level += 1;
            Debug.Log(" Currently on Level 1");
            Debug.Log(level);
            LevelUp();
        }        
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
        var i = 0;
        foreach (Transform item in grassManager)
        {

            GrowTree f = item.gameObject.GetComponent<GrowTree>();
            i+= 1;
            f.GrowUp();
            if(i >= 3) {
                break;
            } 
        }



    }
}
