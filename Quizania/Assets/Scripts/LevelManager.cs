using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] InitialDataGameplay initialData = null;
    [SerializeField] PlayerProgress playerProgress = null;
    private int questionIndex = -1;
    [SerializeField] LevelPackQuiz quizData = null;
    [SerializeField] QuestionsUI questionsUI = null;
    [SerializeField] AnswersUI[] answersUI = new AnswersUI[0];

    [SerializeField] GameSceneManager gameSceneManager = null;
    [SerializeField] string selectMenuSceneName = string.Empty;

    private void Start()
    {
        quizData = initialData.levelPack;
        questionIndex = initialData.levelIndex - 1;
        NextLevel();

        // subscribe events
        AnswersUI.AnswerTheQuestionEvent += AnswersUI_AnswerTheQuestionEvent;
    }

    private void OnDestroy()
    {
        // unsubscribe events
        AnswersUI.AnswerTheQuestionEvent -= AnswersUI_AnswerTheQuestionEvent;
    }

    private void OnApplicationQuit()
    {
        initialData.WhenLose = false;
    }

    private void AnswersUI_AnswerTheQuestionEvent(string answer, bool isTrue)
    {
        if (!isTrue) return;

        string levelPackName = initialData.levelPack.name;
        int latesLevel = playerProgress.progressData.levelProgress[levelPackName];

        if (questionIndex + 2 > latesLevel)
        {
            // add reward coins
            playerProgress.progressData.poin += 20;
            
            // open new level
            playerProgress.progressData.levelProgress[levelPackName] = questionIndex + 2;
            
            playerProgress.SaveProgress();
        }
    }

    public void NextLevel() {
        // next question index
        questionIndex++;

        if (questionIndex >= quizData.QuestionsLength)
        {
            // questionIndex = 0;
            gameSceneManager.OpenScene(selectMenuSceneName);

            return;
        }

        LevelQuizQuestion individualData = quizData.NumOfQuestion(questionIndex);

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