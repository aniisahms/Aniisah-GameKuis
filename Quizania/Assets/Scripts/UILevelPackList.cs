using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelPackList : MonoBehaviour
{
    [SerializeField] InitialDataGameplay initialData = null;
    [SerializeField] UILevelQuizList levelList = null;
    [SerializeField] UILevelPackOption levelPackButton = null;
    [SerializeField] RectTransform content = null;

    private void Start() {
        // LoadLevelPack();

        if (initialData.WhenLose)
        {
            UILevelPackOption_WhenClickedEvent(initialData.levelPack, false);
        }

        // subscribe events
        UILevelPackOption.WhenClickedEvent += UILevelPackOption_WhenClickedEvent;
    }

    private void OnDestroy() {
        // usubscribe events
        UILevelPackOption.WhenClickedEvent -= UILevelPackOption_WhenClickedEvent;
    }

    private void UILevelPackOption_WhenClickedEvent(LevelPackQuiz levelPack, bool isLocked)
    {
        if (isLocked)
        {
            return;
        }

        // open levels page
        levelList.gameObject.SetActive(true);
        levelList.UnLoadLevelPack(levelPack);

        // close level packs page
        gameObject.SetActive(false);

        initialData.levelPack = levelPack;
    }

    public void LoadLevelPack(LevelPackQuiz[] levelPacks, PlayerProgress.MainData playerData)
    {
        foreach (var lp in levelPacks)
        {
            // duplicate object from level pack button prefab
            var t = Instantiate(levelPackButton);

            t.SetLevelPack(lp);

            // put button object as 'content' object child
            t.transform.SetParent(content);
            t.transform.localScale = Vector3.one;

            // check if the lv pack is registered in player Dictionary progress
            if (!playerData.levelProgress.ContainsKey(lp.name))
            {
                // if not --> lock lv pack
                t.LockLevelPack();
            }
        }
    }
}
