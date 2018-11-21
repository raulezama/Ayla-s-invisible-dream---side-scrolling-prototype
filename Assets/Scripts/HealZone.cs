using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

	public float healthRestoredAmount;
	public float healRate;
	private float nextHeal;

	// Use this for initialization
	void Start () {
		nextHeal = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
    {
        while (other.tag == "Player" && nextHeal <= Time.time)
        {
            other.GetComponent<PlayerHealth>().AddHealth(healthRestoredAmount);
			nextHeal = Time.time + healRate;
        }

    }
}
