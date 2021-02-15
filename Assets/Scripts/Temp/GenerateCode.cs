using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ExampleNamespace;

public class GenerateCode : MonoBehaviour
{
	MethodInfo[] publicMethodInfos;

	// Start is called before the first frame update
	void Start()
	{
		Generate( typeof( ExampleClass ) );
	}

	private void Generate( System.Type myType )
	{
		StringBuilder sb = new StringBuilder();

		publicMethodInfos = typeof( ExampleClass ).GetMethods( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly );

		// Write File
		Include( sb );
		NameSpaceOpen( sb, myType.Namespace );
		Class( sb, "I" + myType.Name );
		NameSpaceClose( sb );

		// Send File
		//Debug.Log( sb.ToString() );
		StreamWriter sw = new StreamWriter( Path.Combine( Application.dataPath, "Scripts/Generated/" + "I" + myType.Name + ".cs" ) );
		sw.Write( sb );
		sw.Flush();
		sw.Close();

		AssetDatabase.Refresh();
	}

	void Include( StringBuilder sb )
	{
		sb.AppendLine( "using UnityEngine;" );
	}

	void NameSpaceOpen( StringBuilder sb, string nameSpace )
	{
		sb.AppendLine( "namespace " + nameSpace + "\n{" );
	}

	void Class( StringBuilder sb, string className )
	{
		sb.AppendLine( "\tpublic interface " + className + " {" );

		foreach( MethodInfo method in publicMethodInfos )
		{
			ParameterInfo[] parameters = method.GetParameters();
			string parametersToString = "";
			if( method.GetParameters().Length > 0 )
			{
				foreach( ParameterInfo parameter in parameters )
				{
					string pts = parameter.ParameterType.Name.ToLower() + " " + parameter.Name;
					parametersToString += pts;
				}

				sb.AppendLine( "\t\t " + method.ReturnType.Name.ToLower() + " " + method.Name + "(" + parametersToString + ");" );
			}
			else
			{
				sb.AppendLine( "\t\t " + method.ReturnType.Name.ToLower() + " " + method.Name + "();" );
			}
		}

		sb.AppendLine( "\t}" );
	}

	void NameSpaceClose( StringBuilder sb )
	{
		sb.AppendLine( "}" );
	}

}
