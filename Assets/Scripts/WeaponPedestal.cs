using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestal : MonoBehaviour
{

<<<<<<< HEAD
    private GameObject crystalIndicator;
    private BinCollector redBinCollector;
    private BinCollector blueBinCollector;
    private BinCollector yellowBinCollector;

    private GameObject pistol2;
    private GameObject rifle1;
    private GameObject rifle2;
    private GameObject sniper1;
    private GameObject sniper2;

    private Time upgradeStartTime;

    // Start is called before the first frame update
    void Start()
    {
        redBinCollector = GameObject.Find("TrashbinRed").GetComponent<BinCollector>();
        blueBinCollector = GameObject.Find("TrashbinBlue").GetComponent<BinCollector>();
        yellowBinCollector = GameObject.Find("TrashbinYellow").GetComponent<BinCollector>();
        crystalIndicator = GameObject.Find("SwitchCrystal");

        pistol2 = GameObject.Find("PistolUpgrade2");
        rifle1 = GameObject.Find("RifleUpgrade1");
        rifle2 = GameObject.Find("RifleUpgrade2");
        sniper1 = GameObject.Find("SniperUpgrade1");
        sniper2 = GameObject.Find("SniperUpgrade2");
=======
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

    // Start is called before the first frame update
    void Start()
    {
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (redBinCollector.itemCount == 3) {
            pistol2.transform.position = Vector3.Lerp (pistol2.transform.position, new Vector3 (pistol2.transform.position.x, 1.2f, pistol2.transform.position.z), Time.deltaTime * 0.7f);
        }
    }
=======
        if (yellowBinCollector.itemCount >= 3 && !occupied) {
            occupied = true;
            currentPickup = "LightAmmo";
            StartCoroutine(MoveObject(lightAmmo.transform, lightAmmo.transform.position, new Vector3 (lightAmmo.transform.position.x, 1.2f, lightAmmo.transform.position.z), 3f));
            redBinCollector.itemCount -= 3;
        }
        else if (blueBinCollector.itemCount >= 3 && !occupied) {
            occupied = true;
            currentPickup = "MediumAmmo";
            StartCoroutine(MoveObject(medAmmo.transform, medAmmo.transform.position, new Vector3 (medAmmo.transform.position.x, 1.2f, medAmmo.transform.position.z), 3f));
            redBinCollector.itemCount -= 3;
        }
        else if (redBinCollector.itemCount >= 3 && !occupied) {
            occupied = true;
            currentPickup = "HeavyAmmo";
            StartCoroutine(MoveObject(heavyAmmo.transform, heavyAmmo.transform.position, new Vector3 (heavyAmmo.transform.position.x, 1.2f, heavyAmmo.transform.position.z), 3f));
            redBinCollector.itemCount -= 3;
        } else if (blueBinCollector.specialItemCount >= 5) {
            occupied = true;
            currentPickup = "RifleUpgrade1";
            StartCoroutine(MoveObject(rifle1.transform, rifle1.transform.position, new Vector3 (rifle1.transform.position.x, 1.2f, rifle1.transform.position.z), 3f));
            blueBinCollector.specialItemCount -= 5;
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
        Debug.Log("picked up some shit");
        occupied = false;
        switch(currentPickup) {
            case "LightAmmo":
            playerInventory.lightAmmo += 20;
            lightAmmo.transform.position = startPosition.position;
            break;
            case "MediumAmmo":
            playerInventory.mediumAmmo += 20;
            medAmmo.transform.position = startPosition.position;
            break;
            case "HeavyAmmo":
            playerInventory.heavyAmmo += 20;  
            heavyAmmo.transform.position = startPosition.position;
            break;
            case "PistolUpgrade2":
            other.gameObject.GetComponent<WeaponSwitch>().addPistol2();
            pistol2.transform.position = startPosition.position;
            break;
            case "RifleUpgrade1":
            other.gameObject.GetComponent<WeaponSwitch>().addRifle1();
            rifle1.transform.position = startPosition.position;
            break;
        }
    }

    
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
}
