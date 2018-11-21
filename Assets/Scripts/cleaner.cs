using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Usa el tag Player para corroborar que si éste cae en un
    /// collider de limpieza, el gameObject será destruido
    /// </summary>
    /// <param name="other"></param>

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth playerDead = other.gameObject.GetComponent<PlayerHealth>();
            playerDead.MakeDead();
        }
        else Destroy(other.gameObject);
    }
}
