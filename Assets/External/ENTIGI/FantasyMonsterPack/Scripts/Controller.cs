using UnityEngine;
using UnityEngine.UI;


public class Controller : MonoBehaviour {
    public int selectNum =1;
    private Animator anim;
    private bool rotL = false;
    private bool rotR = false;
    public Text stateText;
    private Camera cam;
    private Transform currentTrans;
    public Animator cha1_Anim;
    public Animator cha2_Anim;
    public Animator cha3_Anim;
    public Animator cha4_Anim;
    
    public GameObject cha1_obj;
    public GameObject cha2_obj;
    public GameObject cha3_obj;
    public GameObject cha4_obj;
    public Camera cha1_Cam;
    public Camera cha2_Cam;
    public Camera cha3_Cam;
    public Camera cha4_Cam;
    void Start()
    {
        this.anim = cha1_Anim;
        this.cam = cha1_Cam;
        this.currentTrans = cha1_obj.transform;
    }
    public void ChangeCha()
    {
        if(selectNum <4)
        {
            selectNum++;
            stateText.text = "Idle";
        }
        else
        {
            selectNum =1;    
            stateText.text = "Idle";
        }
        switch (selectNum)
        {
            case 1:
            {
             cha1_obj.SetActive(true);
             cha2_obj.SetActive(false);
             cha3_obj.SetActive(false);
             cha4_obj.SetActive(false);
             this.anim = cha1_Anim;
             this.cam = cha1_Cam;  
             this.currentTrans = cha1_obj.transform; 
            }
            break;
            case 2:
            {
             cha1_obj.SetActive(false);
             cha2_obj.SetActive(true);
             cha3_obj.SetActive(false);
             cha4_obj.SetActive(false);
             this.anim = cha2_Anim;
             this.cam = cha2_Cam;
             this.currentTrans = cha2_obj.transform;
            }
            break;
            case 3:
            {
             cha1_obj.SetActive(false);
             cha2_obj.SetActive(false);
             cha3_obj.SetActive(true);
             cha4_obj.SetActive(false);
             this.anim = cha3_Anim;
             this.cam = cha3_Cam;
             this.currentTrans = cha3_obj.transform;
            }
            break;
            case 4:
            {
             cha1_obj.SetActive(false);
             cha2_obj.SetActive(false);
             cha3_obj.SetActive(false);
             cha4_obj.SetActive(true);
             this.anim = cha4_Anim;
             this.cam = cha4_Cam;
             this.currentTrans = cha4_obj.transform;
            }
            break;
        }
        
    }
    void Update()
    {
        //캐릭터 회전
        if (rotL == true)
        {
            cam.transform.RotateAround(currentTrans.position, Vector3.up, 90 * Time.deltaTime);
        }
        if (rotR == true)
        {
            cam.transform.RotateAround(currentTrans.position, Vector3.up, -90 * Time.deltaTime);           
        }
    }
    public void RotateLCharacter()
    {
        rotR = false;
        rotL = !rotL;
    }
    public void RotateRCharacter()
    {
        rotL = false;
        rotR = !rotR;
    }
    public void Walk()
    {
        if(anim.GetBool("Death") == true)
        {
            anim.Play("Walk");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", true);

        stateText.text = "Walk";
    }
    public void Run()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("Run");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", true);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        stateText.text = "Run";
    }
    public void Idle()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("Idle");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Walk", false);
        stateText.text = "Idle";
    }
    public void TurnLeft()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("WalkLeft");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", true);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        stateText.text = "Turn Left";
    }
    public void TurnRight()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("WalkRight");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", true);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        stateText.text = "Turn Right";
    }
    public void Attack()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("Attack");
        }
        anim.SetBool("Attack", true);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        stateText.text = "Attack";
    }
    public void Death()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Death", true);
        anim.SetTrigger("DeathTrigger");
        stateText.text = "Death";
    }
    public void Hit()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("Hit");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", true);
        anim.SetBool("Dash", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        stateText.text = "Hit";
    }
    public void Dash()
    {
        if (anim.GetBool("Death") == true)
        {
            anim.Play("Dash");
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.SetBool("TurnLeft", false);
        anim.SetBool("TurnRight", false);
        anim.SetBool("Death", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Dash", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        stateText.text = "Dash";
    }
    public void openURL()
    {
        Application.OpenURL("http://www.entigi.net");
    }
}
