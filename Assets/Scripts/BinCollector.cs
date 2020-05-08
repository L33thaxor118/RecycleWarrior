using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BinCollector : MonoBehaviour
{
    private BoxCollider dropBox;
    private List<string> redAcceptTags = new List<string>(){"Can"};
    private List<string> redSpecialTags = new List<string>(){"Coke"};

    private List<string> blueAcceptTags = new List<string>(){"Battery"};
    private List<string> blueSpecialTags = new List<string>(){"Chip"};

    private List<string> yellowAcceptTags = new List<string>(){"PlasticBottle"};
    private List<string> yellowSpecialTags = new List<string>(){"Milk"};


    private ParticleSystem fire;
    private ParticleSystem trashbinYellowFX;
    private ParticleSystem trashbinRedFX;
    private ParticleSystem trashbinBlueFX;

    public int itemCount;

    public int specialItemCount;



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
            } 
            else if (redSpecialTags.Contains(other.gameObject.tag)) {
                trashbinRedFX.Play();
                specialItemCount++;
            }
            else {
                fire.Play();
            }
        } else if (gameObject.name == "TrashbinYellow") { //plastics
            if (yellowAcceptTags.Contains(other.gameObject.tag)) {
                trashbinYellowFX.Play();
                itemCount++;
            } 
            else if (yellowSpecialTags.Contains(other.gameObject.tag)) {
                trashbinYellowFX.Play();
                specialItemCount++;
            }
            else {
                fire.Play();
            }
        } else if (gameObject.name == "TrashbinBlue") { //electronics
            if (blueSpecialTags.Contains(other.gameObject.tag)) {
                trashbinBlueFX.Play();
                specialItemCount++;
            }
            else if (blueAcceptTags.Contains(other.gameObject.tag)) {
                trashbinBlueFX.Play();
                itemCount++;
            } else {
                fire.Play();
            }
        }

    }
}
