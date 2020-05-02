using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.P)) {
            Instantiate(spawnee, new Vector3(spawnPos.position.x + 20, 0.62f, spawnPos.position.z), spawnPos.rotation);
        }
    }
}
