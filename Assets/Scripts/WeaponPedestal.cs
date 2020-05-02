using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPedestal : MonoBehaviour
{

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

    }

    // Update is called once per frame
    void Update()
    {
        if (redBinCollector.itemCount == 3) {
            pistol2.transform.position = Vector3.Lerp (pistol2.transform.position, new Vector3 (pistol2.transform.position.x, 1.2f, pistol2.transform.position.z), Time.deltaTime * 0.7f);
        }
    }
}
