using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LocationManager locationManager;
    private CrystalManager crystalManager;
    private bool isProgressing = true;

    private void Awake()
    {
        locationManager = GetComponent<LocationManager>();
        crystalManager = GetComponent<CrystalManager>();

        locationManager.Init(DataManagerSO.inst.Data.LocationData);
        crystalManager.Init();
        crystalManager.SpawnSunCrystal(locationManager.GetMaxChapter());
    }

    private void SetLocChapter(int loc, int chapter)
    {
        crystalManager.SpawnSunCrystal(locationManager.GetChapter(loc, chapter));
    }
    private void SetMaxChapter()
    {
        crystalManager.SpawnSunCrystal(locationManager.GetMaxChapter());
    }
    public void SetCustomLvl(int loc, int chapter)
    {
        if (loc == DataManagerSO.inst.Data.LocationData.maxLoc &&
            chapter == DataManagerSO.inst.Data.LocationData.maxChapter)
        {
            isProgressing = true;
            SetMaxChapter();
        }
        else
        {
            isProgressing = false;
            SetLocChapter(loc, chapter);
        }
    }

    public void LvlUp()
    {
        if (isProgressing)
        {
            locationManager.LvlUp();
            crystalManager.SpawnSunCrystal(locationManager.GetMaxChapter());
        }
        else
            SetLocChapter(DataManagerSO.inst.Data.LocationData.numLocation,
                DataManagerSO.inst.Data.LocationData.numChapter);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            DataManagerSO.inst.SaveData();
        }
    }
}
