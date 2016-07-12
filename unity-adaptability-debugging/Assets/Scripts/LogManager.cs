using UnityEngine;
using System.Collections;
using System.IO;

public class LogManager : MonoBehaviour {

	// Session data
	public string user_id = "testUser";
	private static System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

	// File Directories and Paths
	[HideInInspector]
	public string logDirectory;        // Directory for all log files
	[HideInInspector]
	public string sessionLogPath;      // Common session log file
	[HideInInspector]
	public string eventLogPath;        // Common events log file
	[HideInInspector]
	public string streamLogDirectory;  // Paths to stream logs are set in relevant scripts, but placed in this dedicated directory

	void Awake ()
	{
		// Set File directories and Paths
		logDirectory       = Application.dataPath + "/logs/" + user_id + "_" + EpochTime() + "/";  // Log directory for user in Assets/logs/ ; EpochTime() so as not to override multiple trials of same user.
		sessionLogPath     = logDirectory + "session.tsv";
		eventLogPath       = logDirectory + "events.tsv";
		streamLogDirectory = logDirectory + "streams/";

		//check if exists/create directories
		if(!Directory.Exists(streamLogDirectory))
		{    
			Directory.CreateDirectory(streamLogDirectory);
		}

		// Log session details
		StreamWriter sw = new StreamWriter(sessionLogPath);
		sw.WriteLine ("local_start_time\t" + System.DateTime.UtcNow.ToLocalTime());
		sw.WriteLine ("user_id\t" + user_id);
		sw.Close();
	}

	// For event logging
	public void Log (string eventName) {
		Log (eventName, "");
	}
	public void Log (string eventName, string additional) {
		File.AppendAllText(eventLogPath, EpochTime ().ToString() + "\t" + eventName + "\t" + additional + "\n");
	}

	// For stream logging
	public void Log (string PathToLog, double value) {
		File.AppendAllText(PathToLog, EpochTime ().ToString() + "\t" + value.ToString() + "\n");
	}

	// To get Epoch Time
	public static double EpochTime () {
		return (((System.DateTime.UtcNow - epochStart).TotalMilliseconds * 100));  // * 100 to remove decimal places
	}

	// Convert a string into a stream log file path of file-type .tsv
	public string CreateStreamPath (string SteamLogFileName) {
		return(streamLogDirectory + SteamLogFileName + ".tsv");
	}
}
