using System.Collections;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    public static TipsManager Instance;
    public TMP_Text tipsHeader;
    public TMP_Text tipsText;
    public TipsSO tipsSO;
    public GameObject tipsPanel;


    private void Awake()
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

    private void Start()
    {
        tipsPanel.SetActive(false);
        
    }

    public void ShowTips()
    {
        tipsPanel.SetActive(true);
        tipsHeader.text = tipsSO.tipsHeader;
        tipsText.text = tipsSO.tips;
        StartCoroutine(HideTipsCoroutine());
    }

    IEnumerator HideTipsCoroutine()
    {
        yield return new WaitForSeconds(3);
        HideTips();
    }

    public void HideTips()
    {
        tipsPanel.SetActive(false);
    }

    public void SetTips(TipsSO tips)
    {
        tipsSO = tips;
        ShowTips();
    }
}
