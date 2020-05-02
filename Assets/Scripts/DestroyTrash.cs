using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour
{
    public string test;
    // Start is called before the first frame update
    void Start()
    {
        test="hi";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerRigidBody") {
            Destroy(this.gameObject);
        }
    }
}
