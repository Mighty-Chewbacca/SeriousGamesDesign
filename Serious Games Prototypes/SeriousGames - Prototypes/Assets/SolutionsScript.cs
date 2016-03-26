using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SolutionsScript : MonoBehaviour 
{
	//this script will contain the main game loop - it will start the timer - choose a solution and so on

	public float roundTimer;
	public float temp;
	public float desiredSolution;
	public string Symbol;

	public int number1, number2;

	public Button beginButton;
	public Text timerText;
	public Text Digit1Text;
	public Text SymbolText;
	public Text Digit2Text;
	public Text SolutionText;

	public bool correctSolution = false;

	public bool timerActive = false;

	public int currentDigit = 1;

	// Use this for initialization
	void Start () 
	{
		temp = roundTimer;
		beginButton = GameObject.Find ("BeginButton").GetComponent<Button>();

		timerText = GameObject.Find ("TimerText").GetComponent<Text>();
		Digit1Text = GameObject.Find ("FirstDigitSlot").GetComponent<Text>();
		SymbolText = GameObject.Find ("SymbolSlot").GetComponent<Text>();
		Digit2Text = GameObject.Find ("SecondDigitSlot").GetComponent<Text>();
		SolutionText = GameObject.Find ("TotalSlot").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timerText.text = temp.ToString();
		SolutionText.text = desiredSolution.ToString ();

		if (Symbol == "ADD") 
		{
			SymbolText.text = "+";
		}
		if (Symbol == "SUBTRACT") 
		{
			SymbolText.text = "-";
		}

		if (correctSolution) 
		{
			Digit1Text.color = Color.green;
			Digit2Text.color = Color.green;
		} else 
		{
			Digit1Text.color = Color.red;
			Digit2Text.color = Color.red;
		}


		if (timerActive) 
		{
			temp -= Time.deltaTime;

			//choose a solution and symbol

			if (temp < 0)
			{
				Debug.Log ("Round Over");
				endRound ();
			}

			checkSolution ();

			if (correctSolution) 
			{
				endRound ();
			}
		}
	}

	public void startRound()
	{
		timerActive = true;
		beginButton.gameObject.SetActive (false);
		SpawnNumbers.allowedToSpawn = true;
		chooseSolution ();
		correctSolution = false;

	}

	public void endRound()
	{
		temp = roundTimer; //reset timer
		beginButton.gameObject.SetActive (true); //reactive begin button
		SpawnNumbers.allowedToSpawn = false;

		//remove the digits
		GameObject[] GOS = GameObject.FindGameObjectsWithTag ("Digit");

		for (int i = 0; i < GOS.Length; i++) 
		{
			Destroy (GOS[i]);
		}

		
	}

	void chooseSolution()
	{
		desiredSolution = Random.Range (1, 100);
		int tempSymbolVal = Random.Range (1, 2);

		if (tempSymbolVal == 1) 
		{
			Symbol = "ADD";
		}
		if (tempSymbolVal == 2) 
		{
			Symbol = "SUBTRACT";
		}
	}

	void resetChoices()
	{
		Digit1Text.text = "?";
		Digit2Text.text = "?";

		currentDigit = 1;
	}

	void checkSolution()
	{
		if (Symbol == "ADD") 
		{
			if (number1 + number2 == desiredSolution) 
			{
				correctSolution = true;
			}
		}
		if (Symbol == "SUBTRACT") 
		{
			if (number1 - number2 == desiredSolution) 
			{
				correctSolution = true;
			}
		}
	}

	public void passValue(int value)
	{
		if (currentDigit == 1) 
		{
			number1 = value;
			Digit1Text.text = value.ToString();
			currentDigit++;

			Debug.Log ("setting first digit");
		}
		else 
		{
			number2 = value;
			Digit2Text.text = value.ToString();

			Debug.Log ("setting second digit");
		}
	}
}
