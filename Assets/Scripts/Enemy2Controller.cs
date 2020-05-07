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

    void Start(){
      target1 = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update(){

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
