using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum PlayerMovementState
{
	IDLE = 0,
	WALKING = 1
}

public class PlayerMovement : MonoBehaviour
{

	[BoxGroup( "Components" )] [SerializeField] [Required] private Rigidbody rigidBody;
	[BoxGroup( "Components" )] [SerializeField] [Required] private Animator animator;
	[BoxGroup( "Components" )] [SerializeField] [Required] private Transform model;

	[BoxGroup( "Input" )] [SerializeField] [InputAxis] private string horizontalMovementInputAxis = "";

	[BoxGroup( "Movement Values" )] [SerializeField] private float movementSpeed;

	[BoxGroup( "Debug" )] [SerializeField] private float movementInput;
	[BoxGroup( "Debug" )] [SerializeField] private PlayerMovementState movementState = PlayerMovementState.IDLE;

	public void Update()
	{
		movementInput = Input.GetAxisRaw( horizontalMovementInputAxis );
	}

	public void FixedUpdate()
	{
		Move();
	}

	public void Move()
	{
		rigidBody.velocity = transform.forward * ( movementInput * movementSpeed );

		// Animation
		if( movementInput != 0 )
		{
			animator.SetBool( "Walking", true );
		}
		else
		{
			animator.SetBool( "Walking", false );
		}

		// Turning
		if( rigidBody.velocity.x > 0 )
		{
			model.Rotate( new Vector3( 0, 90, 0 ) );
		}
		else if( rigidBody.velocity.x < 0 )
		{
			model.Rotate( new Vector3( 0, -90, 0 ) );
		}
	}
}
