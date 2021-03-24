using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private GameObject HowtoPlayObject;

	private void Awake()
	{
		HowtoPlayObject.SetActive( false );
	}

	public void LoadFirstScene()
	{
		AudioManager.PlayAudioAtPosition( Vector3.zero, AudioClipManager.instance.GetAudioClip( "sfx_select" ), 0.2f, false );
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
	}

	public void LoadHowToPlayMenu()
	{
		AudioManager.PlayAudioAtPosition( Vector3.zero, AudioClipManager.instance.GetAudioClip( "sfx_select" ), 0.2f, false );
		HowtoPlayObject.SetActive( !HowtoPlayObject.activeInHierarchy );
	}

	public void QuitGame()
	{
		AudioManager.PlayAudioAtPosition( Vector3.zero, AudioClipManager.instance.GetAudioClip( "sfx_select" ), 0.2f, false );
		Application.Quit();
	}
}
