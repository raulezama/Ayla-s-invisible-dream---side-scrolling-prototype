using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private GameObject playerObject;


	// Use this for initialization
	void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");		
	}
	
    
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("Checked");
        playerObject.transform.position = currentCheckpoint.transform.position;
    }
}
