using System;

public class Data
{
    public LocationData LocationData;
}

[Serializable] public class LocationData
{
    public int maxLoc, maxChapter, maxLvl;
    public int numLocation, numChapter, numLvl;
}
