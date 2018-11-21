using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePickUpController : MonoBehaviour {

	private static bool firePower;
	public List<Image> Icons = new List<Image>();
    public GameObject powerUpEffect;
	private Color iconColor = new Color(255f,255f,255f,1f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Adquiere el item de fuego y habilita nuevo ataque
    /// </summary>
    /// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			firePower = true;
			foreach (var item in Icons)
			{
				item.color = iconColor;
			}

            Instantiate(powerUpEffect, other.transform.position, other.transform.rotation);
			other.GetComponent<AylaAnim>().IsFirePowerActive(firePower);
			Destroy(transform.root.gameObject);
		}
		
	}
}
