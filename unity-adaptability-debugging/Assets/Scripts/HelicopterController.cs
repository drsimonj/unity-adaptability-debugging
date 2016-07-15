using UnityEngine;
using System.Collections;

public class HelicopterController : MonoBehaviour {

	public float speed = 5.0f;  // Speed at which helicopter can rotate around the player
	public float flyHeight = 50.0f;  // Height above player tobe positioned
	public float flyradius = 10.0f;  // Horizontal distance from player

	private Transform player;
	private Vector3 offset;

	void Start () {
		// Find Player object based on tag
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		// Initialize starting position
		offset = new Vector3 (flyradius, flyHeight, 0.0f);
		//transform.position = player.transform.position + offset;
	}

	void LateUpdate () {
		// Maintain position relative to player
		transform.position = player.transform.position + offset;

		// Always look at the player
		transform.LookAt (player);

		// Control orbit position around the player
		float moveHorizontal = Input.GetAxis ("Horizontal");

		// If orbiting, move and calculate new offset
		if (moveHorizontal != 0.0f) {
			transform.Translate (Vector3.right * moveHorizontal * speed * Time.deltaTime); 
			offset = transform.position - player.transform.position;
		}
	}
}
