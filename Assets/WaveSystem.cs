using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    public int level = 0;
    public int robotsRemaining = 10;
    public RobotSpawner spawner;

    public WeaponPedestal weapons;
    
    private float timeTillNextSpawn;

    public float spawnInterval = 10f;

    public float restTime = 15f;
    private float timeTillNextWave;

    private int robotsSpawnedThisLevel = 0;

    bool interim = false;


    // Start is called before the first frame update
    void Start()
    {
        timeTillNextSpawn = spawnInterval;
        timeTillNextWave = restTime;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (robotsRemaining <= 0) {
            StartNewWave();
        }

        timeTillNextSpawn -= Time.deltaTime;

        if (timeTillNextSpawn <= 0 && (robotsSpawnedThisLevel < level*10) && !interim) {
            if (!weapons.rifle1Taken) {
                robotsSpawnedThisLevel += spawner.SpawnStage1();
            } else if (!weapons.sniper1Taken) {
                spawner.SpawnStage2();
            } else {
                spawner.SpawnStage3();
            }
            timeTillNextSpawn = spawnInterval;
        }
    }

    void StartNewWave() {
        timeTillNextWave -= Time.deltaTime;
        interim = true;
        if (timeTillNextWave <= 0) {
            level++;
            timeTillNextWave = restTime;
            robotsRemaining = level*10;
            robotsSpawnedThisLevel = 0;
            interim = false;
        }
    }
}
