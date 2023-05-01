using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] UILevelPackList levelPackList = null;
    [SerializeField] PlayerProgress playerProgress = null;
    [SerializeField] TextMeshProUGUI coinCountUI = null;
    [SerializeField] LevelPackQuiz[] levelPacks = new LevelPackQuiz[0];
    
    void Start()
    {
        // if (playerProgress.LoadProgress() == false)
        // {
        //     playerProgress.SaveProgress();
        // }

        if (!playerProgress.LoadProgress())
        {
            playerProgress.SaveProgress();
        }

        levelPackList.LoadLevelPack(levelPacks, playerProgress.progressData);

        coinCountUI.text = $"{playerProgress.progressData.poin}";
    }
}
