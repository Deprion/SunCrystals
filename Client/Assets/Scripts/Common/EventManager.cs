using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager inst;

    public Action<int> EOnLvlUpdate, EOnChapterUpdate, EOnLocUpdate;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        inst = this;
    }

    public void OnLvlUpdateInvoke(int lvl)
    {
        EOnLvlUpdate?.Invoke(lvl);
    }
    public void OnChapterUpdateInvoke(int lvl)
    {
        EOnChapterUpdate?.Invoke(lvl);
    }
    public void OnLocUpdateInvoke(int lvl)
    {
        EOnLocUpdate?.Invoke(lvl);
    }
}
