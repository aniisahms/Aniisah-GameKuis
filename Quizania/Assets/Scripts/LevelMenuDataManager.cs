using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] PlayerProgress playerProgress = null;
    [SerializeField] TextMeshProUGUI coinCountUI = null;
    
    void Start()
    {
        coinCountUI.text = $"{playerProgress.progressData.poin}";
    }
}
