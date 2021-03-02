using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantableGround : Clickable
{
	[SerializeField] private Animator anim;
	[SerializeField] private MeshRenderer meshRenderer;
	[Space]
	[SerializeField] private ClickableState state = ClickableState.INACTIVE;
	[SerializeField] private GameObject interactionParticles = default;
	[SerializeField] private List<Clickable> requiredActiveClickables = new List<Clickable>();
	[Space]
	[SerializeField] private Material InfirtleGroundMaterial;
	[SerializeField] private Material FirtleGroundMaterial;

	public override bool clicked { get; set; }

	private void Start()
	{
		anim = GetComponent<Animator>();
		meshRenderer.GetComponent<MeshRenderer>();

		meshRenderer.sharedMaterial = InfirtleGroundMaterial;

		SetAnimatorState();
		interactionParticles.SetActive( false );

	}

	private void FixedUpdate()
	{
		CheckIfAllClickableAreActive();
	}

	private void OnMouseDown()
	{
		Click();
	}

	public override void Click()
	{
		clicked = true;
		SetAnimatorState();
	}

	private void SetAnimatorState()
	{
		switch( state )
		{
			case ClickableState.INACTIVE:
				anim.SetBool( "Planted", false );
				break;
			case ClickableState.ACTIVE:
				anim.SetBool( "Planted", true );
				Destroy( interactionParticles );
				break;
			default:
				break;
		}
	}

	private void CheckIfAllClickableAreActive()
	{
		Debug.Log( "Checking for Clicked Clickables." );

		foreach( Clickable clickable in requiredActiveClickables )
		{
			if( clickable.clicked != true )
			{
				state = ClickableState.INACTIVE;
				return;
			}
		}
		state = ClickableState.ACTIVE;
		if( interactionParticles ) interactionParticles.SetActive( true );
		meshRenderer.sharedMaterial = FirtleGroundMaterial;
	}
}
