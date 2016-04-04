using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject[] buttons = new GameObject[3];
	public int currentButton = 0;
	float timer= 0.25f;
	public GameObject instructions;
	bool instructionsEnabled;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
	}

	void FixedUpdate()
	{
		if (Input.GetAxis ("VerticalPlayer4") < 0 && timer < 0 && instructionsEnabled == false) {	
			if (currentButton < 2) {

				currentButton++;

			} else {
				currentButton = 0;

			}
			timer = 0.25f;
			 
		}
		else if (Input.GetAxis ("VerticalPlayer4") > 0 && timer < 0 && instructionsEnabled == false) 
		{	
			if(currentButton >= 1)
			{
				
				currentButton--;
				
			}
			else
			{
				
				currentButton = 2;
				
			}
			timer = 0.25f;
			
		}

		if(Input.GetButtonDown("JumpPlayer4"))
		{
			if(currentButton == 0)
			{
				Application.LoadLevel("MainScene");
			}
			else if(currentButton == 1)
			{
				if (instructionsEnabled == false)
				{
					instructions.SetActive(true);
					instructionsEnabled = true;
				}
				else
				{
					instructions.SetActive(false);
					instructionsEnabled = false;
				}

			}

			else if (currentButton == 2)
			{
				Application.Quit();
			}

		}

	}

}
