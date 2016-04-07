using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {

	public int currentDictator;
	public int[] score = new int[4];
	public int currentlevel;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
		currentDictator = Random.Range (0, 4);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
