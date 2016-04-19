using UnityEngine;
using System.Collections;

public class RotateTo : MonoBehaviour {

	private Transform CurrentTransform = null;
	public float RotationSpeed = 60f;

	public Transform Target;
	public float Damping = 55f;

	void Awake() {
		CurrentTransform = GetComponent<Transform>();
	}

	void Update() {
		RotateSlerp();
	}

	private void RotateBasic() {
		Quaternion DestRotation = Quaternion.LookRotation( Target.position - CurrentTransform.position, Vector3.up );
		CurrentTransform.rotation = Quaternion.RotateTowards( CurrentTransform.rotation, DestRotation, RotationSpeed * Time.deltaTime );
	}

	private void RotateSlerp() {
		Quaternion DestRotation = Quaternion.LookRotation( Target.position - CurrentTransform.position, Vector3.up );
		Quaternion SmoothRotation = Quaternion.Slerp( transform.rotation, DestRotation, 1f - Time.deltaTime * Damping );
	}
}
