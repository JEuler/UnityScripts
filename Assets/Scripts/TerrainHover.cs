using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour {

	private Transform CurrentTransform = null;
	public float MaxSpeed = 10f;
	// So, the distance we flying from ground;
	public float DistanceFromGround = 2f;
	// Normal
	private Vector3 DestinationUp = Vector3.zero;
	// degrees per second
	public float AngleSpeed = 5;

	void Awake() {
		CurrentTransform = GetComponent<Transform>();
	}

	void Update() {
		float Horizontal = CrossPlatformInputManager.GetAxis( "Horizontal" );
		float Vertical = CrossPlatformInputManager.GetAxis( "Vertical" );

		Vector3 NewPos = CurrentTransform.position;
		NewPos += CurrentTransform.forward * Vertical * MaxSpeed * Time.deltaTime;
		NewPos += CurrentTransform.right * Horizontal * MaxSpeed * Time.deltaTime;

		RaycastHit Hit;
		if ( Physics.Raycast( CurrentTransform.position, -Vector3.up, out Hit ) ) {
			NewPos.y = ( Hit.point + Vector3.up * DistanceFromGround ).y;
			DestinationUp = Hit.normal;
		}

		CurrentTransform.position = NewPos;
		CurrentTransform.up = Vector3.Slerp( CurrentTransform.up, DestinationUp, AngleSpeed * Time.deltaTime );
	}
}
