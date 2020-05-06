using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BlinkingText : MonoBehaviour
{
    public float timer;
    private TextMeshProUGUI textmesh;
    // Update is called once per frame

        
    void Update()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        timer += Time.deltaTime;

        if(timer >= 0.5)
        {
            textmesh.enabled = true;
        }

        if (timer >= 1)
        {
            textmesh.enabled = false;
            timer = 0;
        }
    }
}
