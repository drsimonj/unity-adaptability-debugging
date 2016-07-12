using UnityEngine;
using System.Collections;
using System.IO;

public class WriteToFile : MonoBehaviour {

	private static string uid = "testUser";
	private static string logPath = Application.dataPath + "/logs/" + uid + "/";

	void Start ()
	{
		//check if exists/create "logs/uid" directory in Assets folder
		if(!Directory.Exists(logPath))
		{    
			Directory.CreateDirectory(logPath);
		}

		WriteFile();
	}

	public static void WriteFile()
	{

		StreamWriter sw = new StreamWriter(logPath + "table.txt" );

		sw.WriteLine( "Generated table of 1 to 10" );
		sw.WriteLine( "" );

		for ( int i = 1; i <= 10; i++ )
		{
			for ( int j = 1; j <= 10; j++ )
			{
				sw.WriteLine( "{0}x{1}= {2}", i, j, (i*j) );
			}

			sw.WriteLine( "====================================" );
		}

		sw.WriteLine( "Table successfully written to file!");

		sw.Close();
	}
}
