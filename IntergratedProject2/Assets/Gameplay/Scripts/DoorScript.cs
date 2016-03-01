using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public GameController controller;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject player = other.gameObject;
			controller.ReachedDoor (player);
		}
	}

}
