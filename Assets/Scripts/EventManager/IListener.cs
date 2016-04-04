using UnityEngine;
using System.Collections;

/// <summary>
/// Example of IListener class for Event Managment stuff
/// so, the ammo and health are used
/// tooken from book
/// </summary>
public enum EVENT_TYPE {
	GAME_INIT,
	GAME_END,
	HEALTH_CHANGE,
	DEAD
};

public interface IListener {
	void OnEvent( EVENT_TYPE EventType, Component Sender, Object Param = null );
}

