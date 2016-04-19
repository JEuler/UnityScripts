using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Orbiter : MonoBehaviour {
	public Transform Pivot = null;
	private Transform CurrentTransform = null;
	private Quaternion DestinationRotation = Quaternion.identity;
	// Distance from pivot (constraints)
	public float PivotDistance = 5f;
	public float RotationSpeed = 10f;
	private float RotX = 0f;
	private float RotY = 0f;

	void Awake() {
		CurrentTransform = GetComponent<Transform>();
	}

	void Update() {
		float Horizontal = CrossPlatformInputManager.GetAxis( "Horizontal" );
		float Vertical = CrossPlatformInputManager.GetAxis( "Vertical" );

		RotX += Vertical * Time.deltaTime * RotationSpeed;
		RotY += Horizontal * Time.deltaTime * RotationSpeed;

		Quaternion YRot = Quaternion.Euler( 0f, RotY, 0f );
		DestinationRotation = YRot * Quaternion.Euler( RotX, 0f, 0f );

		CurrentTransform.rotation = DestinationRotation;
		CurrentTransform.position = Pivot.position + CurrentTransform.rotation * Vector3.forward * -PivotDistance;
	}
}
