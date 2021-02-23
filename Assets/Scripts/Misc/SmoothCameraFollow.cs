using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target = default;
	[SerializeField] private float smoothing = 5f;
	[SerializeField] private Vector3 offset = Vector3.zero;

	private Vector3 velocity = Vector3.zero;
	private Vector3 desiredPosition = Vector3.zero;
	private Vector3 smoothedPosition = Vector3.zero;

	private void FixedUpdate()
	{
		desiredPosition = target.position + offset;
		smoothedPosition = Vector3.SmoothDamp( transform.position, desiredPosition, ref velocity, smoothing );

		transform.position = smoothedPosition;
	}
}
