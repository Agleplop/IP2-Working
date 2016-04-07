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
	}
	
	// Use this for initialization
	void Start () 
	{
		randomX = Random.Range (-range, range + 1);
		randomY = Random.Range (0, range + 1);
		rigidbody2D.AddForce (transform.right * randomX * 3);
		rigidbody2D.AddForce (transform.up * randomY * 3);
		
		StartCoroutine (Expire ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (Vector3.forward * Time.deltaTime * randomX);
	}
}
