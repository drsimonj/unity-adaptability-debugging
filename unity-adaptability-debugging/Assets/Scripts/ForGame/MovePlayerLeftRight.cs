using UnityEngine;
using System.Collections;

public class MovePlayerLeftRight : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Vars for logging data.
	private LogManager lm;
	private string eventLogName_collisions = "cube_collision";    // note that we can create multiple event types, just add where necessary
	private string streamLogFile_horizontal = "cube_horizontal";  // We can create multiple stream files like this (dif names and add in start() as example below shows).
	private string streamLogFile_vertical = "cube_vertical";

	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		// Set up Log Manager and stream log file paths
		lm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LogManager> ();
		streamLogFile_horizontal = lm.CreateStreamPath (streamLogFile_horizontal);
		streamLogFile_vertical = lm.CreateStreamPath (streamLogFile_vertical);
	}

	// Stream log of the horizontal force applied through the keyboard
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical   = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		lm.Log (streamLogFile_horizontal, moveHorizontal);
		lm.Log (streamLogFile_vertical,   moveVertical);
	}

	// Event log
	void OnCollisionEnter (Collision col) {
		lm.Log (eventLogName_collisions, col.gameObject.name);
	}
}
