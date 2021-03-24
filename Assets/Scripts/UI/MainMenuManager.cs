using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public void LoadFirstScene()
	{
		AudioManager.PlayAudioAtPosition(Vector3.zero, AudioClipManager.instance.GetAudioClip("sfx_select"), 0.2f, false);
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
	}

	public void LoadHowToPlayMenu()
	{
		AudioManager.PlayAudioAtPosition(Vector3.zero, AudioClipManager.instance.GetAudioClip("sfx_select"), 0.2f, false);
		Debug.Log( "Not yet implemented!" );
	}

	public void QuitGame()
	{
		AudioManager.PlayAudioAtPosition(Vector3.zero, AudioClipManager.instance.GetAudioClip("sfx_select"), 0.2f, false);
		Application.Quit();
	}
}
