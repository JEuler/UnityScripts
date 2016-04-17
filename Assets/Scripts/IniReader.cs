using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class IniReader : MonoBehaviour {
	public static Dictionary<string, string> ReadINIFile( string Filename ) {
		if ( !File.Exists( Filename ) )
			return null;
		Dictionary<string, string> IniFile = new Dictionary<string, string>();
		using ( StreamReader SR = new StreamReader( Filename ) ) {
			string Line;
			while ( !string.IsNullOrEmpty( Line = SR.ReadLine() ) ) {
				Line.Trim();
				string[] Parts = Line.Split( new char[] { '=' } );
				IniFile.Add( Parts[ 0 ].Trim(), Parts[ 1 ].Trim() );
			}
		}
		return IniFile;
	}
}
