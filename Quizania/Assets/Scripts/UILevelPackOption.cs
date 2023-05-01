using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelPackOption : MonoBehaviour
{
    public static event System.Action<LevelPackQuiz, bool> WhenClickedEvent;
    [SerializeField] TextMeshProUGUI packName = null;
    [SerializeField] LevelPackQuiz levelPack = null;
    [SerializeField] Button button = null;

    [SerializeField] TextMeshProUGUI lockedLabel = null;
    [SerializeField] TextMeshProUGUI priceLabel = null;
    [SerializeField] bool isLocked = false;

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
        WhenClickedEvent?.Invoke(levelPack, isLocked);
    }

    public void LockLevelPack()
    {
        isLocked = true;
        lockedLabel.gameObject.SetActive(true);
        priceLabel.transform.parent.gameObject.SetActive(true);
        priceLabel.text = $"{levelPack.Price}";
    }

    public void UnlockLevelPack()
    {
        isLocked = false;
        lockedLabel.gameObject.SetActive(false);
        priceLabel.transform.parent.gameObject.SetActive(false);
    }
}
