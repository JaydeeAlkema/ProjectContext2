using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	[SerializeField] private int sceneIndexToSwitchTo;
	[SerializeField] private PlantableGround plantable;

	public void SwitchToScene()
	{
		SceneManager.LoadSceneAsync( sceneIndexToSwitchTo );
	}

	private void OnTriggerEnter( Collider other )
	{
		if( other.GetComponent<IPlayable>() != null && plantable != null && plantable.PlanteableGroundState == PlantableGroundState.COMPLETE )
		{
			SceneFader.Instance.FadeIn();
			Debug.Log( "test1" );
		}
		else if( other.GetComponent<IPlayable>() != null && plantable == null )
		{
			SceneFader.Instance.FadeIn();
			Debug.Log( "test2" );
		}
		Debug.Log( "test3" );
	}
}
