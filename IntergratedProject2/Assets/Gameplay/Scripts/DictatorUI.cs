using UnityEngine;
using System.Collections;

public class DictatorUI : MonoBehaviour {

	public Sprite[] currentSprite;
	public GameObject nextSelected;
	public GameObject previousSelected;
	int currentSelected = 0;
	SpriteRenderer spriteRenderer;
	SpriteRenderer nextSpriteRenderer;
	SpriteRenderer previousSpriteRenderer;
	int l;
	public string[] currentControls = new string[2]; 

	DictatorSpells dictatorSpells;


	// Use this for initialization
	void Start () 
	{
		ResetDictator ();

		spriteRenderer = GetComponent<SpriteRenderer> ();

		nextSpriteRenderer = nextSelected.GetComponent<SpriteRenderer> ();

		previousSpriteRenderer = previousSelected.GetComponent<SpriteRenderer> ();

		l = currentSprite.Length - 1;

		ChangeImage ();

	}
	
	// Update is called once per frame
	void Update () 
	{


		if(Input.GetButtonDown(currentControls[1]))
		{
			if(currentSelected < currentSprite.Length - 1)
				currentSelected++;
			else
				currentSelected = 0;

			ChangeImage();

		}

		if(Input.GetButtonDown(currentControls[0]))
		{
			if(currentSelected == 0)
				currentSelected = l;
			else
				currentSelected--;

			ChangeImage();
		}

	
	}

	void ChangeImage()
	{

		spriteRenderer.sprite = currentSprite [currentSelected];
		
		if (currentSelected < currentSprite.Length - 1)
			nextSpriteRenderer.sprite = currentSprite [currentSelected + 1];
		else
			nextSpriteRenderer.sprite = currentSprite [0];
		
		if (currentSelected != 0)
			previousSpriteRenderer.sprite = currentSprite [currentSelected - 1];
		else
			previousSpriteRenderer.sprite = currentSprite [l];
		dictatorSpells.CurrentSpellChanged (currentSelected);
	}

	public void ResetDictator()
	{
		dictatorSpells = null;
		GameObject dictator = GameObject.FindGameObjectWithTag ("Dictator");
		dictatorSpells = dictator.GetComponent<DictatorSpells> ();
		print (dictator);
	}

	
}


































