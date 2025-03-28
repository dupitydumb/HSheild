using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    private GameObject player;
    public TipsSO tips;
    public GameObject marker;
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
                TriggerTips();
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

    public void TriggerTips()
    {
        TipsManager.Instance.SetTips(tips);
    }
}
