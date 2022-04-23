using UnityEngine;

[CreateAssetMenu(menuName = "Loc/Location")]
public class LocationSO : ScriptableObject
{
    [SerializeField] private ChapterSO[] chapters;
    public double DelayTime;

    public ChapterSO GetChapter(int index)
    {
        return chapters[index];
    }
    public int GetMaxChapterIndex()
    {
        return chapters.Length - 1;
    }
}
