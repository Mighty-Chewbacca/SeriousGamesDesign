using UnityEngine;
using System.Collections;

public class DeleteMeScript : MonoBehaviour 
{

	//this script deletes an object when it goes out of the bottom of the screen

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collided with = " + col.gameObject.name);

		if (col.gameObject.name == "DigitDestroyer") 
		{
			Destroy (this);
		}
	}

}
