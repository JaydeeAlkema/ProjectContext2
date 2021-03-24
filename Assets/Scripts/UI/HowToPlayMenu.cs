using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
	[SerializeField] private GameObject menuObject;

	private void Awake()
	{
		ToggleMenuObject();
	}

	public void ToggleMenuObject()
	{
		menuObject.SetActive( !menuObject.activeInHierarchy );
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
