using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchQuestion : MonoBehaviour {

	public string question;
	public string answer1;
	public string answer2;
	public string answer3;
	public string answer4;
	public int correctAnswer;
	public GameObject buttonA;
	public GameObject buttonB;
	public GameObject buttonC;
	public GameObject buttonD;
	public GameObject questionText;
	public GameObject feedback;


	public void setAnswersAndQuestion() {
		buttonA.GetComponentInChildren<Text>().text = answer1;
		buttonB.GetComponentInChildren<Text>().text = answer2;
		buttonC.GetComponentInChildren<Text>().text = answer3;
		buttonD.GetComponentInChildren<Text>().text = answer4;
		questionText.GetComponent<Text> ().text = question;
	}

	public void isAnswerCorrect(int answer) {
		if (answer == correctAnswer)
			feedback.GetComponent<Text>().text = "Richtig!";
		else
			feedback.GetComponent<Text>().text = "Falsch!";
	}
}
