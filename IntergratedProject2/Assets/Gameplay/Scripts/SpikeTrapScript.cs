using UnityEngine;
using System.Collections;

public class SpikeTrapScript : MonoBehaviour {

	public Vector3 startPosition;
	public Vector3 activatedPosition;

	bool active = false;
	bool activating = false;

	float travelTime = 0.25f;

	IEnumerator StartLerping (Vector3 pos1, Vector3 pos2)
	{
		float t = 0;
		while(t < travelTime)
		{

			t += Time.deltaTime;
			transform.position = Vector3.Lerp(pos1, pos2, t/travelTime);
			yield return 0;

		}

		if (transform.position != pos2)
		{
			StartCoroutine (StartLerping (pos1, pos2));

		}

		else
		{
			activating = false;


			if (active == true)
				active = false;
			else
				active = true;
		}
	}

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (active == true && activating == false)
		{
			StartCoroutine(StartLerping(activatedPosition, startPosition));
			activating = true;
		}
	}



	public void Activated()
	{

		if (active == false && activating == false)
		{
			StartCoroutine(StartLerping(startPosition, activatedPosition));
			activating = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && (active ==true || activating == true))
		{
			PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement> ();
			playerMovement.Die();
		}
	}

}




















