using UnityEngine;
using System.Collections;
using System.IO;

public class LogToFile : MonoBehaviour {

	public int GmtPlus = 10;  // The GMT + of local timezone for logging; Default = 10 for Sydney, Australia.

	private static string uid = "testUser";
	private static string logDirectory = Application.dataPath + "/logs/" + uid + "/";
	private static System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

	// Log File Paths
	private static string sessionLogPath = logDirectory + "a_session_log.txt";
	private static string eventLogPath   = logDirectory + "an_event_log.txt";
	private static string streamLogPath  = logDirectory + "a_stream_log.txt";

	private double epochTime;
	private static StreamWriter sw;

	void Start ()
	{
		//check if exists/create "logs/uid" directory in Assets folder
		if(!Directory.Exists(logDirectory))
		{    
			Directory.CreateDirectory(logDirectory);
		}

		// Commence Log file
		sw = new StreamWriter(sessionLogPath);
		sw.WriteLine ("Session details:");
		sw.WriteLine ( "" );
		sw.WriteLine ("start\t" + System.DateTime.UtcNow.AddHours (GmtPlus));
		sw.WriteLine ("GMT+\t" + GmtPlus.ToString());
		sw.WriteLine ("uid\t" + uid);
		sw.Close();
	}

	void Update () {
		Log (eventLogPath, "a_log");
		Log (eventLogPath, "a_log2", "x:1 y:2 z:3");
		Log (streamLogPath, 10.0384);
	}

	// For event logging
	public static void Log (string PathToLog, string eventName) {
		Log (PathToLog, eventName, "");
	}
	public static void Log (string PathToLog, string eventName, string additional) {
		File.AppendAllText(PathToLog, EpochTime ().ToString() + "\t" + eventName + "\t" + additional + "\n");
	}

	// For stream logging
	public static void Log (string PathToLog, double value) {
		File.AppendAllText(PathToLog, EpochTime ().ToString() + "\t" + value.ToString() + "\n");
	}

	// To get Epoch Time
	public static double EpochTime () {
		return (((System.DateTime.UtcNow - epochStart).TotalMilliseconds * 100));  // * 100 to remove decimal places
	}
}
