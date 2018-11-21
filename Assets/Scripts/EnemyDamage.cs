using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float damage;
	public float damageRate;
	public float pushBackForce;

	private float nextDamage;
	private bool playerInRange = false;

	GameObject playerAyla;
	PlayerHealth playerAylaHealth;
	Animator enemyAnim;
	// Use this for initialization
	void Start () {
		nextDamage = Time.time;
		playerAyla = GameObject.FindGameObjectWithTag("Player");
		playerAyla.GetComponent<Animator>();
		playerAylaHealth = FindObjectOfType<PlayerHealth>();
		enemyAnim = transform.root.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerInRange) Attack();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player")
		{
			playerInRange = false;
		}
	}

	void Attack(){
		if(nextDamage <= Time.time){
			if(enemyAnim != null) enemyAnim.SetTrigger("attack");
            playerAylaHealth.AddDamage(damage);
			nextDamage = Time.time + damageRate;
			PushBack(playerAyla.transform);
		}
	}

	void PushBack(Transform pushedObject){
		Vector3 pushDirection = new Vector3((pushedObject.position.x - transform.position.x), (pushedObject.position.y - transform.position.y), 0).normalized;
		pushDirection *= pushBackForce;

		Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
		pushedRB.velocity = Vector3.zero;
		pushedRB.AddForce(pushDirection, ForceMode.Impulse);
	}
}
