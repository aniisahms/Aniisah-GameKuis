using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct QuizData {
        public string questionText;
        public Sprite questionImage;
        public string[] answerOption; 
        public bool[] isTrue;
    }

    private int questionIndex = -1;
    [SerializeField] QuizData[] quizData = new QuizData[0];
    [SerializeField] QuestionsUI questionsUI = null;
    [SerializeField] AnswersUI[] answersUI = new AnswersUI[0];

    private void Start() {
        NextLevel();
    }

    public void NextLevel() {
        questionIndex++;

        if (questionIndex >= quizData.Length) {
            questionIndex = 0;
        }

        QuizData individualData = quizData[questionIndex];
        questionsUI.SetQuestion($"Question {questionIndex + 1}",
        individualData.questionText, individualData.questionImage);

        for (int i = 0; i < answersUI.Length; i++) {
            AnswersUI value = answersUI[i];
            value.SetAnswer(individualData.answerOption[i], individualData.isTrue[i]);
        }
    }
}