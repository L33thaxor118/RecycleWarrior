using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISystem : MonoBehaviour
{

    public WaveSystem waveSystem;
    public Inventory inventory;
    public Target treeTarget;
    public PlayerHealth playerHealth;
    public Reticle crossHairs;
    public WeaponSwitch weaponSwitch;

    private Gun currentGun;

    public Text bulletCount;

    public Text robotCount;

    public Text level;

    public Slider healthSlider;

    public Slider treeSlider;




    // Start is called before the first frame update
    void Start()
    {
        healthSlider.minValue = 0;
        healthSlider.maxValue = playerHealth.health;
        treeSlider.minValue = 0;
        treeSlider.maxValue = treeTarget.health;
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level " + waveSystem.level.ToString();
        int currentGunIdx = weaponSwitch.currentIdx;
        if (weaponSwitch.currentIdx != 0) {
            float spreadFactor = weaponSwitch.weapons[currentGunIdx].GetComponent<Gun>().spreadFactor;
            crossHairs.restingSize = spreadFactor;
            crossHairs.currentSize = spreadFactor + weaponSwitch.weapons[currentGunIdx].GetComponent<Gun>().spread ;
            if (currentGunIdx == 1) {
                bulletCount.text = inventory.lightAmmo.ToString();
            } else if (currentGunIdx == 2) {
                bulletCount.text = inventory.mediumAmmo.ToString();
            } else if (currentGunIdx == 3) {
                bulletCount.text = inventory.heavyAmmo.ToString();
            }
        }
        healthSlider.value = playerHealth.health;
        treeSlider.value = treeTarget.health;
        robotCount.text = waveSystem.robotsRemaining.ToString();
    }
}
