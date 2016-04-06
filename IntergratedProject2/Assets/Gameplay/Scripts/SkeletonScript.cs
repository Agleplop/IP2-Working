using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y < -15)
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement> ();
			playerMovement.Die();
		}
	}

}
