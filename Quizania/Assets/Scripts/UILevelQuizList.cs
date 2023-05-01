using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelQuizList : MonoBehaviour
{
    [SerializeField] InitialDataGameplay initialData = null;
    [SerializeField] PlayerProgress playerProgress = null;
    [SerializeField] UILevelOption levelButton = null;
    [SerializeField] RectTransform content = null;
    [SerializeField] LevelPackQuiz levelPack = null;
    [SerializeField] GameSceneManager gameSceneManager = null;
    [SerializeField] string gameplayScene = null;

    private void Start()
    {
        // subscribe events
        UILevelOption.WhenClickedEvent += UILevelOption_WhenClickedEvent;
    }

    private void OnDestroy()
    {
        // usubscribe events
        UILevelOption.WhenClickedEvent -= UILevelOption_WhenClickedEvent;
    }

    private void UILevelOption_WhenClickedEvent(int index)
    {
        initialData.levelIndex = index;
        gameSceneManager.OpenScene(gameplayScene);
    }

    // open, load, show levels from pack
    public void UnLoadLevelPack(LevelPackQuiz levelPack)
    {
        DeleteContent();

        var latestLevelUnlocked = playerProgress.progressData.levelProgress[levelPack.name] - 1;

        this.levelPack = levelPack;

        for (int i = 0; i < levelPack.QuestionsLength; i++)
        {
            // duplicate object from level button prefab
            var t = Instantiate(levelButton);

            t.SetLevelQuiz(levelPack.NumOfQuestion(i), i);

            // put button object as 'content' object child
            t.transform.SetParent(content);
            t.transform.localScale = Vector3.one;

            if (i > latestLevelUnlocked)
            {
                t.ButtonInteraction = false;
            }
        }
    }

    private void DeleteContent()
    {
        var cc = content.childCount;

        for (int i = 0; i < cc; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }
}
