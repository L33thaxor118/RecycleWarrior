using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private int currentIdx;
    private List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        weapons.Add(GameObject.Find("Assault"));
        weapons.Add(GameObject.Find("Tool"));
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
            currentIdx = (Mathf.Abs(currentIdx - 1)) % weapons.Count;

        }
        weapons[oldIdx].SetActive(false);
        weapons[currentIdx].SetActive(true);
    }
}
