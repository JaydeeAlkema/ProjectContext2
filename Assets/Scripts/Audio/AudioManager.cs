using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
	/// <summary>
	/// Plays an audioclip at the given position and volume.
	/// </summary>
	/// <param name="pos"> Where to play the audio clip. (world coordinates)</param>
	/// <param name="clip"> Which audioclip to play. </param>
	/// <param name="volume"> How loud it should be. </param>
	/// <param name="loop"> If the audioclip should loop. </param>
	public static void PlayAudioAtPosition( Vector3 pos, AudioClip clip, float volume, bool loop )
	{
		GameObject sound = new GameObject( "Sound" );
		sound.transform.position = pos;
		AudioSource audioSource = sound.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.maxDistance = 100f;
		audioSource.spatialBlend = 1f;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.dopplerLevel = 0f;
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.Play();

		if( !loop ) Object.Destroy( sound, clip.length );
	}
}
