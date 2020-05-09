using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreePowerups : MonoBehaviour
{

    public GameObject Speed;
    public GameObject HealthRestore;
    public GameObject Bomb;
    public GameObject Ent;

    public float spawnInterval = 10f;

    private float timeLeft;

    public Transform SpawnLocation;

    public GameObject regenFX;

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
            if (val >= 0f && val <= 20f) {
                Instantiate(Speed, SpawnLocation);
            } else if (val > 20f && val <= 40f) {
                Instantiate(HealthRestore, SpawnLocation);
            } else if (val > 40f && val <= 60f) {
                Instantiate(Bomb, SpawnLocation);
            } else if (val > 60f && val <= 80f) {
                Instantiate(Bomb, SpawnLocation);
            } else {
                Instantiate(Ent, SpawnLocation);
            }
        }
        if (gameObject.GetComponent<Target>().isDead) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Avocado") || other.gameObject.CompareTag("Burger")) {
            gameObject.GetComponent<Target>().health += 30;
            regenFX.GetComponent<ParticleSystem>().Play();
            Destroy(other);
        }
    }
}
