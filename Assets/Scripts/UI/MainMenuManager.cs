using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public void LoadFirstScene()
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
	}

	public void LoadHowToPlayMenu()
	{
		Debug.Log( "Not yet implemented!" );
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
