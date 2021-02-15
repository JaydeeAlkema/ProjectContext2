using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using ExampleNamespace;

public class Lesson2 : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		//MessingWithMethodInfos();
		CodeGeneration();
	}

	private static void MessingWithMethodInfos()
	{
		MethodInfo[] methodInfos = typeof( ExampleClass ).GetMethods( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly );

		// Public Methods
		Debug.Log( " ALL PUBLIC FUNCTIONS " );
		foreach( MethodInfo method in methodInfos )
		{
			Debug.Log( method.Name );
		}

		// Public Methods, But only ones WITHOUT parameters.
		Debug.Log( " ALL PUBLIC FUNCTIONS WITHOUT PARAMETERS" );
		foreach( MethodInfo method in methodInfos )
		{
			if( method.GetParameters().Length == 0 )
				Debug.Log( method.Name );
		}

		// Call GetSecret private method, And SetSecret with custom parameter.
		Debug.Log( " GET SECRET " );
		ExampleClass myInstance = new ExampleClass();

		MethodInfo getSecret = typeof( ExampleClass ).GetMethod( "GetSecret", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly );
		Debug.Log( getSecret.Invoke( myInstance, null ) );

		MethodInfo setSecret = typeof( ExampleClass ).GetMethod( "SetSecret", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly );
		setSecret.Invoke( myInstance, new object[] { "Not so secret anymore :)" } );

		Debug.Log( getSecret.Invoke( myInstance, null ) );
	}

	private static void CodeGeneration()
	{

	}
}
