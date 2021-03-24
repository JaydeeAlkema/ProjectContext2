using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	[SerializeField] private int sceneIndexToSwitchTo;

	public void SwitchToScene()
	{
		SceneManager.LoadSceneAsync( sceneIndexToSwitchTo );
	}

	private void OnTriggerEnter( Collider other )
	{
		if( other.GetComponent<IPlayable>() != null )
		{
			SceneFader.Instance.FadeIn();
		}
	}
}
