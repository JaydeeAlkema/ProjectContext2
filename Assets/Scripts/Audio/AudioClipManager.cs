using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
	[SerializeField] public static AudioClipManager instance;
	[SerializeField] private List<SoundEffect> sounds = new List<SoundEffect>();

	private void Awake()
	{
		if( !instance || instance != this )
		{
			Destroy( instance );
			instance = this;
		}
	}

	/// <summary>
	/// Finds and returns the audioclip with the given name.
	/// </summary>
	/// <param name="name"> Name of the audioclip to search for in the list of sounds. </param>
	/// <returns></returns>
	public AudioClip GetAudioClip( string name )
	{
		for( int i = 0; i < sounds.Count; i++ )
		{
			if( sounds[i].Name == name )
			{
				return sounds[i].AudioClip;
			}
		}

		Debug.LogWarning( "Could not find audioclip by the name of " + name + ". Check if the name is correct! (Case Sensitive)" );
		return null;
	}
}

[System.Serializable]
public struct SoundEffect
{
	[SerializeField] private string name;
	[SerializeField] private AudioClip audioClip;

	public string Name { get => name; set => name = value; }
	public AudioClip AudioClip { get => audioClip; set => audioClip = value; }
}
