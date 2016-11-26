using UnityEngine;
using System.Collections;

public class ProjectShooting : MonoBehaviour {

	public Rigidbody Projectile;
  public Transform FlashPoint;
  public float ProjectileForce = 500.0f;
  public float FireRate = 0.25f;



  private float NextFireTime;


	void Update () {
    if(Input.GetButtonDown("Fire2") && Time.time > NextFireTime) {
      Rigidbody cloneRB = Instantiate(Projectile, FlashPoint.position, Quaternion.identity) as Rigidbody;
      cloneRB.AddForce(FlashPoint.transform.forward * ProjectileForce);
      NextFireTime = Time.time + FireRate;
    }
	}
}
