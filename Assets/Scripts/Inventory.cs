using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
<<<<<<< HEAD
    public int[] trashAmmo = {0,0,0,0,0,0,0,0};
    public int pistolAmmo = 0;
    public int rifleAmmo = 0;
    public int sniperAmmo = 0;
=======
    public int[] trashAmmo = {0,0,0,0,0,0,0,0,0,0};
    public int lightAmmo = 0;
    public int mediumAmmo = 0;
    public int heavyAmmo = 0;

    public AudioSource pickupFX;
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        trashAmmo = new int[8];
=======
        trashAmmo = new int[10];
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
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
<<<<<<< HEAD
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
=======
            pickupFX.Play();
            trashAmmo[0]++;
        } else if (collision.gameObject.tag == "Computer") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[1]++;
        } else if (collision.gameObject.tag == "Chip") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[2]++;
        } else if (collision.gameObject.tag == "Can") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[3]++;
        } else if (collision.gameObject.tag == "PlasticBottle") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[4]++;
        } else if (collision.gameObject.tag == "Burger") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[5]++;
        } else if (collision.gameObject.tag == "Battery") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[6]++;
        } else if (collision.gameObject.tag == "Avocado") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[7]++;
        } else if (collision.gameObject.tag == "PearPowerup") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[8]++;
        } else if (collision.gameObject.tag == "KiwiPowerup") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            trashAmmo[9]++;
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
        }
    }
}
