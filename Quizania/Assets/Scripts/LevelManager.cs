using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerProgress playerProgress = null;
    private int questionIndex = -1;
    [SerializeField] LevelPackQuiz quizData = null;
    [SerializeField] QuestionsUI questionsUI = null;
    [SerializeField] AnswersUI[] answersUI = new AnswersUI[0];

    private void Start() {
        if (playerProgress.LoadProgress() == false)
        {
            playerProgress.SaveProgress();
        }
        NextLevel();
    }

    public void NextLevel() {
        questionIndex++;

        if (questionIndex >= quizData.questionLength)
        {
            questionIndex = 0;
        }

        LevelQuizQuestion individualData = quizData.numOfQuestion(questionIndex);

        questionsUI.SetQuestion($"Question {questionIndex + 1}",
        individualData.questionText, individualData.questionImage);

        for (int i = 0; i < answersUI.Length; i++)
        {
            AnswersUI value = answersUI[i];
            LevelQuizQuestion.AnswerOption option = individualData.answerOption[i];
            value.SetAnswer(option.answerOption, option.isTrue);
        }
    }
}