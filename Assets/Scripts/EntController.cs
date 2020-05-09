using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntController : MonoBehaviour
{

  public float hitDelay = 1f;

  private GameObject collidedRobot;

  private bool isHitting = false;

  public AudioSource walk;

  public AudioSource death;

  public AudioSource hit;

  private bool deathPlayed = false;
  
  [SerializeField] private Animator myAnimationController;
    // public float lookRadius = f;
    GameObject currentTargetRobot;
    // Transform target2;
    public float distanceEnt;
    NavMeshAgent agent;    
    public Target selfTarget;

    public GameObject healEffect;

    private float timeTillNextHit = 0f;

    void Start(){
      // target2 = GameObject.FindGameObjectWithTag("Tree").transform;
      agent = GetComponent<NavMeshAgent>();
      timeTillNextHit = hitDelay;
    }

    void Update(){
      if (collidedRobot != null) {
          if (collidedRobot.GetComponent<Target>().isDead) {
            isHitting = false;
            myAnimationController.SetBool("Hit", false);
          }
      }
      if (timeTillNextHit > 0) {
        timeTillNextHit -= Time.deltaTime;
      }

      if (isHitting && timeTillNextHit <= 0) {
        hit.Play();
        collidedRobot.gameObject.GetComponent<Target>().takeDamage(40);
        timeTillNextHit = hitDelay;
      }

      if (selfTarget.health <= 0) {
        if (!deathPlayed) {
          death.Play();
          deathPlayed = true;
        }
        myAnimationController.SetBool("Death", true);
        Destroy(gameObject, 15);
        agent.isStopped = true;
        isHitting = false;
      }

      //Robot Kyle comes out
      GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot Kyle");
      if(robots.Length > 0){
        float closest = 100000f;
        foreach (GameObject robot in robots ) {
          if (robot.GetComponent<Target>().health <= 0) {
            continue;
          }
          float robotDistance = Vector3.Distance(robot.transform.position, transform.position);
          if (robotDistance < closest) {
            closest = robotDistance;
            currentTargetRobot = robot;
          }
        }
        if(closest >= 1f){
          //.Play();
          agent.SetDestination(currentTargetRobot.transform.position);
          myAnimationController.SetBool("Go", true);
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
        myAnimationController.SetBool("Hit", true);
        collidedRobot = collision.gameObject;
        isHitting = true;
        //walk.Stop();
      }
      if (collision.gameObject.CompareTag("Avocado") || collision.gameObject.CompareTag("Burger")) {
        gameObject.GetComponent<Target>().health += 25;
        Debug.Log("hit by avocado");
        healEffect.GetComponent<ParticleSystem>().Play();
        Destroy(collision.gameObject);
      }
    }
    private void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.CompareTag("Robot Kyle")){
        myAnimationController.SetBool("Hit",false);
        isHitting = false;
      }
    }

    private void OnTriggerExit(Collider collision)
    {
      if(collision.gameObject.CompareTag("Robot Kyle")){
        myAnimationController.SetBool("Hit",false);
        isHitting = false;
      }
    }

    // void OnDrawGizmosSelected()
    // {
    //   Gizmos.color = Color.red;
    //   Gizmos.DrawWireSphere(transform.position, lookRadius);
    // }
}
