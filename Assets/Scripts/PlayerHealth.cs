using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            die();
        }
    }
    
    void die() {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameOver");
    }

}
