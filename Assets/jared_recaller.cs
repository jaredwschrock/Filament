using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class jared_recaller : MonoBehaviour {
	public GameObject controller;
	public GameObject itemToRecall; //temporary
	public GameObject greyCube;
	public List<GameObject> itemsToRecall;
	public float spacing;
	
	private List<GameObject> copyItems;
	private GameObject copyItem;
	
	private Collider contCollider;

	// Use this for initialization
	void Start () {
		contCollider = controller.GetComponentInChildren<Collider>();
		copyItems = new List<GameObject>(itemsToRecall.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other == contCollider) {
			Debug.Log("recall active");
			Vector3 newPos = new Vector3(0f, 0f, 0.5f);
			
			float spacingStart = 0 - ((spacing * itemsToRecall.Count) / 2);
			for (int i = 0; i < itemsToRecall.Count; i++) {
				copyItem = Instantiate(itemsToRecall[i]);
				copyItem.transform.parent = this.transform;
				copyItem.transform.localPosition = new Vector3(spacingStart+(i*spacing), 0f, 0.5f);
				copyItem.GetComponentInChildren<Rigidbody>().useGravity = false;
				copyItem.GetComponentInChildren<Collider>().isTrigger = true;
				
				copyItems.Add(copyItem);
			}
			
			greyCube.transform.parent = this.transform;
			greyCube.transform.localPosition = new Vector3(0f, 0f, 0.11f);
			greyCube.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);//new Vector3(0f, 0f, 0f);
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (other == contCollider) {
			float spacingStart = 0 - ((spacing * itemsToRecall.Count) / 2);
			for (int i = 0; i < itemsToRecall.Count; i++) {
				if (copyItems[i].transform.localPosition != new Vector3(spacingStart+(i*spacing), 0f, 0.5f)) {
					copyItems[i].GetComponentInChildren<Renderer>().material.color = Color.grey;
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other == contCollider) {
			Debug.Log("recall deactivated "+copyItems.Count);
			float spacingStart = 0 - ((spacing * itemsToRecall.Count) / 2);
			for (int i = 0; i < itemsToRecall.Count; i++) {
				if (copyItems[i].transform.localPosition != new Vector3(spacingStart+(i*spacing), 0f, 0.5f)) {
					itemsToRecall[i].transform.position = copyItems[i].transform.position;
					itemsToRecall[i].GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
					itemsToRecall[i].GetComponentInChildren<Rigidbody>().angularVelocity = Vector3.zero;
					itemsToRecall[i].GetComponentInChildren<Rigidbody>().useGravity = true;
				}
			}
			for (int i = copyItems.Count-1; i >= 0; i--) {
				Destroy(copyItems[i]);
			}
			copyItems = new List<GameObject>(itemsToRecall.Count);

			this.transform.DetachChildren();
			greyCube.transform.position = new Vector3(0f, -100f, 0f);
		}
	}
}
