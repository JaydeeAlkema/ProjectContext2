using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum ClampAxis
{
	none = 0,
	x = 1 << 1,
	y = 1 << 2,
	z = 1 << 3
}

public class SmoothCameraFollow : MonoBehaviour
{
	[SerializeField] [Required] private Transform target = default;
	[Range( 0.1f, 2f )] [SerializeField] private float smoothing = 5f;
	[SerializeField] private Vector3 offset = Vector3.zero;
	[Space]
	[EnumFlags]
	[SerializeField] private ClampAxis clampAxis;
	[SerializeField] private Vector3 minClampPos;
	[SerializeField] private Vector3 maxClampPos;

	private Vector3 velocity = Vector3.zero;
	private Vector3 desiredPosition = Vector3.zero;
	private Vector3 smoothedPosition = Vector3.zero;

	private void FixedUpdate()
	{
		desiredPosition = target.position + offset;
		smoothedPosition = Vector3.SmoothDamp( transform.position, desiredPosition, ref velocity, smoothing );

		ClampPos();

		transform.position = smoothedPosition;
	}

	private void ClampPos()
	{
		if( clampAxis == ClampAxis.x ) smoothedPosition.x = Mathf.Clamp( smoothedPosition.x, minClampPos.x, maxClampPos.x );
		if( clampAxis == ClampAxis.y ) smoothedPosition.y = Mathf.Clamp( smoothedPosition.y, minClampPos.y, maxClampPos.y );
		if( clampAxis == ClampAxis.z ) smoothedPosition.z = Mathf.Clamp( smoothedPosition.z, minClampPos.z, maxClampPos.z );
	}
}
