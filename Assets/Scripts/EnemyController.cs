using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
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
    public AudioSource walk;
    public AudioSource hitPlayer;
    public AudioSource hitWood;
    public AudioSource spawn;
    public AudioSource death;
    private int deathCounter = 0;
    private bool hurtPlayer;

    public Target target;

    public NavMeshAgent agent;

    void Start(){
      target1 = GameObject.FindGameObjectWithTag("Player").transform;
      target2 = GameObject.FindGameObjectWithTag("Tree").transform;
      if(GameObject.FindGameObjectWithTag("Ent") != null){
        target3 = GameObject.FindGameObjectWithTag("Ent").transform;
      }
      hurtPlayer = false;
      spawn.Play();
    }

    void Update(){
      //sound
      if (myAnimationController.GetBool("Hit") == false && walk.isPlaying == false && deathCounter == 0)
      {
        walk.Play();
        hitPlayer.Stop();
        hitWood.Stop();
      }

      if(myAnimationController.GetBool("Hit") == true && hitWood.isPlaying == false
        && deathCounter == 0 && hitPlayer.isPlaying == false)
      {
        walk.Stop();
        if(hurtPlayer == true)
        {
          hitPlayer.Play();
        }
        else
        {
          hitWood.Play();
        }
      }



      if (target.isDead) {
        mainCollider.enabled = false;
        agent.enabled = false;
        mainRigidBody.detectCollisions = false;
        if(death.isPlaying == false && deathCounter == 0)
        {
          walk.Stop();
          hitPlayer.Stop();
          hitWood.Stop();
          death.Play();
          deathCounter++;
        }
          myAnimationController.enabled = false;
          Destroy(this.gameObject,2);
        return;
      }

      float distancePlayer = Vector3.Distance(target1.position, transform.position);

      if(GameObject.FindGameObjectWithTag("Ent") != null){
        target3 = GameObject.FindGameObjectWithTag("Ent").transform;
        distanceEnt = Vector3.Distance(target3.position, transform.position);
      }
      else{
        distanceEnt = 200f;
      }

      float distanceTree = Vector3.Distance(target2.position, transform.position);

      if(distanceEnt <= distancePlayer)
      {
        if(distanceEnt >= 0.5f){
          agent.SetDestination(target3.position);
        }
      }
      else if(distancePlayer <= lookRadius)
      {
        agent.SetDestination(target1.position);
      }
      else
      {
        agent.SetDestination(target2.position);
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      Debug.Log("robot collided! collision");
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        myAnimationController.SetBool("Hit",true);
      }
      if(collision.gameObject.CompareTag("Player")){
        hurtPlayer = true;
      }
    }

    private void OnTriggerEnter(Collider collision)
    {
      Debug.Log("robot collided! trigger");
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        myAnimationController.SetBool("Hit",true);
      }
      if(collision.gameObject.CompareTag("Player")){
        hurtPlayer = true;
      }
    }

    private void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        myAnimationController.SetBool("Hit",false);
      }
      if(collision.gameObject.CompareTag("Player")){
        hurtPlayer = false;
      }
    }

    private void OnTriggerExit(Collider collision)
    {
      Debug.Log("collided!");
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        myAnimationController.SetBool("Hit",false);
      }
      if(collision.gameObject.CompareTag("Player")){
        hurtPlayer = false;
      }
    }

    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
