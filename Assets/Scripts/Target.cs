// attach this script to any object that is a target. Must be a rigidbody for it to take an impact force

using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f; // Arbitrary health value, keep damage from gun in mind when changing.
	public GameObject trashDrop1;
	public GameObject trashDrop2;

	public GameObject trashDrop3;

	public GameObject trashDrop4;

	public Transform dropLocation;

	public bool isDead;
	

	public void takeDamage(float damageAmount) {
		health -= damageAmount; // damage occuring on object
		if (health <0f && !isDead)
		{
			Death();
		}

		// CHANGE BEHAVIOR BASED ON THIS OBJECTS TAG, FOR EXAMPLE, WE DONT WANT TO REDUCE TERRAIN HEALTH. OR WE MAY NOT WANT ENTs TO DROP ANYTHING.
		void Death()
		{
			int random = Random.Range(1,5);
			if (random == 1) {
				Instantiate(trashDrop1, dropLocation.position, dropLocation.rotation);
			} else {
				Instantiate(trashDrop2, dropLocation.position + new Vector3(0.5f,1f,0.5f), dropLocation.rotation);
				Instantiate(trashDrop3, dropLocation.position + new Vector3(-0.5f,1f,0.5f), dropLocation.rotation);
				Instantiate(trashDrop4, dropLocation.position + new Vector3(0.5f,1f,-0.5f), dropLocation.rotation);
			}
			isDead = true;
		}
	}
}