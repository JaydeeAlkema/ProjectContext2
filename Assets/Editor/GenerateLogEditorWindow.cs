using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ExampleNamespace;

#if UNITY_EDITOR

public class GenerateLogEditorWindow : EditorWindow
{
	private static GenerateLogEditorWindow window;

	private string logPath;
	private int toolbarInt = 0;
	string[] toolbarTabTitles = { "HOME", "ADD LOG", "EDIT LOG", "REMOVE LOG" };

	[MenuItem( "Window/Logbook Generator" )]
	static void ShowWindow()
	{
		window = GetWindow<GenerateLogEditorWindow>( "Logbook Generator" );
		window.Show();
	}
	void OnGUI()
	{
		toolbarInt = GUILayout.Toolbar( toolbarInt, toolbarTabTitles );

		ShowContentsDependingOnToolbarInt();
	}

	private void ShowContentsDependingOnToolbarInt()
	{
		switch( toolbarInt )
		{
			// Welcome Page
			case 0:
				ShowWelcomeContents();
				break;

			// Add Log Page
			case 1:
				ShowAddLogContents();
				break;

			// Edit Log Page
			case 2:
				ShowEditLogContents();
				break;

			// Remove Log Page
			case 3:
				ShowRemoveLogContents();
				break;

			default:
				break;
		}
	}

	private void ShowWelcomeContents()
	{
		if( GUILayout.Button( "Select Log File" ) )
		{
			logPath = EditorUtility.OpenFilePanel( "Select Log File", "This can be a .doc/.docx/.txt etc.", "" );
			Debug.Log( logPath );
			EditorPrefs.SetString( "LogbookGenerator_LogPath", logPath );
		}

		GUILayout.Label( "Current Path:" );
		GUILayout.Label( logPath, EditorStyles.wordWrappedLabel);
	}
	private void ShowAddLogContents()
	{
		//TODO:
		// Fix formating and make this look beter!

		string user = GUILayout.TextField( "User Name" );
		string title = GUILayout.TextField( "Log Title" );
		string message = GUILayout.TextArea( "Log Message" );
		string notes = GUILayout.TextArea( "Log Notes" );

		GUILayout.FlexibleSpace();
		if( GUILayout.Button( "Complete" ) )
		{
			GenerateLog.WriteToLog( logPath, user, title, message, notes );
		}
	}
	private void ShowEditLogContents()
	{
		GUILayout.Label( "Edit Log" );

	}
	private void ShowRemoveLogContents()
	{
		GUILayout.Label( "Remove Log" );

	}
}
#endif