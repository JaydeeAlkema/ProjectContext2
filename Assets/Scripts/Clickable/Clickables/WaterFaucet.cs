using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFaucet : MonoBehaviour
{
	public void ToggleParticles( GameObject particles )
	{
		particles.SetActive( !particles.activeSelf );
	}
}
