using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PlayButton()
	{
		Application.LoadLevel("MainScene");
	}

	public void QuitButton()
	{
		Application.Quit();
	}

	public void MorePlayers()
	{

	}
}
