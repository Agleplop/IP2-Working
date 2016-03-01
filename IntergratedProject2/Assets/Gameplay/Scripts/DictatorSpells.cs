using UnityEngine;
using System.Collections;

public class DictatorSpells : MonoBehaviour {

	int currentSpell = 0;
	public GameObject[] spell;
	public string fire;


	// Use this for initialization
	void Start () 
	{

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

			default:
				print("oops");
				break;


			}

		}

	}

	public void CurrentSpellChanged(int c)
	{
		currentSpell = c;
	}

	void SummonDragon()
	{
		Instantiate (spell [0], transform.position, Quaternion.identity);
	}
	void SummonSkeleton()
	{
		Instantiate (spell [1], transform.position, Quaternion.identity);
	}
	void SummonEvilBall()
	{
		GameObject evilBallObject = Instantiate (spell [2], transform.position, 
		                                   Quaternion.identity) as GameObject;
		EvilBall evilBallScript = evilBallObject.GetComponent<EvilBall> ();

		evilBallScript.GetTarget (transform.position);
	}
}

































