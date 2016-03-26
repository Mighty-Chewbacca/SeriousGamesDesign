using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void LoadMathsScene()
	{
		SceneManager.LoadScene ("Maths Game");
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene ("Menu Scene");
	}
}
