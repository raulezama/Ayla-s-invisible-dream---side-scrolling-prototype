using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public float damage;
	public float knockBack;
	public float knockBackRadius;
	public float meleeRate;

	private float nextMelee;
	private int shootableMask;

	private Animator myAnim;
	AylaAnim Ayla;

	// Use this for initialization
	void Start () {
		shootableMask = LayerMask.GetMask("Shootable");
		myAnim = transform.root.GetComponent<Animator>();
		Ayla = transform.root.GetComponent<AylaAnim>();
		nextMelee = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float melee = Input.GetAxis("Fire2");

		if(melee > 0 && nextMelee < Time.time && !Ayla.GetRunning()){
			myAnim.SetTrigger("melee");
			//myAnim.Play("WAIT04", -1, 0.4f);
			nextMelee = Time.time + meleeRate;

			//Do damage
			Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

			int i = 0;
			while (i < attacked.Length)
			{
				if(attacked[i].tag == "Enemy"){
					EnemyHealth doDamage = attacked[i].GetComponent<EnemyHealth>();
					doDamage.addDamage(damage);
				}
				i++;
			}
		}
	}
}
