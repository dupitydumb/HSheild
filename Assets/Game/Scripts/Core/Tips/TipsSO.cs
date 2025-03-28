using UnityEngine;

[CreateAssetMenu(fileName = "Tips", menuName = "ScriptableObjects/Tips")]
public class TipsSO : ScriptableObject
{
    
    public string tipsHeader;
    [TextArea(3, 10)]
    public string tips;

}
