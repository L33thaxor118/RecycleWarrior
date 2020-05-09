using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestal : MonoBehaviour
{

    public GameObject crystalIndicator;
    public BinCollector redBinCollector;
    public BinCollector blueBinCollector;
    public BinCollector yellowBinCollector;

    public GameObject pistol2;
    public GameObject rifle1;
    public GameObject rifle2;
    public GameObject sniper1;
    public GameObject sniper2;

    public GameObject lightAmmo;

    public GameObject medAmmo;
    public GameObject heavyAmmo;
    
    private Time upgradeStartTime;

    private bool occupied;

    public Inventory playerInventory;

    private string currentPickup;

    public Transform startPosition;

    public bool pistol2Taken;
    public bool rifle1Taken;
    public bool rifle2Taken;
    public bool sniper1Taken;
    public bool sniper2Taken;

    public AudioSource pickupSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (yellowBinCollector.itemCount >= 3 && !occupied) {
            occupied = true;
            currentPickup = "LightAmmo";
            StartCoroutine(MoveObject(lightAmmo.transform, lightAmmo.transform.position, new Vector3 (lightAmmo.transform.position.x, 1.2f, lightAmmo.transform.position.z), 3f));
            yellowBinCollector.itemCount -= 3;
        }
        else if (blueBinCollector.itemCount >= 3 && !occupied) {
            occupied = true;
            currentPickup = "MediumAmmo";
            StartCoroutine(MoveObject(medAmmo.transform, medAmmo.transform.position, new Vector3 (medAmmo.transform.position.x, 1.2f, medAmmo.transform.position.z), 3f));
            blueBinCollector.itemCount -= 3;
        }
        else if (redBinCollector.itemCount >= 3 && !occupied) {
            occupied = true;
            currentPickup = "HeavyAmmo";
            StartCoroutine(MoveObject(heavyAmmo.transform, heavyAmmo.transform.position, new Vector3 (heavyAmmo.transform.position.x, 1.2f, heavyAmmo.transform.position.z), 3f));
            redBinCollector.itemCount -= 3;
        } else if (blueBinCollector.specialItemCount >= 5) {
            if (!rifle1Taken) {
                occupied = true;
                rifle1Taken = true;
                currentPickup = "RifleUpgrade1";
                StartCoroutine(MoveObject(rifle1.transform, rifle1.transform.position, new Vector3 (rifle1.transform.position.x, 1.2f, rifle1.transform.position.z), 3f));
                blueBinCollector.specialItemCount -= 5;
            } else if (!rifle2Taken) {
                occupied = true;
                rifle2Taken = true;
                currentPickup = "RifleUpgrade2";
                StartCoroutine(MoveObject(rifle2.transform, rifle2.transform.position, new Vector3 (rifle2.transform.position.x, 1.2f, rifle2.transform.position.z), 3f));
                blueBinCollector.specialItemCount -= 5;
            } 
        } else if (redBinCollector.specialItemCount >= 5 && !occupied) {
            if (!sniper1Taken) {
                occupied = true;
                sniper1Taken = true;
                currentPickup = "SniperUpgrade1";
                StartCoroutine(MoveObject(sniper1.transform, sniper1.transform.position, new Vector3 (sniper1.transform.position.x, 1.2f, sniper1.transform.position.z), 3f));
                redBinCollector.specialItemCount -= 5;
            } else if (!sniper2Taken) {
                occupied = true;
                sniper2Taken = true;
                currentPickup = "SniperUpgrade2";
                StartCoroutine(MoveObject(sniper2.transform, sniper2.transform.position, new Vector3 (sniper2.transform.position.x, 1.2f, sniper2.transform.position.z), 3f));
                redBinCollector.specialItemCount -= 5;
            }

        } else if (yellowBinCollector.specialItemCount >= 5 && !occupied) {
            if (!pistol2Taken) {
                occupied = true;
                pistol2Taken = true;
                currentPickup = "PistolUpgrade2";
                StartCoroutine(MoveObject(pistol2.transform, pistol2.transform.position, new Vector3 (pistol2.transform.position.x, 1.2f, pistol2.transform.position.z), 3f));
                yellowBinCollector.specialItemCount -= 5;
            }
        }
        
    }

    IEnumerator MoveObject (Transform objectTransform, Vector3 start, Vector3 end, float time) {
        float i = 0.0f;
        float rate = 1.0f/time;
        while (i < 1.0) {
            Debug.Log("while");
            i += Time.deltaTime * rate;
            objectTransform.position = Vector3.Lerp(start, end, i);
            yield return null; 
        }
    }

    void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) {
            return;
        }
        switch(currentPickup) {
            case "LightAmmo":
            pickupSound.Play();
            playerInventory.lightAmmo += 20;
            lightAmmo.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "MediumAmmo":
            pickupSound.Play();
            playerInventory.mediumAmmo += 50;
            medAmmo.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "HeavyAmmo":
            pickupSound.Play();
            playerInventory.heavyAmmo += 10;  
            heavyAmmo.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "PistolUpgrade2":
            pickupSound.Play();
            other.gameObject.GetComponent<WeaponSwitch>().addPistol2();
            pistol2.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "RifleUpgrade1":
            pickupSound.Play();
            other.gameObject.GetComponent<WeaponSwitch>().addRifle1();
            rifle1.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "RifleUpgrade2":
            pickupSound.Play();
            other.gameObject.GetComponent<WeaponSwitch>().addRifle2();
            rifle2.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "SniperUpgrade1":
            pickupSound.Play();
            other.gameObject.GetComponent<WeaponSwitch>().addSniper1();
            sniper1.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
            case "SniperUpgrade2":
            pickupSound.Play();
            other.gameObject.GetComponent<WeaponSwitch>().addSniper2();
            sniper2.transform.position = startPosition.position;
            occupied = false;
            currentPickup = "";
            break;
        }
    }

    
}
