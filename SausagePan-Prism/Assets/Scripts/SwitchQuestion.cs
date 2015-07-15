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
	public int correctlyAnsweredQuestions = 0;
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
			2,
			"Das hat du dir gut gemerkt! Denn rotes Papier wirft nur rotes Licht zurück, sodass es in dein Auge gelangt. Alle " +
			"anderen Lichtfarben aber verschluckt es, also auch Grün.");
		questions[1] = new QuizQuestion(
			"Welche Lichtfarben muss man mischen um gelbes Licht zu erhalten?",
			"Grün & Blau",
			"Grün & Rot",
			"Blau & Rot",
			"Rot & Türkis",
			2,
			"Prima! In deinem Bildschirm sind tausende von kleinen grünen, roten und blauen Lämpchen, so genannten LEDs. Wenn dein Bildschirm " +
			"gelb ist, dann sind nur die grünen und die roten Lämpchen an.");
		questions[2] = new QuizQuestion(
			"Mit welchen 3 Farben kann man subtraktiv alle anderen Farben mischen?",
			"Türkis, Magenta & Gelb",
			"Rot, Grün & Blau",
			"Orange, Violett & Türkis",
			"Schwarz, Weiß & Grau",
			1,
			"Super! Geh doch mal ganz nah an ein Werbeplakat heran. Dann siehst du, dass diese nur mit den Farben Türkis, " +
			"Magenta, Gelb und manchmal auch Schwarz gedruckt werden. Denn indem man verschiedenfarbige Punkte übereinander " +
			"druckt, entstehen alle anderen Farben.");
		questions[3] = new QuizQuestion(
			"Wenn man Türkis, Magenta und Gelb mit dem Pinsel übereinander malt, welche Farbe entsteht?",
			"Schwarz",
			"Weiß",
			"Grau",
			"Braun",
			1,
			"Genau! Wie du vielleicht noch weißt, verschlucken bunte Malfarben alle Farben bis auf die, die du noch siehst. " +
			"Türkis, Gelb und Magenta zusammen verschlucken alle sichtbaren Farben, sodass (fast) nichts übrig bleibt.");
		questions[4] = new QuizQuestion(
			"In welcher Reihenfolge befinden sich die Farben wenn weißes Sonnenlicht durch ein Glasprisma gebrochen wird?\n\n" +
			"A: Orange, Grün, Violett, Türkis, Rot, Blau und Gelb\n" +
			"B: Blau, Grün, Violett, Rot, Gelb, Orange und Türkis\n" +
			"C: Türkis, Orange, Blau, Grün, Rot, Violett und Gelb\n" +
			"D: Rot, Orange, Gelb, Grün, Türkis, Blau und Violett",
			"A",
			"B",
			"C",
			"D",
			4,
			"Juhuu! Genau so ist es. Dir ist bestimmt aufgefallen, dass es auch die Farben des Regenbogens sind. Denn die " +
			"Wassertröpfchen im Regenbogen tun genau das selbe wie kleine Prismen.");
		questions[5] = new QuizQuestion(
			"Welche Farbe hat eine gelbe Lampe, wenn du sie durch eine grün verspiegelte Sonnenbrille ansiehst?\n\n" +
			"Tipp: Welches Licht lässt die Brille hindurch und welches wirft sie zurück?",
			"A",
			"B",
			"C",
			"D",
			4,
			"Ja, genau! Denn gelbes Licht enthält ja rotes und grünes Licht. Da aber die Sonnenbrille alles grüne Licht durch die " +
			"Verspiegelung nach außen zurückwirft dringt nur der rote Anteil durch die Brille und damit in dein Auge.");


		questions[6] = new QuizQuestion(
			"Wenn du eine blaue und eine rote Lampe auf die gleiche Stelle richtest, in welcher Farbe wird sie dann beleuchtet?",
			"Magenta",
			"Türkis",
			"Gelb",
			"Weiß",
			3,
			"Klasse! Würdest du jetzt noch eine grüne Lampe anschalten, dann wäre die Stelle weiß beleuchtet.");

		questions[7] = new QuizQuestion(
			"Welche ist die Komplementärfarbe (Gegenfarbe) von Magenta?",
			"Gelb",
			"Orange",
			"Grün",
			"Rot",
			3,
			"Ja! Sieh dir doch mal einen Farbkreis an. Die Komplementär- oder Gegenfarben liegen sich dort direkt gegenüber.");

		questions[8] = new QuizQuestion(
			"Welche Farbe siehst du, wenn eine blaue und eine grüne Lampe auf die selbe Stelle leuchten?",
			"Türkis",
			"Magenta",
			"Gelb",
			"Weiß",
			3,
			"So ist es! Du kennst doch Bilder von karibischen Stränden. Da Wasserganz viel rotes Licht schluckt, kommen vom Sonnenlicht " +
			"fast nur grünes und blaues Licht wieder aus dem Wasser heraus. Deshalb hat klares Meerwasser so einen schönen blau- bis " +
			"türkisfarbenen Ton.");

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

		feedback.GetComponent<Text> ().text = "";
	}

	public void isAnswerCorrect(int answer) {
		if (questionLocked)
			return;
		else
			questionLocked = true;

		if (answer == questions [activeNumber].correctAnswer) {
			feedback.GetComponent<Text> ().text = "Richtig!";
			questionText.GetComponent<Text>().text = questions[activeNumber].solution;

			if(!questions[activeNumber].alreadyAnswered) correctlyAnsweredQuestions++;

			questions[activeNumber].alreadyAnswered = true;
		}

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
