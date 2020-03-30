using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolGunUIControl : MonoBehaviour
{
    private List<GameObject> ammoPreviews;
    public int activeIdx;
    private Text ammoCounter;

    private Inventory inventory;
    // Start is called before the first frame update

    // private void setFullOpacity(Image img) {
    //     Color tempColor = img.color;
    //     tempColor.a = 1f;
    //     img.color = tempColor;
    // }

    // private void setHalfOpacity(Image img) {
    //     Color tempColor = img.color;
    //     tempColor.a = 0.5f;
    //     img.color = tempColor;
    // }
    void Start()
    {
        activeIdx = 0;
        ammoPreviews = new List<GameObject>(GameObject.FindGameObjectsWithTag("ToolAmmoPreview"));
        ammoCounter = GameObject.Find("AmmoCounter").GetComponent<Text>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        foreach(GameObject panel in ammoPreviews) {
            panel.SetActive(false);
        }
        ammoPreviews[activeIdx].SetActive(true);
        ammoCounter.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        int oldIdx = activeIdx;
        if (Input.GetKeyDown(KeyCode.U)) {
            activeIdx = (activeIdx + 1) % ammoPreviews.Count;
        } else if (Input.GetKeyDown(KeyCode.J)) {
            activeIdx = (Mathf.Abs(activeIdx - 1)) % ammoPreviews.Count;

        }
        ammoPreviews[oldIdx].SetActive(false);
        ammoPreviews[activeIdx].SetActive(true);
        ammoCounter.text = inventory.trashAmmo[activeIdx].ToString();
    }
}
