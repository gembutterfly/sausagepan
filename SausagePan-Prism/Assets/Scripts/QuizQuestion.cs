using UnityEngine;
using System.Collections;

public class QuizQuestion : ScriptableObject {

	public string question;
	public string answer1;
	public string answer2;
	public string answer3;
	public string answer4;
	public int    correctAnswer;
	public string solution;
	public bool   alreadyAnswered;

	public QuizQuestion(string question,
	                    string answer1,
	                    string answer2,
	                    string answer3,
	                    string answer4,
	                    int correctAnswer,
	                    string solution) {
		this.question = question;
		this.answer1 = answer1;
		this.answer2 = answer2;
		this.answer3 = answer3;
		this.answer4 = answer4;
		this.correctAnswer = correctAnswer;
		this.solution = solution;
		this.alreadyAnswered = false;
	}
}
