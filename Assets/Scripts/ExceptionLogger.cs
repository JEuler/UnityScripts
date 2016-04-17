using System;
using UnityEngine;
using System.Collections;
using System.IO;

public class ExceptionLogger : MonoBehaviour {

	private StreamWriter SW;
	public string LogFileName = "log.txt";

	// Use this for initialization
	void Start() {
		DontDestroyOnLoad( gameObject );
		SW = new StreamWriter( Application.persistentDataPath + "/" + LogFileName );
	}

	// Unity 5 api
	void OnEnable() {
		Application.logMessageReceived += HandleLog;
	}

	void OnDisable() {
		Application.logMessageReceived -= HandleLog;
	}

	void HandleLog(string logString, string stackTrace, LogType type) {
		if (type == LogType.Exception || type == LogType.Error) {
			SW.WriteLine("Logged at: " + DateTime.Now + " - Log Desc: " + logString + " - Trace: " + stackTrace + "- Type: " + type);
		}
	}

	void OnDestroy() {
		SW.Close();
	}
}
