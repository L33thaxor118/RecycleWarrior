// attach this script to any object that is a target. Must be a rigidbody for it to take an impact force

using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f; // Arbitrary health value, keep damage from gun in mind when changing.
	public GameObject trashDrop1;
	public GameObject trashDrop2;

	public Transform dropLocation;
	

	public void takeDamage(float damageAmount) {
		health -= damageAmount; // damage occuring on object
		if (health <0f)
		{
			Death();
		}

		// CHANGE BEHAVIOR BASED ON THIS OBJECTS TAG, FOR EXAMPLE, WE DONT WANT TO REDUCE TERRAIN HEALTH. OR WE MAY NOT WANT ENTs TO DROP ANYTHING.
		void Death()
		{
			Instantiate(trashDrop1, dropLocation.position, dropLocation.rotation);
			Instantiate(trashDrop1, dropLocation.position, dropLocation.rotation);
			Destroy(gameObject); // if the object health reaches 0, destroy the object 
		}
	}
}