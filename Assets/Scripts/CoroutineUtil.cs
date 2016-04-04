using System.Collections;
using UnityEngine;

namespace Assets.Scripts {
	/// <summary>
	/// This is simple class for the WaitForSeconds with Time.timescale set to 0. The classic Wait is not working in that case,
	/// and that - working.
	/// </summary>
	public static class CoroutineUtil {
		public static IEnumerator WaitForRealSeconds( float time ) {
			float start = Time.realtimeSinceStartup;
			while ( Time.realtimeSinceStartup < start + time ) {
				yield return null;
			}
		}
	}
}