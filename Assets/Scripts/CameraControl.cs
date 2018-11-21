using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("s")){
            GetComponent<SaveSystem>().SaveData();
		}

		if(Input.GetKeyDown("l")){
			GetComponent<SaveSystem>().LoadData();
		}
	}

	void FixedUpdate(){
		Vector3 cameraPosition = target.position + offset;

		transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothing * Time.deltaTime);
	}
}
