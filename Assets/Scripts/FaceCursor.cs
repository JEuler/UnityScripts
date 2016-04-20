using UnityEngine;
using System.Collections;

public class FaceCursor : MonoBehaviour {
	private Transform CurrentTransform = null;
	// Use this for initialization
	void Awake() {
		CurrentTransform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 MousePositionWorld =
			Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0f ) );
		MousePositionWorld = new Vector3(MousePositionWorld.x, CurrentTransform.position.y ,MousePositionWorld.z);
		Vector3 LookDirection = MousePositionWorld - CurrentTransform.position;
		CurrentTransform.localRotation = Quaternion.LookRotation( LookDirection.normalized, Vector3.up );
	}
}
