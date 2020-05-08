using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    private float bananaTimeRemaining = 0f;
    private float strawberryTimeRemaining = 0f;

    public float powerupTime = 15f;
    public float speedBoost = 20f;
    public float jumpBoost = 5f;

    private float originalSpeed;
    private float originalJump;

    public AudioSource pickupFX;

    public PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = playerMovement.speed;
        originalJump = playerMovement.jumpHeight;

    }

    // Update is called once per frame
    void Update()
    {
        if (bananaTimeRemaining > 0f) {

        } else {

        }

        if (strawberryTimeRemaining <= 0f) {
            strawberryTimeRemaining = 0f;
            playerMovement.doubleJump = false;
            playerMovement.speed = originalSpeed;
            playerMovement.jumpHeight = originalJump;
        } else {
            strawberryTimeRemaining -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ApplePowerup") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            //regenerate health
        } else if (collision.gameObject.tag == "BananaPowerup") {
            Destroy(collision.gameObject);
            pickupFX.Play();
        } else if (collision.gameObject.tag == "StrawberryPowerup") {
            Destroy(collision.gameObject);
            pickupFX.Play();
            strawberryTimeRemaining += powerupTime;
            playerMovement.doubleJump = true;
            playerMovement.speed = originalSpeed + speedBoost;
            playerMovement.jumpHeight = originalJump + jumpBoost;
        }
    }
}
