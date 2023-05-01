using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuConfirmMessage : MonoBehaviour
{
    [SerializeField] PlayerProgress playerProgress = null;
    [SerializeField] GameObject sufficientCoinMessage = null;
    [SerializeField] GameObject insufficientCoinMessage = null;

    void Start()
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

    private void UILevelPackOption_WhenClickedEvent(LevelPackQuiz levelPack, bool isLocked)
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
    }
}
