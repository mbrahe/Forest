using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float minYDiff;
	public float maxYDiff;
	public float minXDiff;
	public float maxXDiff;

	Transform target;

	Vector3 targetPrevPosition;
	Vector2 change;

	// Use this for initialization
	void Start () {
		transform.parent = null;
		change = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (!target) {
			target = GameObject.FindWithTag ("Player").transform;
			targetPrevPosition = target.position;
		}

		Vector3 delta = target.position - targetPrevPosition;
		targetPrevPosition = target.position;

		Vector3 newPos = new Vector3 (transform.position.x, 0, -10);
		change = Vector2.zero;

		if (transform.position.x - target.position.x < minXDiff || 
			transform.position.x - target.position.x > maxXDiff) {
			newPos.x = transform.position.x + delta.x;
			change.x = delta.x;
		}

		/*if (transform.position.y - target.position.y < minYDiff || 
			transform.position.y - target.position.y > maxYDiff) {
			newPos.y = transform.position.y + delta.y;
			change.y = delta.y/Time.deltaTime;
		}*/


		transform.position = newPos;

	}

	public Vector2 GetChange() {
		return change;
	}
}
