using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolGunUIControl : MonoBehaviour
{
    private List<GameObject> miniboxes;
    private int activeIdx;
    // Start is called before the first frame update

    private void setFullOpacity(Image img) {
        Color tempColor = img.color;
        tempColor.a = 1f;
        img.color = tempColor;
    }

    private void setHalfOpacity(Image img) {
        Color tempColor = img.color;
        tempColor.a = 0.5f;
        img.color = tempColor;
    }
    void Start()
    {
        activeIdx = 0;
        miniboxes = new List<GameObject>(GameObject.FindGameObjectsWithTag("ToolAmmo"));
        foreach(GameObject panel in miniboxes) {
            setHalfOpacity(panel.GetComponent<Image>());
        }
        setFullOpacity(miniboxes[activeIdx].GetComponent<Image>());
    }

    // Update is called once per frame
    void Update()
    {
        int oldIdx = activeIdx;
        if (Input.GetKeyDown(KeyCode.U)) {
            activeIdx = (activeIdx + 1) % miniboxes.Count;
        } else if (Input.GetKeyDown(KeyCode.J)) {
            activeIdx = (Mathf.Abs(activeIdx - 1)) % miniboxes.Count;

        }
        setHalfOpacity(miniboxes[oldIdx].GetComponent<Image>());
        setFullOpacity(miniboxes[activeIdx].GetComponent<Image>());

    }
}
