using UnityEngine;
using System.Collections;

/// <summary>
/// It is truly simple script to help you make screenshots.
/// It don't overwrite screenshots, if the filename is the same and it save the width and height in the name of file
/// useful, when you are making screens for marketplaces.
/// </summary>
public class ScreenShooter : MonoBehaviour {
	private int _count = 0;
	// Update is called once per frame
	private void Update() {
		if ( Input.GetKeyDown( KeyCode.S ) ) {
			while ( System.IO.File.Exists( "ScreenShot_" + _count + "_" + Screen.width + "x" + Screen.height + ".png" ) ) {
				_count++;
			}
			Application.CaptureScreenshot( "ScreenShot_" + _count + "_" + Screen.width + "x" + Screen.height + ".png" );
		}
	}
}
