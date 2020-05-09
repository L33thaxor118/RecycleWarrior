using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponSwitch : MonoBehaviour
{

    public GameObject Tool;
    public GameObject Pistol1;
    public GameObject Pistol2;
    public GameObject Rifle1;
    public GameObject Rifle2;
    public GameObject Sniper1;
    public GameObject Sniper2;
    public int currentIdx;
    public List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        Tool.SetActive(false);
        Pistol1.SetActive(false);
        Pistol2.SetActive(false);
        Rifle1.SetActive(false);
        Rifle2.SetActive(false);
        Sniper1.SetActive(false);
        Sniper2.SetActive(false);
        weapons.Add(Tool);
        weapons.Add(Pistol1);
        // weapons.Add(Pistol2);
        // weapons.Add(Rifle1);
        // weapons.Add(Rifle2);
        // weapons.Add(Sniper1);
        // weapons.Add(Sniper2);

        currentIdx = 0;
        weapons[currentIdx].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int oldIdx = currentIdx;
        if (Input.GetKeyDown(KeyCode.I))
        {
            currentIdx = (currentIdx + 1) % weapons.Count;
            weapons[oldIdx].SetActive(false);
            weapons[currentIdx].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.K)) {
            if (currentIdx == 0) currentIdx = weapons.Count;
            currentIdx = (currentIdx - 1) % weapons.Count;
            weapons[oldIdx].SetActive(false);
            weapons[currentIdx].SetActive(true);
        }
    }

    public void addPistol2() {
        //weapons.Add(Pistol2);
        if (currentIdx == 1) {
            Destroy(weapons[1]);
        }
        weapons[1] = Pistol2;
    }

    public void addRifle1() {
        weapons.Add(Rifle1);
    }

    public void addRifle2() {
        if (currentIdx == 2) {
            Destroy(weapons[2]);
        }
        weapons[2] = Rifle2;
    }

    public void addSniper1() {
        weapons.Add(Sniper1);
    }

    public void addSniper2() {
        if (currentIdx == 3) {
            Destroy(weapons[3]);
        }
        weapons[3] = Sniper2;
    }

}
