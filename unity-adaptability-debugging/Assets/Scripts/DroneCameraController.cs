using UnityEngine;
using System.Collections;

public class DroneCameraController : MonoBehaviour {

	// Zoom settings
	public float zoom_speed = 20.0f;
	public float fov_min =  1.0f;  // Defines maximum zoom (min field of view)
	public float fov_max = 20.0f;  // Defines minimum zoom (max field of view)

	// Camera Rotation settings
	public float rotate_speed = 10.0f;
	public float min_angle = -15.0f;
	public float max_angle =  15.0f;

	// Zoom values
	private int zoom_in = 0;
	private int zoom_out = 0;

	// Camera Rotation Values
	private float xrotate = 0.0f;
	private float yrotate = 0.0f;

	// Camera component
	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Camera Rotation
		xrotate += Input.GetAxis ("Vertical") * rotate_speed * Time.deltaTime;
		xrotate = Mathf.Clamp (xrotate, min_angle, max_angle);
		yrotate += Input.GetAxis ("Horizontal") * rotate_speed * Time.deltaTime;
		yrotate = Mathf.Clamp (yrotate, min_angle, max_angle);
		transform.localEulerAngles = new Vector3(xrotate, -yrotate, 0);

		// Camera Zoom
		zoom_in  = Input.GetKey (KeyCode.X) ?  1 : 0;
		zoom_out = Input.GetKey (KeyCode.Z) ? -1 : 0;
		camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + (zoom_in + zoom_out) * zoom_speed * Time.deltaTime, fov_min, fov_max);
	}
}
