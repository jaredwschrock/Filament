using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class eli_BADsnap : MonoBehaviour {

	public Collider Doll1;
	public Collider Doll2;
	public Collider Doll3;
	public Collider Doll4;
	
	public List<Transform> Locations;
	
	public GameObject world;
	
	public GameObject cup1;
	public GameObject cup2;
	public GameObject cup3;
	
	private int Doll1inLoc = -1;
	private int Doll2inLoc = -1;
	private int Doll3inLoc = -1;
	private int Doll4inLoc = -1;
	
	private bool didShrink;

	// Use this for initialization
	void Start () {
		didShrink = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Doll1inLoc >= 0)
		{
			Doll1.transform.position = Locations[Doll1inLoc].position;
			Doll1.transform.rotation = Locations[Doll1inLoc].rotation;
		}
		if (Doll2inLoc >= 0)
		{
			Doll2.transform.position = Locations[Doll2inLoc].position;
			Doll2.transform.rotation = Locations[Doll2inLoc].rotation;
		}
		if (Doll3inLoc >= 0)
		{
			Doll3.transform.position = Locations[Doll3inLoc].position;
			Doll3.transform.rotation = Locations[Doll3inLoc].rotation;
		}
		if (Doll4inLoc >= 0)
		{
			Doll4.transform.position = Locations[Doll4inLoc].position;
			Doll4.transform.rotation = Locations[Doll4inLoc].rotation;
		}
		
		if (Doll1inLoc >= 0 && Doll2inLoc >= 0 && Doll3inLoc >= 0 && Doll4inLoc >= 0) {
			world.transform.localScale = Vector3.Lerp(world.transform.localScale, new Vector3(20f, 20f, 20f), 0.003f);
			world.transform.position = Vector3.Lerp(world.transform.position, new Vector3(-25.9f, -5.9f, -18.1f), 0.003f);
			
			if (!didShrink) {
				cup1.transform.position = new Vector3(500f, 500f, 500f);
				cup2.transform.position = new Vector3(500f, 500f, 500f);
				cup3.transform.position = new Vector3(500f, 500f, 500f);
				didShrink = true;
			}
		}
	}
	
	
	public void IJustCollided(Collider self, Collider other){
		if (other == Doll1 && Doll1inLoc < 0)
		{
			for (int i = 0; i < 4; i++){
				if (self == Locations[i].gameObject.GetComponentInChildren<Collider>())
				{
					Doll1inLoc = i;
				}
			}
		}
		
		if (other == Doll2 && Doll2inLoc < 0)
		{
			for (int i = 0; i < 4; i++){
				if (self == Locations[i].gameObject.GetComponentInChildren<Collider>())
				{
					Doll2inLoc = i;
				}
			}
		}
		
		if (other == Doll3 && Doll3inLoc < 0)
		{
			for (int i = 0; i < 4; i++){
				if (self == Locations[i].gameObject.GetComponentInChildren<Collider>())
				{
					Doll3inLoc = i;
				}
			}
		}
		
		if (other == Doll4 && Doll4inLoc < 0)
		{
			for (int i = 0; i < 4; i++){
				if (self == Locations[i].gameObject.GetComponentInChildren<Collider>())
				{
					Doll4inLoc = i;
				}
			}
		}
		
	}
}
