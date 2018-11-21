using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijarPlataforma : MonoBehaviour {

    public GameObject platform;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.parent = platform.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
