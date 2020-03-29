using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject spawnee;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started script");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject instance = Instantiate(spawnee, spawnPosition.position, spawnPosition.rotation);
            Rigidbody body = instance.GetComponent<Rigidbody>();
            body.AddRelativeForce(new Vector3(1,1,1000));
        }
    }
}
