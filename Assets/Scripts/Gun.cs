// attach gun to main camera object and attach this script to the gun

using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 10f; // Arbotrary Damage value for gun
	public float range = 100f; // Range of weapon in units
	public float force = 10f; // Force to be applied on rigidbodies
	public float fireRate = 15f; // Number of shots fired per second
	public Camera userCamera;  // change this depending on the setup
	private float nextTime = 0f; // inital value for checking rate

	public ParticleSystem muzzleEffect;
	public ParticleSystem HitEffect;
	public Transform gunTransform;

	public AudioSource fireSound;

	private float recoil = 0f;

	void Start() {
	}

	void Update() {

		if (Input.GetButton("Fire1") && Time.time >= nextTime)
		{
			nextTime = Time.time + 1f/fireRate;
			Shoot();
		}
	}

	void Shoot() {
		RaycastHit hit;
		fireSound.Play();
		muzzleEffect.Play();

		if	(Physics.Raycast(userCamera.transform.position, userCamera.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			Target target = hit.transform.GetComponent<Target>();
			if (target != null) {
				target.takeDamage(damage);
			}

			if (hit.rigidbody != null){
				hit.rigidbody.AddForce(-hit.normal * force);
			}
		}

	}

}