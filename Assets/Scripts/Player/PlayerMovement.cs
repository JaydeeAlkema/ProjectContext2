using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum PlayerMovementState
{
	NONE = 0,
	IDLE = 1,
	WALKING = 2
}

public enum PlayerState
{
	NONE = 0,
	CONTROLLED = 1,
	CONTROLABLE = 2
}

public class PlayerMovement : MonoBehaviour
{
	[BoxGroup( "Components" )] [SerializeField] [Required] private Rigidbody rigidBody;
	[BoxGroup( "Components" )] [SerializeField] [Required] private Animator animator;
	[BoxGroup( "Components" )] [SerializeField] [Required] private Transform model;

	[BoxGroup( "Input" )] [SerializeField] [InputAxis] private string horizontalMovementInputAxis = "";

	[BoxGroup( "Movement Values" )] [SerializeField] private float movementSpeed;
	[BoxGroup( "Movement Values" )] [SerializeField] private float minClampPosZ;
	[BoxGroup( "Movement Values" )] [SerializeField] private float maxClampPosZ;

	[BoxGroup( "At Scene Start" )] [SerializeField] private bool moveIntoScene = false;
	[BoxGroup( "At Scene Start" )] [EnableIf( "moveIntoScene" )] [SerializeField] private Vector3 movementTarget = Vector3.zero;
	[BoxGroup( "At Scene Start" )] [EnableIf( "moveIntoScene" )] [SerializeField] [Range( -1f, 1f )] private float stoppingDistance = 0f;
	[BoxGroup( "At Scene Start" )] [EnableIf( "moveIntoScene" )] [SerializeField] [ReadOnly] private bool doneMoving = false;

	[BoxGroup( "Debug" )] [SerializeField] private float movementInput;
	[BoxGroup( "Debug" )] [SerializeField] private PlayerMovementState movementState = PlayerMovementState.NONE;
	[BoxGroup( "Debug" )] [SerializeField] private PlayerState playerState = PlayerState.CONTROLABLE;

	public void Update()
	{
		movementInput = Input.GetAxisRaw( horizontalMovementInputAxis );

		ClampPosZ();
	}

	public void FixedUpdate()
	{
		if( moveIntoScene ) MoveTowardsPoint();
		Move();
		AnimateModel();
		RotateModel();
	}

	/// <summary>
	/// Moves, rotates and Animates the player.
	/// </summary>
	public void Move()
	{
		if( playerState == PlayerState.CONTROLABLE )
		{
			rigidBody.velocity = transform.forward * ( movementInput * movementSpeed );
		}
	}

	/// <summary>
	/// Rotates the model
	/// </summary>
	private void RotateModel()
	{
		// Turning
		if( rigidBody.velocity.z > 0 )
		{
			model.rotation = Quaternion.Euler( new Vector3( 0, 0, 0 ) );
		}
		else if( rigidBody.velocity.z < 0 )
		{
			model.rotation = Quaternion.Euler( new Vector3( 0, -180, 0 ) );
		}
	}

	/// <summary>
	/// Sets the Animator parameters.
	/// </summary>
	private void AnimateModel()
	{
		// Animation
		if( rigidBody.velocity.z != 0 )
		{
			animator.SetBool( "Walking", true );
			movementState = PlayerMovementState.WALKING;
		}
		else
		{
			animator.SetBool( "Walking", false );
			movementState = PlayerMovementState.IDLE;
		}
	}

	/// <summary>
	/// Moves the player towards the given point.
	/// </summary>
	private void MoveTowardsPoint()
	{
		if( !doneMoving )
		{
			float distanceToTarget = Vector3.Distance( transform.position, movementTarget );
			if( distanceToTarget >= stoppingDistance )
			{
				playerState = PlayerState.CONTROLLED;
				rigidBody.velocity = transform.forward * ( 1 * movementSpeed );
			}
			else
			{
				playerState = PlayerState.CONTROLABLE;
				doneMoving = true;
				rigidBody.velocity = Vector3.zero;
			}
		}
	}

	/// <summary>
	/// Clamp the Z position of the Player.
	/// </summary>
	private void ClampPosZ()
	{
		Vector3 pos = transform.position;
		pos.z = Mathf.Clamp( pos.z, minClampPosZ, maxClampPosZ );

		transform.position = pos;
	}
}
