using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class PersistentAudioClip : MonoBehaviour
{
	[SerializeField] [Required] private AudioClip audioClip;
	[SerializeField] [Required] private AudioSource audioSource;
	[SerializeField] private int stopAtSceneIndex = -1;

	private void Awake()
	{
		DontDestroyOnLoad( gameObject );
		Debug.Log( "Don't destroy on load: " + transform.name );
	}

	private void OnEnable()
	{
		Debug.Log( "OnEnable Called" );
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		Debug.Log( "OnDisable Called" );
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		audioSource.Play();
	}

	public void OnSceneLoaded( Scene scene, LoadSceneMode mode )
	{
		if( scene.buildIndex == stopAtSceneIndex )
		{
			Debug.Log( "I've reached my end, Goodbye!" );
			Destroy( this.gameObject );
		}
	}
}
