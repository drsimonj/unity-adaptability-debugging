using UnityEngine;
using System.Collections;
using System.IO;

public class LogManager : MonoBehaviour {

	// Session data
	public string uid = "testUser";
	public int GmtPlus = 10;  // The GMT + (hours) of local timezone for logging; Default = 10 for Sydney, Australia.
	private static System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

	// File Directories and Paths
	[HideInInspector]
	public string logDirectory;
	public string sessionLogPath;
	public string eventLogPath;  // Common file for all events.
	public string streamLogDirectory;  // Paths to stream logs are set in relevant scripts, but placed in this dedicated directory

	void Awake ()
	{
		// Set File directories and Paths
		logDirectory       = Application.dataPath + "/logs/" + uid + "/";  // Log directory for user in Assets/logs/
		sessionLogPath     = logDirectory + "session.txt";
		eventLogPath       = logDirectory + "events.txt";
		streamLogDirectory = logDirectory + "streams/";

		//check if exists/create directories
		/*if(!Directory.Exists(logDirectory))
		{    
			Directory.CreateDirectory(logDirectory);
		}*/

		if(!Directory.Exists(streamLogDirectory))
		{    
			Directory.CreateDirectory(streamLogDirectory);
		}

		// Log session details
		StreamWriter sw = new StreamWriter(sessionLogPath);
		sw.WriteLine ("Session details:");
		sw.WriteLine ( "" );
		sw.WriteLine ("start\t" + System.DateTime.UtcNow.AddHours (GmtPlus));
		sw.WriteLine ("GMT+\t" + GmtPlus.ToString());
		sw.WriteLine ("uid\t" + uid);
		sw.Close();
	}

	// For event logging
	public void Log (string PathToLog, string eventName) {
		Log (PathToLog, eventName, "");
	}
	public void Log (string PathToLog, string eventName, string additional) {
		File.AppendAllText(PathToLog, EpochTime ().ToString() + "\t" + eventName + "\t" + additional + "\n");
	}

	// For stream logging
	public void Log (string PathToLog, double value) {
		File.AppendAllText(PathToLog, EpochTime ().ToString() + "\t" + value.ToString() + "\n");
	}

	// To get Epoch Time
	public static double EpochTime () {
		return (((System.DateTime.UtcNow - epochStart).TotalMilliseconds * 100));  // * 100 to remove decimal places
	}
}
