using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Question", order = 1)]
public class Question : ScriptableObject
{
    public string question;
    public string[] answers;
    public int correctAnswer;
    public bool isAnswered;
    public bool isCorrect;

    public void CheckAnswer(int answer)
    {
        isAnswered = true;
        if (answer == correctAnswer)
        {
            isCorrect = true;
        }
    }   
}
