using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpController : MonoBehaviour {

	public float healthRestoredAmount;
	public AudioClip pickUpClip;
    public GameObject healthEffect;
	AudioSource pickUpAS;

	// Use this for initialization
	void Start () {
		pickUpAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Adquiere el item de salud
    /// </summary>
    /// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			other.GetComponent<PlayerHealth>().AddHealth(healthRestoredAmount);
			AudioSource.PlayClipAtPoint(pickUpClip, transform.position, 0.15f);
            Instantiate(healthEffect, other.transform.position, other.transform.rotation);
			
			Destroy(transform.root.gameObject);
		}
		
	}
}
