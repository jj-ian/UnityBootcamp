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
	private TransformMode mode = TransformMode.Rotate;

	Vector3 targetLastPos;
	Quaternion targetLastRot;

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
			Vector3 translationAmount = targetToFollow.transform.position - targetLastPos;
			transform.Translate(translationAmount, Space.World);
		} else if (mode == TransformMode.Rotate) {
			Quaternion rotationAmount = targetToFollow.transform.rotation * Quaternion.Inverse(targetLastRot);
			transform.Rotate(rotationAmount.eulerAngles, Space.World);
		} else {
			//gets bigger as you move horizontally away from x = 0
			float scaleFactor = targetToFollow.transform.position.x - targetLastPos.x;
			Vector3 scaleIncrease = new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			transform.localScale = transform.localScale + scaleIncrease;
		}
		targetLastPos = targetToFollow.transform.position;
		targetLastRot = targetToFollow.transform.rotation;

	}
}
