using UnityEngine;
using System.Collections;

public class ValueScript : MonoBehaviour 
{
	public int objectsValue;

	public SolutionsScript solScript;

	// Use this for initialization
	void Start () 
	{
		solScript = GameObject.Find ("ObjectSpawner").GetComponent<SolutionsScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnMouseDown()
	{
		Debug.Log ("passing value in");
		solScript.passValue (objectsValue);
	}


}
