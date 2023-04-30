using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMessageUI : MonoBehaviour
{
    [SerializeField] GameObject correctOption = null;
    [SerializeField] GameObject wrongOption = null;
    [SerializeField] TextMeshProUGUI messageText = null;
    public string Message {
        get => messageText.text;
        set => messageText.text = value;
    }
    
    private void Awake() {
        // disable UI level message
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }

        // subscribe event
        TimerUI.TimeOverEvent += TimerUI_TimeOverEvent;
        AnswersUI.AnswerTheQuestionEvent += AnswersUI_AnswerTheQuestionEvent;
    }

    private void OnDestroy() {
        // unsubscribe event
        TimerUI.TimeOverEvent -= TimerUI_TimeOverEvent;
        AnswersUI.AnswerTheQuestionEvent -= AnswersUI_AnswerTheQuestionEvent;
    }

    private void TimerUI_TimeOverEvent()
    {
        Message = "You're run out of time.";
        gameObject.SetActive(true);

        correctOption.SetActive(false);
        wrongOption.SetActive(true);
    }

    private void AnswersUI_AnswerTheQuestionEvent(string answerText, bool isTrue)
    {
        Message = $"Your answer is {isTrue} (Answer: {answerText})";
        gameObject.SetActive(true);

        if (isTrue)
        {
            correctOption.SetActive(true);
            wrongOption.SetActive(false);
        }
        else
        {
            correctOption.SetActive(false);
            wrongOption.SetActive(true);
        }
    }
}
