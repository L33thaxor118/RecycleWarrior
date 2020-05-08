// attach gun to main camera object and attach this script to the gun

using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float damage = 10f; // Arbotrary Damage value for gun
	public float range = 100f; // Range of weapon in units
	public float force = 10f; // Force to be applied on rigidbodies
	public float fireRate = 15f; // Number of shots fired per second
	public Camera userCamera;  // change this depending on the setup
	private float nextTime = 0f; // inital value for checking rate

	public ParticleSystem muzzleEffect;
	public GameObject HitEffectMetal;
	public GameObject HitEffectGround;

	public Transform gunTransform;

	public AudioSource fireSound;

	public AudioSource emptySound;

	public Inventory inventory;
	public float spread = 0f;

	public float spreadFactor = 1f;

	public int ammoType;

	void Start() {
	}

	void Update() {
		if (spread > 0) {
			spread -= Time.deltaTime;
		} else {
			spread = 0f;
		}
		
		if (Input.GetButton("Fire1") && Time.time >= nextTime)
		{
			if (ammoType == 1 && inventory.lightAmmo > 0) {
				nextTime = Time.time + 1f/fireRate;
				inventory.lightAmmo--;
				Shoot();
			} else if (ammoType == 2 && inventory.mediumAmmo > 0) {
				nextTime = Time.time + 1f/fireRate;
				inventory.mediumAmmo--;
				Shoot();
			} else if (ammoType == 3 && inventory.heavyAmmo > 0) {
				nextTime = Time.time + 1f/fireRate;
				inventory.heavyAmmo--;
				Shoot();
			} else {
				//empty ammo sound play
				emptySound.Play();
			}

		}
	}

	void Shoot() {
		StartCoroutine(Kick(gameObject.transform, gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward*0.015f, 0.01f));
		RaycastHit hit;
		fireSound.Play();
		muzzleEffect.Play();
		spread += spreadFactor;
		Debug.Log(spread);

		 Vector3 dir = new Vector3(Random.Range(-spread, spread),Random.Range(spread,spread),1f);
 		 Vector3 sprayDir = userCamera.transform.TransformVector(dir);


		if	(Physics.Raycast(userCamera.transform.position, sprayDir, out hit, range))
		{
			Debug.DrawRay(userCamera.transform.position, userCamera.transform.forward * range, Color.red, 10);
			Debug.Log(hit.transform.name);
			Target target = hit.transform.GetComponent<Target>();
			if (target != null) {
				target.takeDamage(damage);
			}

			if (hit.rigidbody != null){
				hit.rigidbody.AddForce(-hit.normal * force);
			}
		}

		if (hit.collider.gameObject != null) {
			if (hit.collider.gameObject.CompareTag("Robot Kyle")) {
				GameObject impact = Instantiate(HitEffectMetal, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(impact, 1.0f);
			} else {
				GameObject impact = Instantiate(HitEffectGround, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(impact, 1.0f);
			}
		}


	}

	    IEnumerator Kick (Transform objectTransform, Vector3 start, Vector3 end, float time) {
        float i = 0.0f;
        float rate = 1.0f/time;
        while (i < 1.0) {
            Debug.Log("while");
            i += Time.deltaTime * rate;
            objectTransform.position = Vector3.Lerp(start, end, i);
            yield return null; 
        }
				StartCoroutine(KickBack(gameObject.transform, gameObject.transform.position, gameObject.transform.position - gameObject.transform.forward*0.015f, 0.01f));
    }

			IEnumerator KickBack (Transform objectTransform, Vector3 start, Vector3 end, float time) {
        float i = 0.0f;
        float rate = 1.0f/time;
        while (i < 1.0) {
            Debug.Log("while");
            i += Time.deltaTime * rate;
            objectTransform.position = Vector3.Lerp(start, end, i);
            yield return null; 
        }
    }

}