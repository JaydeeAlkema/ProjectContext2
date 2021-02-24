using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class GenerateLog
{
	public static void WriteToLog( string logPath, string user, string title, string message, string notes )
	{
		//Debug.Log( logPath + "\n" + user + "\n" + title + "\n" + message + "\n" + notes );

		StringBuilder sb = new StringBuilder();

		// Write File

		// Send File
		StreamWriter sw = new StreamWriter( logPath );
		sw.Write( sb );
		sw.Flush();
		sw.Close();
	}
}
