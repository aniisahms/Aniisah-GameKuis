using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelOption : MonoBehaviour
{
    public static event System.Action<int> WhenClickedEvent;

    [SerializeField] Button levelButton = null;
    [SerializeField] TextMeshProUGUI levelName = null;
    [SerializeField] LevelQuizQuestion levelQuiz = null;

    private void Start()
    {
        if (levelQuiz != null)
        {
            SetLevelQuiz(levelQuiz, levelQuiz.levelPackIndex);
        }

        // subscribe event
        levelButton.onClick.AddListener(WhenClicked);
    }

    private void OnDestroy() {
        // unsubscribe event
        levelButton.onClick.RemoveListener(WhenClicked);
    }

    public void SetLevelQuiz(LevelQuizQuestion levelQuiz, int index)
    {
        levelName.text = levelQuiz.name;
        this.levelQuiz = levelQuiz;

        levelQuiz.levelPackIndex = index;
    }

    private void WhenClicked()
    {
        WhenClickedEvent?.Invoke(levelQuiz.levelPackIndex);
    }
}
