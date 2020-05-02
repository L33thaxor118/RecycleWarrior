using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject Trash1;
    public GameObject Trash2;
    public GameObject Trash3;
    public GameObject Trash4;
    public GameObject Trash5;
    public GameObject Trash6;
    public GameObject Trash7;
    public GameObject Trash8;

    public WeaponSwitch weaponSwitch;

    public Inventory inventory;
    private toolGunUIControl control;
    private List<GameObject> trashes;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started script");
        control = GameObject.Find("Player").GetComponent<toolGunUIControl>();
        trashes = new List<GameObject>();
        trashes.Add(Trash1);
        trashes.Add(Trash2);
        trashes.Add(Trash3);
        trashes.Add(Trash4);
        trashes.Add(Trash5);
        trashes.Add(Trash6);
        trashes.Add(Trash7);
        trashes.Add(Trash8);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inventory.trashAmmo[control.activeIdx] > 0 && weaponSwitch.currentIdx == 0) {
            GameObject instance = Instantiate(trashes[control.activeIdx], spawnPosition.position, spawnPosition.rotation);
            Rigidbody body = instance.GetComponent<Rigidbody>();
            body.AddRelativeForce(new Vector3(1,1,1000));
            inventory.trashAmmo[control.activeIdx]--;
        }
    }
}
