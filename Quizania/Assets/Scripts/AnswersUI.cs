using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswersUI : MonoBehaviour
{
    public static event System.Action<string, bool> AnswerTheQuestionEvent;
    // [SerializeField] LevelMessageUI messageUI = null;
    [SerializeField] TextMeshProUGUI answerText = null;
    [SerializeField] bool isTrue = false;

    public void SelectAnswer() {
        // messageUI.Message = $"{answerText.text} adalah {isTrue}";
        AnswerTheQuestionEvent?.Invoke(answerText.text, isTrue);
    }

    public void SetAnswer(string answerText, bool isTrue)
    {
        this.answerText.text = answerText;
        this.isTrue = isTrue;
    }
}
