using UnityEngine;
using System.Collections;

public class AutoOrbitPlayer : MonoBehaviour {

	public GameObject OrbitPosition;

	void Update () {
		// Just orbit the "Player" around the worldCentre to create movement
		transform.RotateAround (OrbitPosition.transform.position, new Vector3 (0, 1, 0), 10 * Time.deltaTime);
	}
}
