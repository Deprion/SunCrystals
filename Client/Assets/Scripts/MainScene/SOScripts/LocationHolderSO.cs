using UnityEngine;

[CreateAssetMenu(menuName = "ManagersSO/LocHolder")]
public class LocationHolderSO : ScriptableObject
{
    [SerializeField] private LocationSO[] locations;

    public LocationSO GetLocation(int index)
    {
        return locations[index];
    }
    public int GetMaxLocIndex()
    {
        return locations.Length - 1;
    }
}
