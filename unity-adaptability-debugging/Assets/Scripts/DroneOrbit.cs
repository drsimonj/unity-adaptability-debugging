using UnityEngine;
using System.Collections;

public class DroneOrbit : MonoBehaviour {

	/* the object to orbit */
	public Transform target;

	/* speed of orbit (in degrees/second) */
	public float speed = 2.0f;

	void Start() {
		if (target == null) {
			target = transform.parent.gameObject.transform;
		}
	}

	void Update()
	{
			transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
	}
}
