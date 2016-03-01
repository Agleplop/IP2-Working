using UnityEngine;
using System.Collections;

public class DictatorMovement : MonoBehaviour {

	public float movementSpeed;
	public float maxMovementSpeed;
	float inputValueX = 0;
	float inputValueY = 0;
	public string[] currentControls = new string[6];

	// Use this for initialization
	void Start () 
	{
		DictatorSpells dictatorSpells = GetComponent<DictatorSpells> ();
		dictatorSpells.fire = currentControls [3];
		GameObject userInterface = GameObject.FindGameObjectWithTag ("UI");
		DictatorUI dictatorUI = GetComponent<DictatorUI> ();
		dictatorUI.currentControls [0] = currentControls [4];
		dictatorUI.currentControls [1] = currentControls [5];

	}

	// Update is called once per frame
	void Update () 
	{

		inputValueX = Input.GetAxis(currentControls[0]);
		inputValueY = Input.GetAxis(currentControls[1]);

		if (rigidbody2D.velocity.magnitude > maxMovementSpeed)
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxMovementSpeed;



		if (Input.GetAxis(currentControls[0]) == 0 && Input.GetAxis(currentControls[1]) == 0 && rigidbody2D.drag < 20)
			rigidbody2D.drag++;
		else
			rigidbody2D.drag = 0;


	}

	void FixedUpdate ()
	{
		if (inputValueX > 0)
			rigidbody2D.AddForce(transform.right * movementSpeed);

		if (inputValueX < 0)
			rigidbody2D.AddForce(transform.right * -movementSpeed);

		if (inputValueY > 0)
			rigidbody2D.AddForce(transform.up * movementSpeed);

		if (inputValueY < 0)
			rigidbody2D.AddForce(transform.up * -movementSpeed);
	}

}

























