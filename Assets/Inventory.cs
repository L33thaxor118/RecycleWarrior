using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "cannedfood") {
            can_pickup itemScript = collision.gameObject.GetComponent<can_pickup>();
            Debug.Log("collided with" + itemScript.test);
        }
    }
}
