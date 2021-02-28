using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class GenerateLog
{
	private static List<LogEntry> entries = new List<LogEntry>();

	public static void GetEntriesFromLogFile( string logPath )
	{
		//TODO:
		// Fill the entries list from reading each line of the file.
		string[] lines = System.IO.File.ReadAllLines( logPath );

		foreach( string line in lines )
		{
			Debug.Log( line );
		}
	}

	public static void WriteToLog( string logPath, string user, string title, string message, string notes )
	{
		//Debug.Log( logPath + "\n" + user + "\n" + title + "\n" + message + "\n" + notes );
		LogEntry entry = new LogEntry
		{
			username = user,
			title = title,
			message = message,
			notes = notes
		};

		entries.Add( entry );

		StringBuilder sb = new StringBuilder();

		// Write File
		sb.AppendLine( GetDate() );
		sb.AppendLine( entry.username );
		sb.AppendLine( entry.title + "\n" );
		sb.AppendLine( entry.message + "\n" );
		sb.AppendLine( entry.notes );
		sb.AppendLine( "\n" + "------------------------------------------------------------------------" + "\n" );

		// Send File
		StreamWriter sw = new StreamWriter( logPath, true );
		sw.Write( sb );
		sw.Flush();
		sw.Close();
	}

	private static string GetDate()
	{
		string day = System.DateTime.Now.Day.ToString();
		string month = System.DateTime.Now.Month.ToString();
		string year = System.DateTime.Now.Year.ToString();

		string time = System.DateTime.Now.ToString( "HH:mm:ss" );

		return day + "/" + month + "/" + year + " " + time;
	}
}

public struct LogEntry
{
	public string username { get; set; }
	public string title { get; set; }
	public string message { get; set; }
	public string notes { get; set; }
}
