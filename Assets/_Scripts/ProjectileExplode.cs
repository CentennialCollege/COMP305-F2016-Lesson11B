using UnityEngine;
using System.Collections;

public class ProjectileExplode : MonoBehaviour {

public GameObject Explosion;
  public float BlastRadius = 5.0f;
  public float BlastForce = 60000f;
  public int Damage = 1;
  private bool explode = false;

	// Update is called once per frame
	void FixedUpdate () {
    if(explode) {
      Collider[] hitColliders = Physics.OverlapSphere(transform.position, this.BlastRadius);
      for(int i = 0; i < hitColliders.Length; i++) {
        if(hitColliders[i].GetComponent<Rigidbody>() != null) {
          hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(this.BlastForce, transform.position, BlastRadius);
					if (hitColliders [i].CompareTag ("Enemy")) {
						Destroy (hitColliders [i].gameObject);
					}
        }

      }
      Destroy(this.gameObject);
    }
	}

  void OnCollisionEnter(Collision other) {
    	Instantiate(Explosion, transform.position, Quaternion.identity);
    	this.explode = true;

    }
  
}
