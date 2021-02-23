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
	[BoxGroup( "Components" )]
	[SerializeField] [Required] private Rigidbody rb;

	[BoxGroup( "Input" )]
	[SerializeField] [InputAxis] private string horizontalMovementInputAxis = "";

	[BoxGroup( "Movement Values" )]
	[SerializeField] private float movementSpeed;

	[BoxGroup( "Debug" )]
	[SerializeField] private float movementInput;
	[SerializeField] private PlayerMovementState movementState = PlayerMovementState.IDLE;

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
		rb.velocity = transform.forward * ( movementInput * movementSpeed );
	}
}
