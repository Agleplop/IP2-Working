using UnityEngine;
using System.Collections;

public class DragonScript : MonoBehaviour {

	Vector3 target;
	public float speed;
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		float targetY = transform.position.y;
		float targetZ = transform.position.z;

		transform.position = new Vector3 (26, targetY, targetZ);

		target = new Vector3 (-26, targetY, targetZ);

		anim = GetComponent<Animator> ();

		anim.StartPlayback();

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);

		if (transform.position.x == -26)
			Destroy (this.gameObject);
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
