using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PhotoTriggerManagerState
{
	BUSY = 0,
	DONE = 1
}
public class PhotoTriggerManager : MonoBehaviour
{
	[SerializeField] private PhotoTriggerManagerState state = PhotoTriggerManagerState.BUSY;
	[SerializeField] private List<PhotoGraphObject> imagesToFade = new List<PhotoGraphObject>();

	public void TriggerPhotographs()
	{
		foreach( PhotoGraphObject photoGraphObject in imagesToFade )
		{
			photoGraphObject.animator.SetBool( "FadeIn", true );
		}
	}
}

[System.Serializable]
public struct PhotoGraphObject
{
	public string name;
	public Animator animator;
}