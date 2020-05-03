using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameObject player;
    public GameObject tree;
    public GameObject grass;
    public TerrainManager terrainManager;
    private float radius = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(player.transform.position);
    }

    // Update is called once per frame
    
    void Update()
    {   
       // Debug.Log(this.radius);
        Vector3 treeLocation = new Vector3(player.transform.position.x,player.transform.position.y, 0);
        Vector3 playerLocation = new Vector3(tree.transform.position.x,tree.transform.position.y, 0);
        if(Vector3.Distance(treeLocation, playerLocation) >= this.radius) {
            Debug.Log("I'm dead");
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            StartCoroutine(GrowBorder());
        }
        
        
    }

    IEnumerator GrowGrass() { 
        float currentTime = 0.0f; 
        do
        {
            Debug.Log("growed grass");
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= 5);
    }


    IEnumerator GrowBorder() {
        Vector3 originalScale = gameObject.transform.localScale;
        Debug.Log(originalScale);
        Vector3 destinationScale = new Vector3(originalScale.x + 30 , 100, originalScale.z + 30 );
        this.radius += 15;
         
        float currentTime = 0.0f;
         
        do
        {
             gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / 5);
             currentTime += Time.deltaTime;
             yield return null;
        } while (currentTime <= 5);
        
        terrainManager.LevelUp();
         

    }
}