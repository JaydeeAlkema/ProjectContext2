using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronCart : MonoBehaviour
{
	[SerializeField] private Vector3 desiredPos = Vector3.zero;

	public void MoveCart()
	{
		StartCoroutine( CartMoveEvent() );
	}

	private IEnumerator CartMoveEvent()
	{
		bool posReached = false;
		while( !posReached )
		{
			transform.position = Vector3.Lerp( transform.position, desiredPos, 3f * Time.deltaTime );

			if( transform.position == desiredPos )
			{
				posReached = true;
			}

			yield return null;
		}
		yield return null;
	}
}
