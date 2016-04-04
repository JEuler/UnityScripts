using UnityEngine;

public enum Swipe {
	None,
	Up,
	Down,
	Left,
	Right,
	UpRight,
	UpLeft,
	DownRight,
	DownLeft
};

/// <summary>
/// This is simple Swipe manager. Firstly, it was written without dot product, and something was wrong.
/// But wit credits to gallenwolf from here: http://forum.unity3d.com/threads/swipe-in-all-directions-touch-and-mouse.165416/#post-1968538
/// all is working and now with the dot product and more precisely
/// It is also updated for debug, mouse is working
/// DON'T FORGET TO DELETE THE PRINT BEFORE RELEASE
/// </summary>
public class SwipeManager : MonoBehaviour {
	// Swipe minimal length
	public float MinSwipeLength = 5;

	private Vector2 _firstPressPos;
	private Vector2 _secondPressPos;
	private Vector2 _currentSwipe;

	public static Swipe SwipeDirection;

	private void Update() {
		DetectSwipe();
	}

	// Normalized directions
	private class GetCardinalDirections {
		public static readonly Vector2 Up = new Vector2( 0, 1 );
		public static readonly Vector2 Down = new Vector2( 0, -1 );
		public static readonly Vector2 Right = new Vector2( 1, 0 );
		public static readonly Vector2 Left = new Vector2( -1, 0 );

		public static readonly Vector2 UpRight = new Vector2( 1, 1 );
		public static readonly Vector2 UpLeft = new Vector2( -1, 1 );
		public static readonly Vector2 DownRight = new Vector2( 1, -1 );
		public static readonly Vector2 DownLeft = new Vector2( -1, -1 );
	}


	public void DetectSwipe() {
		if ( Input.touches.Length > 0 ) {
			Touch t = Input.GetTouch( 0 );

			if ( t.phase == TouchPhase.Began ) {
				_firstPressPos = new Vector2( t.position.x, t.position.y );
			}

			if ( t.phase == TouchPhase.Ended ) {
				_secondPressPos = new Vector2( t.position.x, t.position.y );
				_currentSwipe = new Vector3( _secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y );


				// Make sure it was a legit swipe, not a tap
				if ( _currentSwipe.magnitude < MinSwipeLength ) {
					SwipeDirection = Swipe.None;
					return;
				}


				_currentSwipe.Normalize();

				// use dot product against 4 cardinal directions.
				// return if one of them is > 0.5f;

				print( _currentSwipe );

				//compare north
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Up ) > 0.906f ) {
					SwipeDirection = Swipe.Up;
					print( "Up!" );
					return;
				}
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Down ) > 0.906f ) {
					SwipeDirection = Swipe.Down;
					print( "Down!" );
					return;
				}
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Left ) > 0.906f ) {
					SwipeDirection = Swipe.Left;
					print( "Left" );
					return;
				}
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Right ) > 0.906f ) {
					SwipeDirection = Swipe.Right;
					print( "Right" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.UpRight ) > 0.906f ) {
					SwipeDirection = Swipe.UpRight;
					print( "UpRight" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.UpLeft ) > 0.906f ) {
					SwipeDirection = Swipe.UpLeft;
					print( "UpLeft" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.DownLeft ) > 0.906f ) {
					SwipeDirection = Swipe.DownLeft;
					print( "DownLeft" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.DownRight ) > 0.906f ) {
					SwipeDirection = Swipe.DownRight;
					print( "DownRight" );
					return;
				}
			}
		}
		else {
			if ( Input.GetMouseButtonDown( 0 ) ) {
				_firstPressPos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
			}
			else {
				SwipeDirection = Swipe.None;
				//Debug.Log ("None");
			}
			if ( Input.GetMouseButtonUp( 0 ) ) {
				_secondPressPos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
				_currentSwipe = new Vector3( _secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y );

				// Make sure it was a legit swipe, not a tap
				if ( _currentSwipe.magnitude < MinSwipeLength ) {
					SwipeDirection = Swipe.None;
					return;
				}

				_currentSwipe.Normalize();

				//Swipe directional check
				// Swipe up
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Up ) > 0.906f ) {
					SwipeDirection = Swipe.Up;
					print( "Up!" );
					return;
				}
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Down ) > 0.906f ) {
					SwipeDirection = Swipe.Down;
					print( "Down!" );
					return;
				}
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Left ) > 0.906f ) {
					SwipeDirection = Swipe.Left;
					print( "Left" );
					return;
				}
				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.Right ) > 0.906f ) {
					SwipeDirection = Swipe.Right;
					print( "Right" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.UpRight ) > 0.906f ) {
					SwipeDirection = Swipe.UpRight;
					print( "UpRight" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.UpLeft ) > 0.906f ) {
					SwipeDirection = Swipe.UpLeft;
					print( "UpLeft" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.DownLeft ) > 0.906f ) {
					SwipeDirection = Swipe.DownLeft;
					print( "DownLeft" );
					return;
				}

				if ( Vector2.Dot( _currentSwipe, GetCardinalDirections.DownRight ) > 0.906f ) {
					SwipeDirection = Swipe.DownRight;
					print( "DownRight" );
					return;
				}
			}
		}
	}
}