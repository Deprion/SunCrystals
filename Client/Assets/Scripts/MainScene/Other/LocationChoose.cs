using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationChoose : MonoBehaviour
{
    [SerializeField] private TMP_Text numLocTxt;
    [SerializeField] private Button btn;

    public void SetLoc(GameManager gm, int loc, int chapter)
    {
        numLocTxt.text = "Location: " + loc;
        btn.onClick.AddListener(delegate
        {
            gm.SetCustomLvl(loc, chapter);
        });
    }
    public void SetNum(int loc)
    {
        numLocTxt.text = "Location: " + loc;
    }
}
