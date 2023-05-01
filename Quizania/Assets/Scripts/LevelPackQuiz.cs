using UnityEngine;

[CreateAssetMenu(
    fileName = "New Level Pack",
    menuName = "Level Pack Quiz"
)]

public class LevelPackQuiz : ScriptableObject
{
    [SerializeField] LevelQuizQuestion[] levelQuizQuestion = new LevelQuizQuestion[0];
    public int QuestionsLength => levelQuizQuestion.Length;

    [SerializeField] int price = 0;
    public int Price => price;

    public LevelQuizQuestion NumOfQuestion(int index) {
        return levelQuizQuestion[index];
    }
}
