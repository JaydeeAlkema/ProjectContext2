using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantableGroundState
{
	INCOMPLETE = 0,
	COMPLETE = 1
}

public class PlantableGround : Clickable
{
	[SerializeField] private PlantableGroundState planteableGroundState = PlantableGroundState.INCOMPLETE;
	[SerializeField] private Animator anim;
	[SerializeField] private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
	[Space]
	[SerializeField] private ClickableState clickableState = ClickableState.INACTIVE;
	[SerializeField] private GameObject interactionParticles = default;
	[SerializeField] private List<Clickable> requiredActiveClickables = new List<Clickable>();
	[Space]
	[SerializeField] private Material InfirtleGroundMaterial;
	[SerializeField] private Material FirtleGroundMaterial;

	public override bool clicked { get; set; }
	public PlantableGroundState PlanteableGroundState { get => planteableGroundState; set => planteableGroundState =  value ; }

	private void Start()
	{
		if( !anim ) anim = GetComponent<Animator>();

		foreach( MeshRenderer meshRenderer in meshRenderers )
		{
			meshRenderer.GetComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = InfirtleGroundMaterial;
		}

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
		switch( clickableState )
		{
			case ClickableState.INACTIVE:
				anim.SetBool( "Planted", false );
				break;
			case ClickableState.ACTIVE:
				anim.SetBool( "Planted", true );
				planteableGroundState = PlantableGroundState.COMPLETE;
				Destroy( interactionParticles );
				break;
			default:
				break;
		}
	}

	private void CheckIfAllClickableAreActive()
	{
		//Debug.Log( "Checking for Clicked Clickables." );

		foreach( Clickable clickable in requiredActiveClickables )
		{
			if( clickable.clicked != true )
			{
				clickableState = ClickableState.INACTIVE;
				return;
			}
		}

		clickableState = ClickableState.ACTIVE;
		if( interactionParticles ) interactionParticles.SetActive( true );

		foreach( MeshRenderer meshRenderer in meshRenderers )
		{
			meshRenderer.sharedMaterial = FirtleGroundMaterial;
		}
	}
}
