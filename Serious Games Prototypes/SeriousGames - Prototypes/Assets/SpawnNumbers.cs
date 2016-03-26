using UnityEngine;
using System.Collections;

public class SpawnNumbers : MonoBehaviour 
{
	//this script will create the numbers and letters randomly at the top of the screen

	public int fallingSpeed;
	public int maxNumbersOnScreen;

	public float SpawnTimer;
	public float temp;

	public static bool allowedToSpawn = false;

	// Use this for initialization
	void Start () 
	{
		temp = SpawnTimer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (allowedToSpawn)
		{

			temp -= Time.deltaTime;

			if (temp < 0) 
			{

				int tmp = Random.Range (0, 100);
				string tmps = tmp.ToString ();
				//spawn a tile
				//spawn the number or symbol
				GameObject go = Instantiate (Resources.Load (tmps)) as GameObject; 

				//now set its random x position
				Vector2 newPos = new Vector2 (Random.value, 1.2f);
				newPos = Camera.main.ViewportToWorldPoint (newPos);

				go.gameObject.transform.position = newPos;

				temp = SpawnTimer;
			}
		}
	}
}
