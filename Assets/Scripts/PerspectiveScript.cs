using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveScript : MonoBehaviour {

	SpriteRenderer sr;
	CameraScript cs;

	float prevY;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		cs = Camera.main.GetComponent<CameraScript> ();
		prevY = transform.parent.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float y = transform.parent.position.z;

		Vector3 tempPosition = transform.position;
		if (y != prevY) {
			tempPosition.x = Mathf.Lerp(tempPosition.x, y * (-transform.parent.position.x) + transform.parent.position.x, cs.GetChange().y);
			prevY = y;
		}
		tempPosition.y = Camera.main.ViewportToWorldPoint (new Vector2(0, Mathf.Sin (Mathf.PI / 2 * (y)))).y;
		tempPosition.z = Camera.main.WorldToViewportPoint (tempPosition).y;
		tempPosition.x += cs.GetChange ().x * y;

		transform.position = tempPosition;

		if (y < 0) {
			y = 0;
		}

		transform.localScale = new Vector3 (Mathf.Sin (Mathf.PI / 2 * (1 - y/.5f)) * 10, Mathf.Sin (Mathf.PI / 2 * (1 - y/.5f)) * 10, 1);
		
		if (y > .3f) {
			sr.enabled = false;
		} else if (y > .2f) {
			sr.enabled = true;

			/*Color tempColor = sr.color;
			tempColor.r = (.25f - y) * 10;
			tempColor.g = (.25f - y) * 10;
			tempColor.b = (.25f - y) * 10;
			sr.color = tempColor;*/
		} else {
			sr.enabled = true;
		}
			

	}
}
