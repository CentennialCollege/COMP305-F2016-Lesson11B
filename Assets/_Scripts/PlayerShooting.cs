using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour {

	// PUBLIC VARIABLES FOR TESTING
	public Transform FlashPoint;
	public GameObject MuzzleFlash;
	public GameObject Explosion;
	public GameObject BulletImpact;
	public AudioSource RifleShotSound;
	public Transform PlayerCam;
	public LineRenderer Laser;

	public float WeaponRange = 50.0f;



	// PRIVATE VARIABLES

	private WaitForSeconds waitTime = new WaitForSeconds (0.1f);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame (for Physics)
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			// show the MuzzleFlash at the FlashPoint without any rotation
			Instantiate (this.MuzzleFlash, this.FlashPoint.position, Quaternion.identity);

			// initial Line position - element 0
			Laser.SetPosition (0, this.FlashPoint.position);

			// need a variable to hold the location of our Raycast Hit
			RaycastHit hit;

			// if raycast hits an object then do something...
			if (Physics.Raycast (this.PlayerCam.position, this.PlayerCam.forward, out hit)) {

				if (hit.transform.gameObject.CompareTag ("Enemy")) {
					Instantiate (this.Explosion, hit.point, Quaternion.identity);
					Destroy (hit.transform.gameObject);
				} else {
					Instantiate (this.BulletImpact, hit.point, Quaternion.identity);
				}

				// terminus of the line position - element 1
				Laser.SetPosition (1, hit.point);

			} else {
				// if the laser misses - terminate it 50 units from the playercam
				Laser.SetPosition (1, this.PlayerCam.position + (this.PlayerCam.forward * this.WeaponRange));
			}

			// Play Rifle Sound
			this.RifleShotSound.Play();

			StartCoroutine (ShotEffect ());

		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Exit")) {
			SceneManager.LoadScene ("OutDoor");	
		}
	}

	// CoRoutine
	IEnumerator ShotEffect() {
		Laser.enabled = true;
		yield return this.waitTime;
		Laser.enabled = false;
	}

}
