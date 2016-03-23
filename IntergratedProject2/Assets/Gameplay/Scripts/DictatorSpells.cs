using UnityEngine;
using System.Collections;

public class DictatorSpells : MonoBehaviour 
{

	int currentSpell = 0;
	public GameObject[] spell;
	public string fire;

	float ballCooldown = 2.0f;
	float dragonCooldown = 10.0f;
	float skeletonCooldown = 10.0f;

	float maxBallCD;
	float maxDragonCD;
	float maxSkeleCD;

	bool ballCD = false;
	bool dragonCD = false;
	bool skeleCD = false;

	bool onTrap = false;

	GameObject currentTrap = null;


	// Use this for initialization
	void Start () 
	{
		maxBallCD = ballCooldown;
		maxDragonCD = dragonCooldown;
		maxSkeleCD = skeletonCooldown;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetButtonDown(fire))
		{
			switch(currentSpell)
			{
			case 0:
				SummonDragon();
				break;

			case 1:
				SummonSkeleton();
				break;

			case 2:
				SummonEvilBall();
				break;
			
			case 3:
				UseTrap();
				break;

			default:
				print("oops");
				break;
			}

		}

		if (dragonCD)
			dragonCooldown -= Time.deltaTime;

		if (dragonCooldown < 0)
		{
			dragonCooldown = maxDragonCD;
			dragonCD = false;
		}



		if (skeleCD)
			skeletonCooldown -= Time.deltaTime;

		if (skeletonCooldown < 0)
		{
			skeletonCooldown = maxSkeleCD;
			skeleCD = false;
		}


		if (ballCD)
			ballCooldown -= Time.deltaTime;

		if (ballCooldown < 0)
		{
			ballCooldown = maxBallCD;
			ballCD = false;
		}


	}

	public void CurrentSpellChanged(int c)
	{
		currentSpell = c;
	}

	void SummonDragon()
	{

		if (dragonCD == false)
		{
			Instantiate (spell [0], transform.position, Quaternion.identity);
			dragonCD = true;
		}

	}

	void SummonSkeleton()
	{

		if (skeleCD == false)
		{

			Instantiate (spell [1], transform.position, Quaternion.identity);
			skeleCD = true;
		}

	}

	void SummonEvilBall()
	{

		if (ballCD == false)
		{

			GameObject evilBallObject = Instantiate (spell [2], transform.position, 
		                                   Quaternion.identity) as GameObject;
			EvilBall evilBallScript = evilBallObject.GetComponent<EvilBall> ();

			evilBallScript.GetTarget (transform.position);
			ballCD = true;

		}

	}

	void UseTrap()
	{

		GameObject[] traps = GameObject.FindGameObjectsWithTag ("Trap");
		float d;
		float e = 100.0f;
		foreach(GameObject trap in traps)
		{
			d = Vector3.Distance(trap.transform.position, transform.position);
			if (d < e)
			{
				e = d;
				currentTrap = trap;

			}

		}

		SpikeTrapScript sts = currentTrap.GetComponent<SpikeTrapScript> ();
		sts.Activated();
	}
	
//	void OnTriggerEnter2D(Collider2D other)
//	{
//
//		if (other.tag == "Trap")
//		{
//			onTrap = true;
//			currentTrap = other.gameObject;
//		}
//
//	}

//	void OnTriggerExit2D(Collider2D other)
//	{
//
//		if (other.tag == "Trap")
//		{
//			onTrap = false;
//			currentTrap = null;
//		}
//
//	}
	
}

































