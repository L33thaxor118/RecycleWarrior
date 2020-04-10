using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int currentIdx;
    private List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        weapons.Add(GameObject.Find("Tool"));
        weapons.Add(GameObject.Find("Pistol1"));
        weapons.Add(GameObject.Find("Pistol2"));
        weapons.Add(GameObject.Find("Rifle1"));
        weapons.Add(GameObject.Find("Rifle2"));
        weapons.Add(GameObject.Find("Sniper1"));
        weapons.Add(GameObject.Find("Sniper2"));

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
        }
        else if (Input.GetKeyDown(KeyCode.K)) {
            if (currentIdx == 0) currentIdx = weapons.Count;
            currentIdx = (currentIdx - 1) % weapons.Count;

        }
        weapons[oldIdx].SetActive(false);
        weapons[currentIdx].SetActive(true);
    }
}
