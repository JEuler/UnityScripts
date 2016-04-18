using UnityEngine;
using System.Collections;
using System.IO;

// Example of data-into-file save and load.
// from course. 
public class PositionSaver : MonoBehaviour {

	public Vector3 LastPosition = Vector3.up;
	public Quaternion LastRotation = Quaternion.identity;
	private Transform CurrentTransform = null;

	// Use this for initialization
	void Awake() {
		CurrentTransform = GetComponent<Transform>();
	}

	void SaveObject() {
		string OutputPath = Application.persistentDataPath + @"\ObjectPosition.json";
		LastPosition = CurrentTransform.position;
		LastRotation = CurrentTransform.rotation;

		StreamWriter Writer = new StreamWriter( OutputPath );
		Writer.WriteLine( JsonUtility.ToJson( this ) );
		Writer.Close();
		Debug.Log( "Outputting to: " + OutputPath );
	}

	void LoadObject() {
		string InputPath = Application.persistentDataPath + @"\ObjectPosition.json";
		StreamReader Reader = new StreamReader(InputPath);

		string JSONString = Reader.ReadToEnd();
		Debug.Log("Reading: " + JSONString);
		JsonUtility.FromJsonOverwrite(JSONString, this);
		Reader.Close();

		CurrentTransform.position = LastPosition;
		CurrentTransform.rotation = LastRotation;
	}

	void OnDestroy() {
		SaveObject();
	}

	void Start() {
		LoadObject();
	}
}
