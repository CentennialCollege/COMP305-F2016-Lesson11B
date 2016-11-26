using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	public AudioSource CoinSound;

	private WaitForSeconds waitTime = new WaitForSeconds (0.25f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (PlaySoundAndDestroy ());
		}
	}

	// CoRoutine
	IEnumerator PlaySoundAndDestroy() {
		CoinSound.Play ();
		yield return this.waitTime;
		Destroy (this.gameObject);
	}
}
