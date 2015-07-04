using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchQuestion : MonoBehaviour {

	public Color correctAns = new Color(.3f, 1.0f, .3f, 1.0f);
	public Color wrongAns   = new Color(1.0f, .3f, .3f, 1.0f);

	public QuizQuestion[] questions;
	public GameObject buttonA;
	public GameObject buttonB;
	public GameObject buttonC;
	public GameObject buttonD;
	public GameObject questionText;
	public GameObject feedback;
	public int activeNumber = 0;
	public bool questionLocked = false;	// lock, when question answered, unlock when displaying new question

	public void Start() {
		questionLocked = false;
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
			"Rot & Türkis",
			2);
		questions[2] = new QuizQuestion(
			"Mit welchen 3 Farben kann man subtraktiv alle anderen Farben mischen?",
			"Türkis, Magenta und Gelb",
			"Rot, Grün und Blau",
			"Orange, Violett und Türkis",
			"Schwarz, Weiß und Grau",
			1);
		questions[3] = new QuizQuestion(
			"Wenn man Türkis, Magenta und Gelb mit dem Pinsel übereinander malt, welche Farbe entsteht?",
			"Schwarz",
			"Weiß",
			"Grau",
			"Braun",
			1);
		questions[4] = new QuizQuestion(
			"Wenn weißes Licht durch ein Glasprisma geht, in welcher Reihenfolge wird der Lichtstrahl zerlegt?",
			"Orange, Grün, Violett, Türkis, Rot, Blau und Gelb",
			"Blau, Grün, Violett, Rot, Gelb, Orange und Türkis",
			"Türkis, Orange, Blau, Grün, Rot, Violett und Gelb",
			"Rot, Orange, Gelb, Grün, Türkis, Blau und Violett",
			4);

	}



	public void setAnswersAndQuestion(int question) {

		buttonA.GetComponentInChildren<Image> ().color = Color.white;
		buttonB.GetComponentInChildren<Image> ().color = Color.white;
		buttonC.GetComponentInChildren<Image> ().color = Color.white;
		buttonD.GetComponentInChildren<Image> ().color = Color.white;

		questionLocked = false;
		activeNumber = question;
		buttonA.GetComponentInChildren<Text> ().text = questions [question].answer1;
		buttonB.GetComponentInChildren<Text>().text = questions [question].answer2;
		buttonC.GetComponentInChildren<Text>().text = questions [question].answer3;
		buttonD.GetComponentInChildren<Text>().text = questions [question].answer4;
		questionText.GetComponent<Text> ().text = questions [question].question;
	}

	public void isAnswerCorrect(int answer) {
		if (questionLocked)
			return;
		else
			questionLocked = true;

		if (answer == questions [activeNumber].correctAnswer)
			feedback.GetComponent<Text> ().text = "Richtig!";
		else {
			feedback.GetComponent<Text> ().text = "Falsch!";

			switch (answer) {
			case 1: buttonA.GetComponentInChildren<Image>().color = wrongAns;break;
			case 2: buttonB.GetComponentInChildren<Image>().color = wrongAns;break;
			case 3: buttonC.GetComponentInChildren<Image>().color = wrongAns;break;
			case 4: buttonD.GetComponentInChildren<Image>().color = wrongAns;break;
			}
		}

		switch (questions[activeNumber].correctAnswer) {
		case 1: buttonA.GetComponentInChildren<Image>().color = correctAns;break;
		case 2: buttonB.GetComponentInChildren<Image>().color = correctAns;break;
		case 3: buttonC.GetComponentInChildren<Image>().color = correctAns;break;
		case 4: buttonD.GetComponentInChildren<Image>().color = correctAns;break;
		}
	}
}
