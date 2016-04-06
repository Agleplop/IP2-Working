using UnityEngine;
using System.Collections;

public class GoreScript : MonoBehaviour {

	float randomX;
	float randomY;
	public float range;
	
	IEnumerator Expire()
	{
		float t = Random.Range (0.5f, 2.0f);
		yield return new WaitForSeconds (t);
		Destroy (this.gameObject);
	}
	
	// Use this for initialization
	void Start () 
	{
		randomX = Random.Range (-range, range) + 50;
		randomY = Random.Range (-range, range) + 50;
		rigidbody2D.AddForce (transform.right * randomX);
		rigidbody2D.AddForce (transform.up * randomY);
		
		StartCoroutine (Expire ());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
