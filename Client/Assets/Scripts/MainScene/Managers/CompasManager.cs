using UnityEngine;

public class CompasManager : MonoBehaviour
{
    [SerializeField] private LocationHolderSO locs;
    [SerializeField] private GameObject locPrefab;
    [SerializeField] private Transform parent;
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();

        for (int i = 0; i <= locs.GetMaxLocIndex(); i++)
        {
            var go = Instantiate(locPrefab);
            go.transform.SetParent(parent, false);
            var locChoose = go.GetComponent<LocationChoose>();

            if (DataManagerSO.inst.Data.LocationData.maxLoc > i)
                locChoose.SetLoc(gm, i, locs.GetLocation(i).GetMaxChapterIndex());
            else if (DataManagerSO.inst.Data.LocationData.maxLoc == i)
                locChoose.SetLoc(gm, i, DataManagerSO.inst.Data.LocationData.maxChapter);
            else
                locChoose.SetNum(i);
        }
    }
}
