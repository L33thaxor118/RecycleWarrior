using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class waveConnection : MonoBehaviour
{

    public Target robotTarget;
    private bool deathRegistered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (robotTarget.isDead && !deathRegistered) {
            deathRegistered = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<WaveSystem>().robotsRemaining--;
        }
    }
}
