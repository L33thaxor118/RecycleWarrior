using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
  [SerializeField] private Animator myAnimationController;
    public float lookRadius = 5f;
    Transform target1;
    Transform target2;
    Transform target3;

    public float distanceEnt = 200f;

    private int deadTime = 0;

    public Collider mainCollider;
    public Rigidbody mainRigidBody;

    public Target target;

    public NavMeshAgent agent;



    public AudioSource walk;
    public AudioSource hitPlayer;
    // public AudioSource hitWood;
    public AudioSource spawn;
    public AudioSource death;
    private int deathCounter = 0;
    // private bool hurtPlayer;

    void Start(){
      target1 = GameObject.FindGameObjectWithTag("Player").transform;
      spawn.Play();
    }

    void Update(){

      if (myAnimationController.GetBool("Hit") == false && walk.isPlaying == false && deathCounter == 0)
      {
        walk.Play();
        hitPlayer.Stop();
        // hitWood.Stop();
      }

      if(myAnimationController.GetBool("Hit") == true
        && deathCounter == 0 && hitPlayer.isPlaying == false)
      {
        walk.Stop();
        hitPlayer.Play();
      }

      if (target.isDead) {
        mainCollider.enabled = false;
        agent.enabled = false;
        mainRigidBody.detectCollisions = false;
        if(death.isPlaying == false && deathCounter == 0)
        {
          walk.Stop();
          hitPlayer.Stop();
          death.Play();
          deathCounter++;
        }
          myAnimationController.enabled = false;
          Destroy(this.gameObject,2);
        return;
      }

      float distancePlayer = Vector3.Distance(target1.position, transform.position);
      agent.SetDestination(target1.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
      Debug.Log("robot collided! collision");
      if(collision.gameObject.CompareTag("Player"))
      {
        myAnimationController.SetBool("Hit",true);
      }
    }

    private void OnTriggerEnter(Collider collision)
    {
      Debug.Log("robot collided! trigger");
      if(collision.gameObject.CompareTag("Player"))
      {
        myAnimationController.SetBool("Hit",true);
      }
    }

    private void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.CompareTag("Player"))
      {
        myAnimationController.SetBool("Hit",false);
      }
    }

    private void OnTriggerExit(Collider collision)
    {
      Debug.Log("collided!");
      if(collision.gameObject.CompareTag("Player"))
      {
        myAnimationController.SetBool("Hit",false);
      }
    }

    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
