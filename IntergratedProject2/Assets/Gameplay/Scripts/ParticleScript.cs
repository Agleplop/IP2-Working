using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
	
	float randomX;
	float randomY;
	public float range;
	public Sprite[] currentSprite;

	IEnumerator Expire()
	{
		float t = Random.Range (0.5f, 2.0f);
		yield return new WaitForSeconds (t);
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () 
	{

		int s = Random.Range (0, currentSprite.Length - 1);
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.sprite = currentSprite [s];


		randomX = Random.Range (-range, range);
		randomY = Random.Range (-range, range);
		rigidbody2D.AddForce (transform.right * randomX);
		rigidbody2D.AddForce (transform.up * randomY);

		StartCoroutine (Expire ());
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
