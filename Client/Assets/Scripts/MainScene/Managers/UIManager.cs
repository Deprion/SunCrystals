using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentLvlTxt, currentLocTxt, currentChapterTxt;
    private void Awake()
    {
        EventManager.inst.EOnLvlUpdate += UpdateLvl;
        EventManager.inst.EOnChapterUpdate += UpdateChapter;
        EventManager.inst.EOnLocUpdate += UpdateLoc;
    }
    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        var data = DataManagerSO.inst.Data.LocationData;
        currentLvlTxt.text = data.maxLvl.ToString();
        currentLocTxt.text = $"Location: {data.maxLoc}";
        currentChapterTxt.text = $"Chapter: {data.maxChapter}";
    }

    private void UpdateLoc(int loc)
    {
        currentLocTxt.text = $"Location: {loc}";
    }
    private void UpdateChapter(int chapter)
    {
        currentChapterTxt.text = $"Chapter: {chapter}";
    }
    private void UpdateLvl(int lvl)
    {
        currentLvlTxt.text = lvl.ToString();
    }
    private void OnDestroy()
    {
        EventManager.inst.EOnLvlUpdate -= UpdateLvl;
        EventManager.inst.EOnChapterUpdate -= UpdateChapter;
        EventManager.inst.EOnLocUpdate -= UpdateLoc;
    }
}
