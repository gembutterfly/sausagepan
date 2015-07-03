using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchQuestion : MonoBehaviour {

	public QuizQuestion[] questions;
	public GameObject buttonA;
	public GameObject buttonB;
	public GameObject buttonC;
	public GameObject buttonD;
	public GameObject questionText;
	public GameObject feedback;
	public int activeNumber = 0;

	public void Start() {
		questions = new QuizQuestion[10];
		questions[0] = new QuizQuestion(
			"Welche Farbe hat ein rein rotes Blatt Papier unter reinem grünem Licht?",
			"Grün",
			"Schwarz",
			"Rot",
			"Weiß",
			2);
		questions[1] = new QuizQuestion(
			"Welche Lichtfarben muss man mischen um gelbes Licht zu erhalten?",
			"Grün & Blau",
			"Grün & Rot",
			"Blau & Rot",
			"Rot & Cyan",
			2);
	}



	public void setAnswersAndQuestion(int question) {
		activeNumber = question;
		buttonA.GetComponentInChildren<Text> ().text = questions [question].answer1;
		buttonB.GetComponentInChildren<Text>().text = questions [question].answer2;
		buttonC.GetComponentInChildren<Text>().text = questions [question].answer3;
		buttonD.GetComponentInChildren<Text>().text = questions [question].answer4;
		questionText.GetComponent<Text> ().text = questions [question].question;
	}

	public void isAnswerCorrect(int answer) {
		if (answer == questions[activeNumber].correctAnswer)
			feedback.GetComponent<Text>().text = "Richtig!";
		else
			feedback.GetComponent<Text>().text = "Falsch!";
	}
}
