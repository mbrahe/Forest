using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScript : MonoBehaviour {
	public string dialogue;
	public float dialogueLength;
	public GUIStyle textStyle;

	string[] formattedDialogue;

	string displayText; // What is being printed on the screen at any given time
	bool isSpeaking;
	int scriptIndex;
	bool justBeganTalking;

	Vector2 textPosition;

	float timer;


	// Use this for initialization
	void Start () {
		displayText = "";
		isSpeaking = false;
		scriptIndex = 0;
		justBeganTalking = false;

		timer = 0;

		formattedDialogue = dialogue.Split ('#');


	}
	
	// Update is called once per frame
	void Update () {
		if (isSpeaking) {
			if (scriptIndex < formattedDialogue.Length) {
				if (displayText.Length < formattedDialogue [scriptIndex].Length) {
					if (timer <= 0) {
						timer = dialogueLength;
						displayText = formattedDialogue [scriptIndex].Substring (0, displayText.Length + 1);
					}
					timer -= Time.deltaTime;
				}
			} else {
				// End dialogue
				isSpeaking = false;
				scriptIndex = 0;
			}

			if (Input.GetButtonDown ("Action") && !justBeganTalking) {
				if (displayText.Length < formattedDialogue [scriptIndex].Length) {
					// Show full line if text is not completely displayed
					displayText = formattedDialogue [scriptIndex];
				} else {
					// Move on to the next line if text is completely displayed
					scriptIndex++;
					timer = 0;
					displayText = "";
				}
			}

			justBeganTalking = false;
		}
			

		textPosition = Camera.main.WorldToViewportPoint (transform.position);
		textPosition.x *= Screen.width;
		textPosition.y = 1 - textPosition.y;
		textPosition.y *= Screen.height;
		//textPosition.y -= 40;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			if (Input.GetButtonDown ("Action") && !isSpeaking) {
				isSpeaking = true;
				justBeganTalking = true;
				scriptIndex = 0;
				timer = 0;
			}
		}
	}

	void OnGUI() {
		if (isSpeaking) {
			GUI.Label (new Rect (textPosition, new Vector2 (300, 100)), displayText, textStyle);
		}
	}
}
