using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField] private LocationHolderSO locations;
    public static LocationManager s_inst;
    public double DelayTime { get; private set; }
    private LocationData data;
    private bool isMaxLevel 
    {
        get
        {
            LocationSO maxLoc = locations.GetLocation(data.maxLoc);
            bool max = locations.GetMaxLocIndex() == data.maxLoc &&
                data.maxChapter == maxLoc.GetMaxChapterIndex() &&
                data.maxLvl == maxLoc.GetChapter(data.maxChapter).MaxLvl;
            return max;
        }
    }

    public void Init(LocationData data)
    {
        this.data = data;
        s_inst = this;
    }
    public void LvlUp()
    {
        if (isMaxLevel) return;

        data.maxLvl++;
        if (data.maxLvl > locations.GetLocation(data.maxLoc).GetChapter(data.maxChapter).MaxLvl)
        {
            data.maxLvl = 0;
            data.maxChapter++;
            if (data.maxChapter > locations.GetLocation(data.maxLoc).GetMaxChapterIndex())
            {
                data.maxChapter = 0;
                data.maxLoc++;
                EventManager.inst.OnLocUpdateInvoke(data.maxLoc);
            }
            EventManager.inst.OnChapterUpdateInvoke(data.maxChapter);
        }
        EventManager.inst.OnLvlUpdateInvoke(data.maxLvl);
    }
    public ChapterSO GetChapter(int loc, int chapter)
    {
        return locations.GetLocation(loc).GetChapter(chapter);
    }
    public ChapterSO GetMaxChapter()
    {
        return locations.GetLocation(data.maxLoc).GetChapter(data.maxChapter);
    }
}
