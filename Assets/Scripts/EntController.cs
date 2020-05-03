using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntController : MonoBehaviour
{
  [SerializeField] private Animator myAnimationController;
    // public float lookRadius = f;
    Transform target1;
    // Transform target2;
    public float distanceEnt;
    NavMeshAgent agent;

    void Start(){
      // target2 = GameObject.FindGameObjectWithTag("Tree").transform;
      agent = GetComponent<NavMeshAgent>();
    }

    void Update(){

      if (Input.GetKeyDown(KeyCode.X))
      {
        myAnimationController.SetBool("Death",true);
      }

      //Robot Kyle comes out
      if(GameObject.FindGameObjectWithTag("Robot Kyle") != null){
        target1 = GameObject.FindGameObjectWithTag("Robot Kyle").transform;
        distanceEnt = Vector3.Distance(target1.position, transform.position);
        myAnimationController.SetBool("Go",true);
        if(distanceEnt >= 0.5f){
          agent.SetDestination(target1.position);
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
