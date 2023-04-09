using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswersUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI answerText = null;
    [SerializeField] LevelMessageUI messageUI = null;
    [SerializeField] bool isTrue = false;

    public void SelectAnswer() {
        messageUI.Message = $"{answerText.text} adalah {isTrue}";
    }

    public void SetAnswer(string answerText, bool isTrue)
    {
        this.answerText.text = answerText;
        this.isTrue = isTrue;
    }
}
