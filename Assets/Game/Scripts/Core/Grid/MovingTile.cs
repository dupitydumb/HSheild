using UnityEngine;

public class MovingTile : MonoBehaviour, IMoveable
{
    public float speed = 5f;
    public Vector3 destination;
    private Vector3 startPosition;
    public bool isTriggered;
    bool isMoved;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isTriggered)
        {
            MoveTiles();
        }
    }

    public void MoveTile()
    {
        isTriggered = true;
    }
    public void MoveTiles()
    {
        if (!isMoved)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            if (transform.position == destination)
            {
                isMoved = true;
                //Disable child colliders
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        
    }
}
