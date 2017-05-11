using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthOrderingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Objects at the bottom of the screen are closer to the camera then objects at the top
		Vector3 tempPosition = transform.position;
		tempPosition.z = Camera.main.WorldToViewportPoint (tempPosition).y;

		transform.position = tempPosition;
	}
}
