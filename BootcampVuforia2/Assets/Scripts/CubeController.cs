using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	enum TransformMode {
		Translate,
		Rotate,
		Scale
	};

	public GameObject targetToFollow;
	// Use this for initialization
	private TransformMode mode = TransformMode.Translate;

	Vector3 targetLastPos;
	void Start () {
		targetLastPos = targetToFollow.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("t")) {
			mode = TransformMode.Translate;
		} else if (Input.GetKeyUp ("r")) {
			mode = TransformMode.Rotate;
		} else if (Input.GetKeyUp ("s")) {
			mode = TransformMode.Scale;
		}

		if (mode == TransformMode.Translate) {
			//Debug.Log ("cube x " + transform.position.x);
			//Debug.Log ("target from cube x " + targetToFollow.transform.position.x);
			Vector3 translationAmount = targetToFollow.transform.position - targetLastPos;
			//transform.position = targetToFollow.transform.position;
			transform.position += translationAmount;
			targetLastPos = targetToFollow.transform.position;
		} else if (mode == TransformMode.Rotate) {
			transform.rotation = targetToFollow.transform.rotation;
		} else {

			//left it gets small, right it gets big
			float scaleFactor = targetToFollow.transform.position.x;
			scaleFactor = scaleFactor > 0 ? scaleFactor : 0;
			//Debug.Log ("scalefactor " + scaleFactor);
			Vector3 myNewScale = new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			//Vector3 lol = Vector3 (2, 2, 2);
			transform.localScale = myNewScale;
		}

	}
}
