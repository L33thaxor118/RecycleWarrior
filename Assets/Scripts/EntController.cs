using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntController : MonoBehaviour
{

  public float hitDelay = 1f;
  
  [SerializeField] private Animator myAnimationController;
    // public float lookRadius = f;
    GameObject currentTargetRobot;
    // Transform target2;
    public float distanceEnt;
    NavMeshAgent agent;
    
    public Target selfTarget;

    void Start(){
      // target2 = GameObject.FindGameObjectWithTag("Tree").transform;
      agent = GetComponent<NavMeshAgent>();
    }

    void Update(){

      if (selfTarget.health <= 0) {
        myAnimationController.SetBool("Death", true);
        Destroy(gameObject, 15);
        agent.isStopped = true;
      }

      //Robot Kyle comes out
      GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot Kyle");
      if(robots.Length > 0){
        myAnimationController.SetBool("Go", true);
        float closest = 100000f;
        foreach (GameObject robot in robots ) {
          float robotDistance = Vector3.Distance(robot.transform.position, transform.position);
          if (robotDistance < closest) {
            closest = robotDistance;
            currentTargetRobot = robot;
          }
        }
        if(closest >= 0.5f){
          agent.SetDestination(currentTargetRobot.transform.position);
        }
      }
      else
      {
        myAnimationController.SetBool("Go",false);
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      Debug.Log("robot collided! collision");
      if(collision.gameObject.CompareTag("Robot Kyle")){
        myAnimationController.SetBool("Hit",true);
      }
    }

    private void OnTriggerEnter(Collider collision)
    {
      Debug.Log("robot collided! trigger");
      if(collision.gameObject.CompareTag("Robot Kyle")){
        myAnimationController.SetBool("Hit",true);
      }
    }
    private void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.CompareTag("Robot Kyle")){
        myAnimationController.SetBool("Hit",false);
      }
    }

    private void OnTriggerExit(Collider collision)
    {
      Debug.Log("collided!");
      if(collision.gameObject.CompareTag("Robot Kyle")){
        myAnimationController.SetBool("Hit",false);
      }
    }

    // void OnDrawGizmosSelected()
    // {
    //   Gizmos.color = Color.red;
    //   Gizmos.DrawWireSphere(transform.position, lookRadius);
    // }
}
