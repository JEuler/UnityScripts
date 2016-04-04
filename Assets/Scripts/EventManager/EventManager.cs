using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Singleton EventManager to send events to listeners
// Works with IListener implementations
// from book Mastering Unity Scripting
public class EventManager : MonoBehaviour {
	public static EventManager Instance
	{
		get { return instance; }
		set { }
	}

	private static EventManager instance = null;

	// Array of listeners
	private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>>();

	public void Awake() {
		if ( instance == null ) {
			instance = this;
			DontDestroyOnLoad( gameObject );
		}
		else {
			DestroyImmediate( this );
		}
	}

	// Add listener
	public void AddListener( EVENT_TYPE Event_Type, IListener Listener ) {
		List<IListener> ListenList = null;
		if ( Listeners.TryGetValue( Event_Type, out ListenList ) ) {
			ListenList.Add( Listener );
			return;
		}
		ListenList = new List<IListener>();
		ListenList.Add( Listener );
		Listeners.Add( Event_Type, ListenList );
	}

	public void PostNotification( EVENT_TYPE Event_Type, Component Sender, Object Param = null ) {
		List<IListener> ListenList = null;

		if ( !Listeners.TryGetValue( Event_Type, out ListenList ) )
			return;

		for ( int i = 0; i < ListenList.Count; i++ ) {
			if ( !ListenList[ i ].Equals( null ) ) {
				ListenList[ i ].OnEvent( Event_Type, Sender, Param );
			}
		}
	}

	public void RemoveEvent( EVENT_TYPE Event_Type ) {
		Listeners.Remove( Event_Type );
	}

	public void RemoveRedundancies() {
		Dictionary<EVENT_TYPE, List<IListener>> TmpListeners = new Dictionary<EVENT_TYPE, List<IListener>>();
		foreach ( var listener in Listeners ) {
			for ( int i = listener.Value.Count - 1; i >= 0; i-- ) {
				if ( listener.Value[ i ].Equals( null ) ) {
					listener.Value.RemoveAt( i );
				}
			}
			if ( listener.Value.Count > 0 ) {
				TmpListeners.Add( listener.Key, listener.Value );
			}

			Listeners = TmpListeners;
		}
	}

	void OnLevelWasLoaded( int level ) {
		RemoveRedundancies();
	}
}