using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatApple : MonoBehaviour
{
    public int end = 0;

    public GameObject apple;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end == 1) {
            Destroy(apple);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {   
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player") {  
            Debug.Log("eating");
            end = 1;
        }
    }
}
