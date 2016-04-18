using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimplePool : MonoBehaviour {

	public GameObject PrefabToInstantiate = null;
	public int PoolSize = 100;

	private GameObject[] ArrayOfObjects;
	public static SimplePool SimplePoolSingleton = null;

	public Queue<Transform> QueueOfObjects = new Queue<Transform>();

	void Awake() {
		if (SimplePoolSingleton != null) {
			DestroyImmediate(gameObject);
			return;
		}
		SimplePoolSingleton = this;
	}

	void Start () {
		ArrayOfObjects = new GameObject[PoolSize];
		for (int i = 0; i < PoolSize; i++) {
			ArrayOfObjects[i] = Instantiate(PrefabToInstantiate, Vector3.zero, Quaternion.identity) as GameObject;
			Transform ObjTransform = ArrayOfObjects[i].GetComponent<Transform>();
			ObjTransform.parent = transform;
			QueueOfObjects.Enqueue(ObjTransform);
			ArrayOfObjects[i].SetActive(false);
		}
	}

	public static Transform SpawnObject(Vector3 Position, Quaternion Rotation) {
		Transform SpawnedObject = SimplePoolSingleton.QueueOfObjects.Dequeue();
		SpawnedObject.gameObject.SetActive(true);
		SpawnedObject.position = Position;
		SpawnedObject.rotation = Rotation;

		SimplePoolSingleton.QueueOfObjects.Enqueue(SpawnedObject);

		return SpawnedObject;
	}
}
