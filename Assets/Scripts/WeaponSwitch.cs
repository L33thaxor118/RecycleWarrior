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
    private List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        weapons.Add(Tool);
        weapons.Add(Pistol1);
        weapons.Add(Pistol2);
        weapons.Add(Rifle1);
        weapons.Add(Rifle2);
        weapons.Add(Sniper1);
        weapons.Add(Sniper2);

        currentIdx = 0;
        foreach (GameObject weapon in weapons) {
            weapon.SetActive(false);
        }
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
}
