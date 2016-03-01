using UnityEngine;
using System.Collections;

public class DragonScript : MonoBehaviour {

	Vector3 target;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		float targetY = transform.position.y;
		float targetZ = transform.position.z;

		transform.position = new Vector3 (26, targetY, targetZ);

		target = new Vector3 (-26, targetY, targetZ);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);

		if (transform.position.x == -26)
			Destroy (this.gameObject);
	}
}
