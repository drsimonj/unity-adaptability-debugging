using UnityEngine;
using System.Collections;

public class TimeStamps : MonoBehaviour {

	private System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
	private double epochTime;

	public double GetTime () {
		epochTime = (System.DateTime.UtcNow - epochStart).TotalMilliseconds * 100;  // * 100 to remove decimal places
		return (epochTime);
	}
}