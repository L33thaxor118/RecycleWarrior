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

    public Target target;

    public NavMeshAgent agent;

    public float hitDelay = 1f;
    private float timeTillNextHit;

    private bool isHitting = false;

    private GameObject collision;

    void Start(){
      timeTillNextHit = hitDelay;
      target1 = GameObject.FindGameObjectWithTag("Player").transform;
      target2 = GameObject.FindGameObjectWithTag("Tree").transform;
      if(GameObject.FindGameObjectWithTag("Ent") != null){
        target3 = GameObject.FindGameObjectWithTag("Ent").transform;
      }
    }

    void Update(){
      if (timeTillNextHit > 0) {
        timeTillNextHit -= Time.deltaTime;
      }
      if (isHitting) {
        if (collision.gameObject.CompareTag("Player") && timeTillNextHit <= 0) {
          collision.gameObject.GetComponent<PlayerHealth>().health -= 10;
          collision.gameObject.GetComponents<AudioSource>()[2].Play();
          timeTillNextHit = hitDelay;
        }
      }

      if (target.isDead) {
        mainCollider.enabled = false;
        agent.enabled = false;
        mainRigidBody.detectCollisions = false;
        deadTime++;
        if (deadTime > 25) {
          myAnimationController.enabled = false;
        }
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
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        this.collision = collision.gameObject;
        Debug.Log("robot entered collision");
        myAnimationController.SetBool("Hit",true);
        isHitting = true;
      }
    }

    private void OnTriggerEnter(Collider collision)
    {
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        Debug.Log("robot entered trigger");
        myAnimationController.SetBool("Hit",true);
        this.collision = collision.gameObject;
        isHitting = true;
      }
    }

    private void OnCollisionExit(Collision collision)
    {
      Debug.Log("robot exited collision");
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        stopHitting();
      }
    }

    private void OnTriggerExit(Collider collision)
    {
      Debug.Log("robot exited trigger");
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        stopHitting();
      }
    }

    void stopHitting() {
      myAnimationController.SetBool("Hit",false);
      isHitting = false;
    }

    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}



