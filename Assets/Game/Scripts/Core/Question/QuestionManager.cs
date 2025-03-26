using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Question question;

    public TMP_Text questionText;
    public TMP_Text[] answerTexts;

    public GameObject questionPanel;

    public QuestionTrigger questionTrigger;
    public static QuestionManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SetQuestion(question);
    }

    public void SetQuestion(Question question)
    {
        this.question = question;
        questionText.text = question.question;
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = question.answers[i];
        }
    }

    public void CheckAnswer(int answer)
    {
        if (answer == question.correctAnswer)
        {
            Debug.Log("Correct Answer");
            question.isCorrect = true;
            questionTrigger.TriggerEffect();
            questionPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Answer");
            question.isCorrect = false;
        }
    }
}
