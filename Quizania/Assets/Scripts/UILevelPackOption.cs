using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelPackOption : MonoBehaviour
{
    public static event System.Action<LevelPackQuiz> WhenClickedEvent;
    [SerializeField] TextMeshProUGUI packName = null;
    [SerializeField] LevelPackQuiz levelPack = null;
    [SerializeField] Button button = null;

    private void Start()
    {
        if (levelPack != null)
        {
            SetLevelPack(levelPack);
        }

        // subscribe events
        button.onClick.AddListener(WhenClicked);
    }

    private void OnDestroy() {
        // unsubscribe events
        button.onClick.RemoveListener(WhenClicked);
    }

    public void SetLevelPack(LevelPackQuiz levelPack)
    {
        packName.text = levelPack.name;
        this.levelPack = levelPack;
    }

    private void WhenClicked()
    {
        // Debug.Log("Clicked");
        WhenClickedEvent?.Invoke(levelPack);
    }
}
