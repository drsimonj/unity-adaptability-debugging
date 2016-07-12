using UnityEngine;
using System.Collections;

public class MovePlayerLeftRight : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Vars for logging data.
	private LogManager lm;
	private string eventLogPath;
	private string streamLogPath_horizontal = "cube_horizontal.txt";  // Note that we can create multiple stream files like this (dif names and add in start()).

	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		// Set up Log Manager and log file paths
		lm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LogManager> ();
		eventLogPath = lm.eventLogPath;
		streamLogPath_horizontal = lm.streamLogDirectory + streamLogPath_horizontal;
	}

	// Stream log of the horizontal force applied through the keyboard
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.AddForce (movement * speed);

		lm.Log (streamLogPath_horizontal, moveHorizontal);
	}

	// Event log
	void OnCollisionEnter (Collision col) {
		lm.Log (eventLogPath, "cube_collision", col.gameObject.name);
	}
}
