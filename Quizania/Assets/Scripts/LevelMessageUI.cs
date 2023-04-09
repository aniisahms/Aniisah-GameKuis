using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMessageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText = null;
    public string Message {
        get => messageText.text;
        set => messageText.text = value;
    }
    
    private void Awake() {
        // untuk mematikan UI level message
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }
}
