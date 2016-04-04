using UnityEngine;
using System.Collections;

/// <summary>
/// Example of Singleton Object, tooken from the book
/// </summary>
public class Singleton : MonoBehaviour {
	public static Singleton Instance
	{
		get
		{
			return instance;
		}
	}

	private static Singleton instance = null;

	// For example purposes, GameManager stuff
	public int HighScore = 0;
	public bool IsPaused = false;
	public bool InputAllowed = true;

	void Awake() {
		if ( instance ) {
			DestroyImmediate( gameObject );
			return;
		}

		instance = this;

		DontDestroyOnLoad( gameObject );
	}
}
