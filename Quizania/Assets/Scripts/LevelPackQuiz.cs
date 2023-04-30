using UnityEngine;

[CreateAssetMenu(
    fileName = "New Level Pack",
    menuName = "Level Pack Quiz"
)]

public class LevelPackQuiz : ScriptableObject
{
    [SerializeField] LevelQuizQuestion[] levelQuizQuestion = new LevelQuizQuestion[0];
    public int questionLength => levelQuizQuestion.Length;

    public LevelQuizQuestion NumOfQuestion(int index) {
        return levelQuizQuestion[index];
    }
}
