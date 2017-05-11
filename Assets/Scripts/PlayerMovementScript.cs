using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

	public float walkingAcc;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")).normalized * walkingAcc);
	}
}
