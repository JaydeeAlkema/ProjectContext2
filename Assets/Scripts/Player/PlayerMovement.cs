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
	[BoxGroup( "Movement Values" )] [SerializeField] private float minClampPosZ;
	[BoxGroup( "Movement Values" )] [SerializeField] private float maxClampPosZ;

	[BoxGroup( "Debug" )] [SerializeField] private float movementInput;
	[BoxGroup( "Debug" )] [SerializeField] private PlayerMovementState movementState = PlayerMovementState.IDLE;

	public void Update()
	{
		movementInput = Input.GetAxisRaw( horizontalMovementInputAxis );

		ClampPosZ();
	}

	public void FixedUpdate()
	{
		Move();
	}

	public void Move()
	{
		rigidBody.velocity = transform.forward * ( movementInput * movementSpeed );

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

	private void ClampPosZ()
	{
		Vector3 pos = transform.position;
		pos.z = Mathf.Clamp( pos.z, minClampPosZ, maxClampPosZ );

		transform.position = pos;
	}
}
