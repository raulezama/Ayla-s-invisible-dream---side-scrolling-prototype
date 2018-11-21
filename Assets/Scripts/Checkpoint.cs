using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;
	public GameObject checkpointPS;
	

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			levelManager.currentCheckpoint = gameObject;
			Instantiate(checkpointPS, gameObject.transform);
			Debug.Log("New Check");
		}
	}
}
