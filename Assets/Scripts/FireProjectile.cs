using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

	public float fireRate = 0.15f;
	public GameObject projectile;
	public GameObject ayla;
	private Animator anim;


	float nextProjectile;
	// Use this for initialization
	void Awake () {
		nextProjectile = 0f;
		anim = ayla.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		AylaAnim player = transform.root.GetComponent<AylaAnim>();

		if(Input.GetAxisRaw("Fire1") > 0 && nextProjectile < Time.time && player.firePower == true)
		{
			nextProjectile = Time.time + fireRate;
			Vector3 rot;
			anim.Play("WAIT03", -1, 0.6f);
			if(player.GetFacing() == -1f){
				rot = new Vector3(0, -90, 0);
			}
			else{
				rot = new Vector3(0, 90, 0);
			}

			Instantiate(projectile, transform.position, Quaternion.Euler(rot));
		}
	}
}
