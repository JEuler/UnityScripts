using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Singleton EventManager to send events to listeners
// Works with IListener implementations
// from book
public class EventManager : MonoBehaviour {
	public static EventManager Instance {
		get { return instance; }
		set { }
	}

	private static EventManager instance = null;

	// Array of listeners
	private Dictionary<>
}