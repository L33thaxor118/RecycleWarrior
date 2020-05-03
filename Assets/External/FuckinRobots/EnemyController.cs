using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  [SerializeField] private Animator myAnimationController;
    public float lookRadius = 5f;
    public float distanceEnt = 200f;
    Transform target1;
    Transform target2;
    Transform target3;
    NavMeshAgent agent;

    void Start(){
      target1 = GameObject.FindGameObjectWithTag("Player").transform;
      target2 = GameObject.FindGameObjectWithTag("Tree").transform;
      if(GameObject.FindGameObjectWithTag("Ent") != null){
        target3 = GameObject.FindGameObjectWithTag("Ent").transform;
      }
      agent = GetComponent<NavMeshAgent>();
    }

    void Update(){


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
    }
    private void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.CompareTag("Tree") ||
         collision.gameObject.CompareTag("Player") ||
         collision.gameObject.CompareTag("Ent"))
      {
        myAnimationController.SetBool("Hit",false);
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
    }

    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
