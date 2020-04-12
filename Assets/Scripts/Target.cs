// attach this script to any object that is a target. Must be a rigidbody for it to take an impact force

using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f; // Arbitrary health value, keep damage from gun in mind when changing.
	

	public void takeDamage(float damageAmount) {
		health -= damageAmount; // damage occuring on object
		if (health <0f)
		{
			Death();
		}

		void Death()
		{
			Destroy(gameObject); // if the object health reaches 0, destroy the object 
		}
	}
}