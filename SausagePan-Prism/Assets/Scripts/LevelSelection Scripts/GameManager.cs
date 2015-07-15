using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//zeigt, ob der jeweilige Level schon bestanden ist oder nicht
	static bool levelOneClear = false;
	static bool levelTwoClear = false;
	static bool levelThreeClear = false;
	static bool levelFourClear = false;
	static bool levelFiveClear = false;
	static bool levelSixClear = false;

	//dazu kommt ein Counter, damit der kleine Mann sich zu nächsten Level
	//bewegen kann, 
	static int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Wenn ein Level beendet wird, wird der Wert auch geändert
	public void changeLevelValue(int index)
	{
		switch (index) 
		{
		case 1: levelOneClear = true; break;
		case 2: levelTwoClear = true; break;
		case 3: levelThreeClear = true; break;
		case 4: levelFourClear = true; break;
		case 5: levelFiveClear = true; break;
		case 6: levelSixClear = true; break;
		}

	}

	//Abfrage für das Rendern der Sprites
	//Bei false schwarz-weiß
	//Bei true farbe
	public bool getLevelValue(int index)
	{
		bool value  = false;
		switch (index)
		{
		case 0: value = true; break;
		case 1: value = levelOneClear ; break;
		case 2: value = levelTwoClear; break;
		case 3: value = levelThreeClear; break;
		case 4: value = levelFourClear; break;
		case 5: value = levelFiveClear; break;
		case 6: value = levelSixClear; break;
		}

		return value;
	}

	public void setCounter(int number)
	{
		counter = number;
	}

	public int getCounter()
	{
		int value = counter;
		return value;
	}

}
