using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalScene : MonoBehaviour
{
	[SerializeField] private VideoClip videoClip;

	private float shutdownTimer;

	private void Start()
	{
		shutdownTimer = ( float )videoClip.length + 5f;

		StartCoroutine( CloseGame() );
	}

	private IEnumerator CloseGame()
	{
		yield return new WaitForSeconds( shutdownTimer );
		SceneManager.LoadScene( 0 );
	}
}
