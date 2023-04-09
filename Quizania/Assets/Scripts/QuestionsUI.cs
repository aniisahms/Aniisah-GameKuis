using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title = null;
    [SerializeField] TextMeshProUGUI questionText = null;
    [SerializeField] Image questionImage = null;

    public void SetQuestion(string title, string questionText, Sprite questionImage) {
        this.title.text = title;
        this.questionText.text = questionText;
        this.questionImage.sprite = questionImage;
    }
}
