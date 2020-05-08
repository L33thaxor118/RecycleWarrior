using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] trashAmmo = {0,0,0,0,0,0,0,0,0,0};
    public int lightAmmo = 0;
    public int mediumAmmo = 0;
    public int heavyAmmo = 0;

    public AudioSource pickupFX;


    // Start is called before the first frame update
    void Start()
    {
        trashAmmo = new int[10];
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
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[0]++;
        } else if (collision.gameObject.tag == "Computer") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[1]++;
        } else if (collision.gameObject.tag == "Chip") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[2]++;
        } else if (collision.gameObject.tag == "Can") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[3]++;
        } else if (collision.gameObject.tag == "PlasticBottle") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[4]++;
        } else if (collision.gameObject.tag == "Burger") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[5]++;
        } else if (collision.gameObject.tag == "Battery") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[6]++;
        } else if (collision.gameObject.tag == "Avocado") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[7]++;
        } else if (collision.gameObject.tag == "PearPowerup") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[8]++;
        } else if (collision.gameObject.tag == "KiwiPowerup") {
            Destroy(collision.gameObject);
            pickupFX.pitch = Random.Range(0.9f, 1.2f);
            pickupFX.Play();
            trashAmmo[9]++;
        }
    }
}
