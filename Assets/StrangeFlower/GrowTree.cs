using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree: MonoBehaviour
{
    public int grow = 0;
    
    public Transform spawnPos;
    public GameObject spawnee;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)){
            Debug.Log("pressed");
            grow = 1;
        }
        if(grow == 1 && transform.position.y < 3.5f) {
            
            Vector3 pos = gameObject.transform.position;
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f ,0.01f); 
            gameObject.transform.position =  new Vector3(pos.x, pos.y+0.025f, pos.z);
        }
        if(transform.localScale.y >= 1) {
            grow = 2;
        }
        if(grow == 2) {
            Destroy(gameObject);
            Vector3 newPosition = new Vector3(spawnPos.position.x, spawnPos.position.y - 2, spawnPos.position.z);
            Instantiate(spawnee, newPosition, spawnPos.rotation);
        }
         
        if(transform.position.y <= 0.625) {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.name == "Terrain" && grow == 0) {  
                grow = 1;
        }
    }

    void Destroy() {

        Debug.Log("aha");
    }
}
