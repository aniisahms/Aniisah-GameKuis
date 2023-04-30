using UnityEngine;

[CreateAssetMenu(
    fileName = "Initial Data Gameplay",
    menuName = "Initial Data Gameplay"
)]

public class InitialDataGameplay : ScriptableObject
{
    public LevelPackQuiz levelPack = null;
    public int levelIndex = 0;

    [SerializeField] bool whenLose = false;

    public bool WhenLose
    {
        get => whenLose;
        set => whenLose = value;
    }
}
