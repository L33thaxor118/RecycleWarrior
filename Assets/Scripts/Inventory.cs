using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] trashAmmo = {0,0,0,0,0,0,0,0};
    public int pistolAmmo = 0;
    public int rifleAmmo = 0;
    public int sniperAmmo = 0;


    // Start is called before the first frame update
    void Start()
    {
        trashAmmo = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision on trigger!");
        //THESE NEED TO BE IN SAME ORDER AS UI PREVIEWS
        if (collision.gameObject.tag == "Taco") {
            Destroy(collision.gameObject);
            trashAmmo[0]++;
        } else if (collision.gameObject.tag == "Computer") {
            Destroy(collision.gameObject);
            trashAmmo[1]++;
        } else if (collision.gameObject.tag == "Chip") {
            Destroy(collision.gameObject);
            trashAmmo[2]++;
        } else if (collision.gameObject.tag == "Can") {
            Destroy(collision.gameObject);
            trashAmmo[3]++;
        } else if (collision.gameObject.tag == "PlasticBottle") {
            Destroy(collision.gameObject);
            trashAmmo[4]++;
        } else if (collision.gameObject.tag == "Burger") {
            Destroy(collision.gameObject);
            trashAmmo[5]++;
        } else if (collision.gameObject.tag == "Battery") {
            Destroy(collision.gameObject);
            trashAmmo[6]++;
        } else if (collision.gameObject.tag == "Avocado") {
            Destroy(collision.gameObject);
            trashAmmo[7]++;
        }
    }
}
