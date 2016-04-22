using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	private Transform CurrentTransform = null;

	// Use this for initialization
	void Start() {
		CurrentTransform = transform;
	}

	// Update is called once per frame
	void LateUpdate() {
		Vector3 LookAtDir = new Vector3( Camera.main.transform.position.x - CurrentTransform.position.x, 0,
			Camera.main.transform.position.z - CurrentTransform.position.z );
		CurrentTransform.rotation = Quaternion.LookRotation( LookAtDir.normalized, Vector3.up );
	}
}
