using UnityEngine;
using System.Collections;

public class eli_BADsnap2 : MonoBehaviour {

	public GameObject ScriptObject; 

	void OnTriggerEnter(Collider other) {
		ScriptObject.GetComponent<eli_BADsnap>().IJustCollided(this.GetComponentInChildren<Collider>(),other);
	}
}
