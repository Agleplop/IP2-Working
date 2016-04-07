using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public string[,] controls = new string[4,6] ;
	public int currentDictator;
	public GameObject player;
	public Sprite[] sprites;
	int currentPlayer = 0;

	bool countdown = false;
	public float timer = 1.0f;
	string[] playerCondition = new string[4];
	GameObject firstPlayer;

	public DictatorUI dictatorUI;
	public GameObject dictatorInterface;

	int killScore;

	public string[] levels = new string[4];
	
	GameDataScript gds;

	// Use this for initialization
	void Start () 
	{
		GameObject gameData = GameObject.Find ("GameData");
		if(gameData == null)
		{
			gameData = new GameObject("GameData");
			gameData.AddComponent <GameDataScript> ();
			gameData.tag = "DataController";
		}

		GameObject dataController = GameObject.FindGameObjectWithTag ("DataController");
		gds = dataController.GetComponent<GameDataScript> ();

		currentDictator = gds.currentDictator;

		killScore = 0;

		playerCondition[currentDictator] = "Dictator";

		firstPlayer = null;

		controls [0, 0] = "HorizontalPlayer1";
		controls [0, 1] = "VerticalPlayer1";
		controls [0, 2] = "JumpPlayer1";
		controls [0, 3] = "FirePlayer1";
		controls [0, 4] = "NextPlayer1";
		controls [0, 5] = "PreviousPlayer1";

		controls [1, 0] = "HorizontalPlayer2";
		controls [1, 1] = "VerticalPlayer2";
		controls [1, 2] = "JumpPlayer2";
		controls [1, 3] = "FirePlayer2";
		controls [1, 4] = "NextPlayer2";
		controls [1, 5] = "PreviousPlayer2";

		controls [2, 0] = "HorizontalPlayer3";
		controls [2, 1] = "VerticalPlayer3";
		controls [2, 2] = "JumpPlayer3";
		controls [2, 3] = "FirePlayer3";
		controls [2, 4] = "NextPlayer3";
		controls [2, 5] = "PreviousPlayer3";

		controls [3, 0] = "HorizontalPlayer4";
		controls [3, 1] = "VerticalPlayer4";
		controls [3, 2] = "JumpPlayer4";
		controls [3, 3] = "FirePlayer4";
		controls [3, 4] = "NextPlayer4";
		controls [3, 5] = "PreviousPlayer4";

		CreatePlayer1 ();
		currentPlayer++;
		CreatePlayer2 ();
		currentPlayer++;
		CreatePlayer3 ();
		currentPlayer++;
		CreatePlayer4 ();



	}
	
	// Update is called once per frame
	void Update () 
	{
		if (countdown)
		{
			timer -= Time.deltaTime;
			if (timer < 0)
			{

				RoomComplete ();
			}

		}

	}

	void CreatePlayer1 ()
	{
		GameObject player1 = Instantiate (player, transform.position, Quaternion.identity) as GameObject;
		player1.name = "Player1";
		player1.layer = 8;

		SpriteRenderer sp = player1.GetComponent<SpriteRenderer> ();
		PlayerMovement playerMovement = player1.GetComponent<PlayerMovement> ();
		DictatorMovement dictatorMovement = player1.GetComponent<DictatorMovement> ();
		DictatorSpells dictatorSpells = player1.GetComponent<DictatorSpells> ();
		Rigidbody2D rb2D = player1.GetComponent<Rigidbody2D> ();
		BoxCollider2D box2D = player1.GetComponent<BoxCollider2D> ();

		//if the player is the dictator
		if (currentPlayer == currentDictator)
		{
			dictatorUI.dictator = player1;

			player1.tag = "Dictator";
			sp.sprite = sprites [0];
			playerMovement.enabled = false;
			rb2D.gravityScale = 0;
			box2D.isTrigger = true;

			for (int i = 0; i < 6; i++)
			{
				dictatorMovement.currentControls[i] = controls[currentPlayer, i];
			}

		}


		//if the player is just a normal player
		else
		{
			player1.tag = "Player";
			sp.sprite = sprites [1];
			dictatorMovement.enabled = false;
			dictatorSpells.enabled = false;

			playerCondition[0] = "Playing";

			for (int i = 0; i < 6; i++)
			{
				playerMovement.currentControls[i] = controls[currentPlayer, i];
			}
		}

	}

	void CreatePlayer2()
	{
		GameObject player2 = Instantiate (player, transform.position, Quaternion.identity) as GameObject;
		player2.name = "Player2";
		player2.layer = 9;

		SpriteRenderer sp = player2.GetComponent<SpriteRenderer> ();
		PlayerMovement playerMovement = player2.GetComponent<PlayerMovement> ();
		DictatorMovement dictatorMovement = player2.GetComponent<DictatorMovement> ();
		DictatorSpells dictatorSpells = player2.GetComponent<DictatorSpells> ();
		Rigidbody2D rb2D = player2.GetComponent<Rigidbody2D> ();
		BoxCollider2D box2D = player2.GetComponent<BoxCollider2D> ();
		
		if (currentPlayer == currentDictator) 
		{

			dictatorUI.dictator = player2;

			player2.tag = "Dictator";
			sp.sprite = sprites [0];
			playerMovement.enabled = false;
			rb2D.gravityScale = 0;
			box2D.isTrigger = true;
			
			for (int i = 0; i < 6; i++) 
			{
				dictatorMovement.currentControls [i] = controls [currentPlayer, i];
			}
			
		} 
		else 
		{
			player2.tag = "Player";
			sp.sprite = sprites [2];
			dictatorMovement.enabled = false;
			dictatorSpells.enabled = false;

			playerCondition [1] = "Playing";

			for (int i = 0; i < 6; i++) 
			{
				playerMovement.currentControls [i] = controls [currentPlayer, i];
			}

		}

	}


	void CreatePlayer3()
	{
		GameObject player3 = Instantiate (player, transform.position, Quaternion.identity) as GameObject;
		player3.name = "Player3";
		player3.layer = 10;

		
		SpriteRenderer sp = player3.GetComponent<SpriteRenderer> ();
		PlayerMovement playerMovement = player3.GetComponent<PlayerMovement> ();
		DictatorMovement dictatorMovement = player3.GetComponent<DictatorMovement> ();
		DictatorSpells dictatorSpells = player3.GetComponent<DictatorSpells> ();
		Rigidbody2D rb2D = player3.GetComponent<Rigidbody2D> ();
		BoxCollider2D box2D = player3.GetComponent<BoxCollider2D> ();
		
		if (currentPlayer == currentDictator)
		{

			dictatorUI.dictator = player3;

			player3.tag = "Dictator";
			sp.sprite = sprites [0];
			playerMovement.enabled = false;
			rb2D.gravityScale = 0;
			box2D.isTrigger = true;
			
			for (int i = 0; i < 6; i++)
			{
				dictatorMovement.currentControls[i] = controls[currentPlayer, i];
			}
			
		}
		
		else
		{
			player3.tag = "Player";
			sp.sprite = sprites [3];
			dictatorMovement.enabled = false;
			dictatorSpells.enabled = false;
			
			playerCondition[2] = "Playing";
			
			for (int i = 0; i < 6; i++)
			{
				playerMovement.currentControls[i] = controls[currentPlayer, i];
			}
			
		}

	}

	void CreatePlayer4()
	{
		GameObject player4= Instantiate (player, transform.position, Quaternion.identity) as GameObject;
		player4.name = "Player4";
		player4.layer = 11;
		
		SpriteRenderer sp = player4.GetComponent<SpriteRenderer> ();
		PlayerMovement playerMovement = player4.GetComponent<PlayerMovement> ();
		DictatorMovement dictatorMovement = player4.GetComponent<DictatorMovement> ();
		DictatorSpells dictatorSpells = player4.GetComponent<DictatorSpells> ();
		Rigidbody2D rb2D = player4.GetComponent<Rigidbody2D> ();
		BoxCollider2D box2D = player4.GetComponent<BoxCollider2D> ();
		
		if (currentPlayer == currentDictator)
		{

			dictatorUI.dictator = player4;

			player4.tag = "Dictator";
			sp.sprite = sprites [0];
			playerMovement.enabled = false;
			rb2D.gravityScale = 0;
			box2D.isTrigger = true;
			
			for (int i = 0; i < 6; i++)
			{
				dictatorMovement.currentControls[i] = controls[currentPlayer, i];
			}
			
		}
		
		else
		{
			player4.tag = "Player";
			sp.sprite = sprites [4];
			dictatorMovement.enabled = false;
			dictatorSpells.enabled = false;
			
			playerCondition[3] = "Playing";
			
			for (int i = 0; i < 6; i++)
			{
				playerMovement.currentControls[i] = controls[currentPlayer, i];
			}
			
		}
		
	}



	public void ReachedDoor(GameObject finishedPlayer)
	{
		if (finishedPlayer.name == "Player1")
		{
			playerCondition[0] = "Finished";
		}
		else if (finishedPlayer.name == "Player2")
		{
			playerCondition[1] = "Finished";
		}
		else if (finishedPlayer.name == "Player3")
		{
			playerCondition[2] = "Finished";

		}
		else if (finishedPlayer.name == "Player4")
		{
			playerCondition[3] = "Finished";
		}


		if(countdown == false)
		{
			firstPlayer = finishedPlayer;
		}

		countdown = true;

		if (firstPlayer.name == "Player1")
		{
			currentDictator = 0;
		}
		else if (firstPlayer.name == "Player2")
		{
			currentDictator = 1;
		}
		else if (firstPlayer.name == "Player3")
		{
			currentDictator = 2;
		}
		else if (firstPlayer.name == "Player4")
		{
			currentDictator = 3;
		}

		Destroy (finishedPlayer);
	}



	void RoomComplete()
	{
		
		for (int i = 0; i < 4; i++)
		{
			if(playerCondition[i] != "Finished")
			{
				playerCondition[i] = "Dead";
			}

		}

		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach(GameObject deletedPlayer in players)
		{
			Destroy(deletedPlayer);
		}

		GameObject dictator = GameObject.FindGameObjectWithTag ("Dictator");

		Destroy (dictator);

		NextLevel ();

	}

	void NextLevel ()
	{
		gds.currentDictator = currentDictator;

		if (gds.currentlevel < 3) 
			gds.currentlevel++;
		else
			gds.currentlevel = 0;


		Application.LoadLevel (levels [gds.currentlevel]);
	}

//	void RestartGame()
//	{
//
//
//		GameObject dictatorInterface = GameObject.FindGameObjectWithTag ("UI");
//		dictatorUI = dictatorInterface.GetComponent<DictatorUI> ();
//		dictatorUI.ResetDictator();
//
//		killScore = 0;
//
//		countdown = false;
//		playerCondition[currentDictator] = "Dictator";
//		firstPlayer = null;
//		currentPlayer = 0;
//
//		CreatePlayer1 ();
//		currentPlayer++;
//		CreatePlayer2 ();
//		currentPlayer++;
//		CreatePlayer3 ();
//		currentPlayer++;
//		CreatePlayer4 ();
//
//		timer = 1.0f;
//
//	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement> ();
			playerMovement.Die();
		}

	}

	public void PlayerDied ()
	{
		killScore++;
		if (killScore >= 30)
		{
			//RestartGame();
		}

	}


}
































