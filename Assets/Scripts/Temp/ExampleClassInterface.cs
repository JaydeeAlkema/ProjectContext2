using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ExampleClassInterface
{
	void GetName();
	void SetName( string newName );

	void Prepare();
	void DoSomething();

	void SetSecret( string newSecret );
	string GetSecret();
}
