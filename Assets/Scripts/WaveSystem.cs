using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSystem : MonoBehaviour
{

    public int level = 0;
    public int robotsRemaining = 0;
    public RobotSpawner spawner;

    public WeaponPedestal weapons;
    
    private float timeTillNextSpawn;

    public float spawnInterval = 10f;

    public float restTime = 30f;
    private float timeTillNextWave;

    private int robotsSpawnedThisLevel = 0;

    bool interim = false;

    public GrowScene growScene;


    // Start is called before the first frame update
    void Start()
    {
        timeTillNextSpawn = spawnInterval;
        timeTillNextWave = restTime;
        level = 0;
        robotsRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (robotsRemaining <= 0) {
            Debug.Log("starting new wave");
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
        if (level >= 1) {
            growScene.Grow();
        }
        //grow terrain;
        if (timeTillNextWave <= 0) {
            level++;
            if (level == 11) {
                SceneManager.LoadScene("MainMenu");
            }
            timeTillNextWave = restTime;
            robotsRemaining = level*10;
            robotsSpawnedThisLevel = 0;
            interim = false;
        }
    }
}
