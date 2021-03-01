using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantableGround : MonoBehaviour, IClickable
{
	[SerializeField] private IClickable.ClickableState state = IClickable.ClickableState.INACTIVE;
	[SerializeField] private GameObject interactionParticles = default;
	[SerializeField] private List<IClickable> requiredActiveClickables = new List<IClickable>();

	private Animator anim;

	public bool clicked { get; set; }

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void OnMouseDown()
	{
		Click();
	}

	public void Click()
	{
		CheckIfAllClickableAreActive();
	}

	private void SetAnimatorState()
	{
		switch( state )
		{
			case IClickable.ClickableState.INACTIVE:
				anim.SetBool( "Planted", false );
				interactionParticles.SetActive( true );
				break;
			case IClickable.ClickableState.ACTIVE:
				anim.SetBool( "Planted", true );
				interactionParticles.SetActive( false );
				break;
			default:
				break;
		}
	}

	private void CheckIfAllClickableAreActive()
	{
		foreach( IClickable clickable in requiredActiveClickables )
		{
			if( clickable.clicked )
				continue;
			else
				break;
		}
		SetAnimatorState();
	}
}
