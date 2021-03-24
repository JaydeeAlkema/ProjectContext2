using NaughtyAttributes;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
	[SerializeField] private static SceneFader instance;
	[SerializeField] [Required] private Animator animator;
	[SerializeField] private PhotoTriggerManager photoTriggerManager;
	[SerializeField] private SceneSwitcher sceneSwitcher;

	public static SceneFader Instance { get; set; }

	private void Awake()
	{
		if( !Instance || Instance != this )
		{
			Destroy( Instance );
			Instance = this;
		}
	}

	private void Start()
	{
		// the scene always starts with a fade out.
		FadeOut();
	}

	/// <summary>
	/// Starts the Fade In Animation.
	/// </summary>
	public void FadeIn()
	{
		animator.SetBool( "FadeIn", true );
		animator.SetBool( "FadeOut", false );
	}

	/// <summary>
	/// Starts the Fade Out Animation.
	/// </summary>
	public void FadeOut()
	{
		animator.SetBool( "FadeIn", false );
		animator.SetBool( "FadeOut", true );
	}

	public void TriggerPhotographs()
	{
		if( photoTriggerManager )
			photoTriggerManager.TriggerPhotographs();
	}

	public void SwitchToNextScene()
	{
		if( sceneSwitcher )
			sceneSwitcher.SwitchToScene();
	}
}
