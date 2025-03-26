using UnityEngine;
using System.Collections.Generic;

public class QuestionTrigger : MonoBehaviour
{
    private GameObject player;
    public Question question;
    public GameObject effectedObject;
    private GameObject marker;
    bool isMarkerActive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        marker = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1f)
        {
            if (!isMarkerActive)
            {
                marker.SetActive(true);
                isMarkerActive = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerQuestion();
            }
        }
        else
        {
            if (isMarkerActive)
            {
                marker.SetActive(false);
                isMarkerActive = false;
            }
        }
    }

    public void TriggerQuestion()
    {
        QuestionManager.Instance.SetQuestion(question);
        QuestionManager.Instance.questionTrigger = this;
        QuestionManager.Instance.questionPanel.SetActive(true);
    }

    public void TriggerEffect()
    {
        if (effectedObject != null)
        {
            IMoveable moveable = effectedObject.GetComponent<IMoveable>();
            if (moveable != null)
            {
                moveable.MoveTile();
            }
        }
    }
}
