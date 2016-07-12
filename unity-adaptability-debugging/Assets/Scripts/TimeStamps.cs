using UnityEngine;
using System.Collections;

public class TimeStamps : MonoBehaviour {

	private System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
	private double epochTime;

	void Start() {
		Debug.Log (System.DateTime.UtcNow);
	}

	void Update () {
		epochTime = (System.DateTime.UtcNow - epochStart).TotalMilliseconds;
		Debug.Log (epochTime);
	}
}