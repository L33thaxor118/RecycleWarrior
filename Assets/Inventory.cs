using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] trashAmmo;

    // Start is called before the first frame update
    void Start()
    {
        trashAmmo = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //THESE NEED TO BE IN SAME ORDER AS UI PREVIEWS
        if (collision.gameObject.tag == "Taco") {
            DestroyTrash itemScript = collision.gameObject.GetComponent<DestroyTrash>();
            Debug.Log("collided with" + itemScript.test);
            trashAmmo[0]++;
        } else if (collision.gameObject.tag == "Computer") {
            trashAmmo[1]++;
        } else if (collision.gameObject.tag == "Chip") {
            trashAmmo[2]++;
        } else if (collision.gameObject.tag == "Can") {
            trashAmmo[3]++;
        } else if (collision.gameObject.tag == "PlasticBottle") {
            trashAmmo[4]++;
        } else if (collision.gameObject.tag == "Burger") {
            trashAmmo[5]++;
        } else if (collision.gameObject.tag == "Battery") {
            trashAmmo[6]++;
        } else if (collision.gameObject.tag == "Avocado") {
            trashAmmo[7]++;
        }
    }
}
