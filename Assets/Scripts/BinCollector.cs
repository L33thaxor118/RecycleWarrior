using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BinCollector : MonoBehaviour
{
    private BoxCollider dropBox;
    private List<string> redAcceptTags = new List<string>(){"Can"};
<<<<<<< HEAD
    private List<string> blueAcceptTags = new List<string>(){"Computer", "Chip", "Battery"};
    private List<string> yellowAcceptTags = new List<string>(){"PlasticBottle"};
=======
    private List<string> redSpecialTags = new List<string>(){""};

    private List<string> blueAcceptTags = new List<string>(){ "Chip", "Battery"};
    private List<string> blueSpecialTags = new List<string>(){"Computer"};

    private List<string> yellowAcceptTags = new List<string>(){"PlasticBottle"};
    private List<string> yellowSpecialTags = new List<string>(){""};

>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de

    private ParticleSystem fire;
    private ParticleSystem trashbinYellowFX;
    private ParticleSystem trashbinRedFX;
    private ParticleSystem trashbinBlueFX;

    public int itemCount;

<<<<<<< HEAD
=======
    public int specialItemCount;

>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de


    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.Find("BurningField").GetComponent<ParticleSystem>();
        trashbinYellowFX = GameObject.Find("TrashbinYellowFX").GetComponent<ParticleSystem>();
        trashbinRedFX = GameObject.Find("TrashbinRedFX").GetComponent<ParticleSystem>();
        trashbinBlueFX = GameObject.Find("TrashbinBlueFX").GetComponent<ParticleSystem>();

        fire.Stop();
        trashbinYellowFX.Stop();
        trashbinRedFX.Stop();
        trashbinBlueFX.Stop();
        this.dropBox = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //maybe these can be set on every level?
        if (gameObject.name == "TrashbinRed") { //metal/aluminum
            if (redAcceptTags.Contains(other.gameObject.tag)) {
                trashbinRedFX.Play();
                itemCount++;
            } else {
                fire.Play();
            }
        } else if (gameObject.name == "TrashbinYellow") { //plastics
            if (yellowAcceptTags.Contains(other.gameObject.tag)) {
                trashbinYellowFX.Play();
                itemCount++;
            } else {
                fire.Play();
            }
        } else if (gameObject.name == "TrashbinBlue") { //electronics
<<<<<<< HEAD
            if (blueAcceptTags.Contains(other.gameObject.tag)) {
=======
            if (blueSpecialTags.Contains(other.gameObject.tag)) {
                specialItemCount++;
            }
            else if (blueAcceptTags.Contains(other.gameObject.tag)) {
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
                trashbinBlueFX.Play();
                itemCount++;
            } else {
                fire.Play();
            }
        }

    }
}
