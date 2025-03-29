using UnityEngine;
using UnityEngine.Events;

public class FinishedTrigger : MonoBehaviour
{
    private Transform playerTransform;

    public UnityEvent onPlayerFinished;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlayerFinished?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
