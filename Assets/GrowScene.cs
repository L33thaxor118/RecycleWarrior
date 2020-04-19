using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScene : MonoBehaviour
{
    public GameObject player;
    public GameObject tree;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(player.transform.position);
    }

    // Update is called once per frame
    
    void Update()
    {   
        Debug.Log(Vector3.Distance(player.transform.position, tree.transform.position));
        Debug.Log(player.transform.position);

        if(Vector3.Distance(player.transform.position, tree.transform.position) > 20.0f) {
            StartCoroutine(GrowBorder());
        }
        
    }


    IEnumerator GrowBorder() {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(originalScale.x + 20,20, originalScale.z + 20);
         
        float currentTime = 0.0f;
         
        do
        {
             gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / 5);
             currentTime += Time.deltaTime;
             yield return null;
        } while (currentTime <= 2);
         

    }
}
