using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{

	public Sprite[] sprites = new Sprite[2];
	SpriteRenderer sr;
	public int selfNumber;
	public MenuController menuController;

	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(menuController.currentButton == selfNumber)
		{
			sr.sprite = sprites[1];
		}
		else
		{
			sr.sprite = sprites[0];
		}

	}

}
