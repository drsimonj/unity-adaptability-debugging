using UnityEngine;
using System.Collections;

public class HelicopterReporting : MonoBehaviour {

	public GameObject LogMenu;
	public string ShowMenuKey = "escape";

	private bool isShowing = false;

	void Start () {
		LogMenu.SetActive (isShowing);
	}

	void Update () {
		if (Input.GetKeyDown(ShowMenuKey)) {
			isShowing = !isShowing;
			LogMenu.SetActive(isShowing);
		}
	}
}
