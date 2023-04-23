using UnityEngine;

[CreateAssetMenu(
    fileName = "New Question",
    menuName = "Level Quiz Question"
)]

public class LevelQuizQuestion : ScriptableObject
{
    [System.Serializable]
    public struct AnswerOption {
        public string answerOption;
        public bool isTrue;
    }

    public string questionText = string.Empty;
    public Sprite questionImage = null;
    
    public AnswerOption[] answerOption = new AnswerOption[0];
}
