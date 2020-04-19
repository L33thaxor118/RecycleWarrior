using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePowerups : MonoBehaviour
{

    public GameObject Speed;
    public GameObject HealthRestore;
    public GameObject Damage;
    public GameObject Bomb;
    public GameObject Ent;

    public float spawnInterval = 10f;

    private float timeLeft;

    public Transform SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            timeLeft = spawnInterval;
            float val = Random.value * 100f;
            if (val >= 0f && val <= 25f) {
                Instantiate(Speed, SpawnLocation);
            } else if (val > 25f && val <= 50f) {
                Instantiate(HealthRestore, SpawnLocation);
            } else if (val > 50f && val <= 75f) {
                Instantiate(Damage, SpawnLocation);
            } else if (val > 75f && val <= 90f) {
                Instantiate(Bomb, SpawnLocation);
            } else {
                Instantiate(Ent, SpawnLocation);
            }
        }
    }
}
