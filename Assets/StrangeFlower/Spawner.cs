using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.P)) {
            Vector3 start = spawnPos.position;
            start.y += 2;
            GameObject seed = Instantiate(spawnee, start  , spawnPos.rotation);
            seed.GetComponent<Rigidbody>().useGravity = true;
            seed.GetComponent<Rigidbody>().AddForce(spawnPos.forward * 1000);
        } 
    }
}
