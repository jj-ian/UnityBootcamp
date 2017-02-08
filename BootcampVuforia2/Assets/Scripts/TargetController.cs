using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("target x " + transform.position.x);
		Debug.Log ("target y " + transform.position.y);
		Debug.Log ("target z " + transform.position.z);

	}
}
