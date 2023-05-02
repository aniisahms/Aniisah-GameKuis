using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuConfirmMessage : MonoBehaviour
{
    [SerializeField] PlayerProgress playerProgress = null;
    [SerializeField] GameObject sufficientCoinMessage = null;
    [SerializeField] GameObject insufficientCoinMessage = null;
    private UILevelPackOption _levelPackButton = null;
    private LevelPackQuiz _levelPack = null;
    [SerializeField] LevelMenuDataManager levelMenuDataManager;

    private void Start()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        // subscribe event
        UILevelPackOption.WhenClickedEvent += UILevelPackOption_WhenClickedEvent;
    }

    private void OnDestroy()
    {
        // unsubscribe event
        UILevelPackOption.WhenClickedEvent -= UILevelPackOption_WhenClickedEvent;
    }

    private void UILevelPackOption_WhenClickedEvent(UILevelPackOption levelPackButton,
        LevelPackQuiz levelPack, bool isLocked)
    {
        if (!isLocked) return;

        gameObject.SetActive(true);

        if (playerProgress.progressData.poin < levelPack.Price)
        {
            // insufficient
            sufficientCoinMessage.SetActive(false);
            insufficientCoinMessage.SetActive(true);

            return;
        }

        // sufficient
        sufficientCoinMessage.SetActive(true);
        insufficientCoinMessage.SetActive(false);

        _levelPackButton = levelPackButton;
        _levelPack = levelPack;
    }

    public void UnlockLevel()
    {
        playerProgress.progressData.poin -= _levelPack.Price;
        playerProgress.progressData.levelProgress[_levelPack.name] = 1;

        levelMenuDataManager.coinCountUI.text = $"{playerProgress.progressData.poin}";

        playerProgress.SaveProgress();
        _levelPackButton.UnlockLevelPack();
    }
}
