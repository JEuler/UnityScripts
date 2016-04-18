using UnityEngine;
using System.Collections;

public class GizmoShower : MonoBehaviour {

	public bool Show = true;
	public string Icon = string.Empty;

	// Range of "sight"
	[Range( 0f, 100f )]
	public float Range = 10f;

	void OnDrawGizmos() {
		if ( !Show )
			return;
		Gizmos.DrawIcon( transform.position, Icon, true );

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere( transform.position, Range );

		Gizmos.color = Color.green;
		Gizmos.DrawLine( transform.position, transform.position + transform.forward * Range );
	}
}
