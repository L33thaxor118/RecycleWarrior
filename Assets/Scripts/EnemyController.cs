using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  [SerializeField] private Animator myAnimationController;
    public float lookRadius = 5f;
    Transform playerTarget;
    Transform treeTarget;
    GameObject currentEntTarget;

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
      playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
      treeTarget = GameObject.FindGameObjectWithTag("Tree").transform;
      if(GameObject.FindGameObjectWithTag("Ent") != null){
        currentEntTarget = GameObject.FindGameObjectWithTag("Ent");
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
        } else if (collision.gameObject.CompareTag("Ent") && timeTillNextHit <= 0) {
          collision.gameObject.GetComponent<Target>().takeDamage(10);
          timeTillNextHit = hitDelay;
        }
      }

      if (target.isDead) {
        mainCollider.enabled = false;
        agent.enabled = false;
        mainRigidBody.detectCollisions = false;
        deadTime++;
        isHitting = false;
        if (deadTime > 25) {
          myAnimationController.enabled = false;
          Destroy(gameObject, 15);
        }
        return;
      }

      float distancePlayer = Vector3.Distance(playerTarget.position, transform.position);

      GameObject[] ents = GameObject.FindGameObjectsWithTag("Ent");

      float closest = 100000f;
      foreach (GameObject ent in ents) {
        if (ent.GetComponent<Target>().health <= 0) {
          continue;
        }
        float entDistance = Vector3.Distance(ent.transform.position, transform.position);
        if (entDistance < closest) {
          closest = entDistance;
          currentEntTarget = ent;
        }
      }
      distanceEnt = closest;

      float distanceTree = Vector3.Distance(treeTarget.position, transform.position);

      if(distanceEnt <= distancePlayer && currentEntTarget.GetComponent<Target>().health > 0)
      {
        if(distanceEnt >= 0.5f) {
          agent.SetDestination(currentEntTarget.transform.position);
        }
      }
      else if(distancePlayer <= lookRadius)
      {
        agent.SetDestination(playerTarget.position);
      }
      else
      {
        agent.SetDestination(treeTarget.position);
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



