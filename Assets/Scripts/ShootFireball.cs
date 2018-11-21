using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour {

	public float damage;
	public float speed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		if(transform.rotation.y > 0) rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
		else rb.AddForce(Vector3.right * -speed, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy" || other.gameObject.layer == LayerMask.NameToLayer("Shootable")){
		rb.velocity = Vector3.zero;
		EnemyHealth enemyH = other.GetComponent<EnemyHealth>();
		if(enemyH != null){
			enemyH.addDamage(damage);
			//enemyH.addFire();
		}
		Destroy(gameObject);
		}
	}
}
