using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour
{
    public static CrystalManager s_inst;
    [SerializeField] private GameObject sunCrystalPrefab;
    [SerializeField] private Transform crystalContainer;
    private GameManager gm;
    private List<GameObject> sunCrystals;
    private int amountOfCrystal = 20;
    private int x = 0; // x base coordinate
    private int y = 225; // y base coordinate
    private int z = 45; // z base coordinate
    private int e = 18; // angle base bias

    public void Init()
    {
        gm = GetComponent<GameManager>();
        s_inst = this;
    }

    public void SpawnSunCrystal(ChapterSO chapter)
    {
        ResetList();

        z = 45;
        amountOfCrystal = chapter.CrystalsAmount;
        sunCrystals = new(amountOfCrystal);

        e = 360 / amountOfCrystal;

        ConfigObj(1, -1, amountOfCrystal / 4);
        ConfigObj(-1, -1, amountOfCrystal / 4);
        ConfigObj(-1, 1, amountOfCrystal / 4);
        ConfigObj(1, 1, amountOfCrystal / 4);

        sunCrystals[0].GetComponent<CircleCollider2D>().enabled = true;
        sunCrystals[0].GetComponent<Image>().color = Color.cyan;
    }
    private void ResetList()
    { 
        if (sunCrystals != null)
            foreach (var item in sunCrystals)
            {
                DestroyCrystal(item);
            }
    }
    private void ConfigObj(int xm, int ym, int iteration)
    {
        int pos = 900 / amountOfCrystal;
        for (int k = 0; k < iteration; k++)
        {
            var obj = Instantiate(sunCrystalPrefab, crystalContainer, false);
            obj.transform.localPosition = new Vector2(x += pos * xm, y += pos * ym);
            obj.transform.localRotation = Quaternion.Euler(0, 0, z -= e);
            sunCrystals.Add(obj);
        }
    }
    public void ChangeActiveCrystal()
    {
        if (sunCrystals.Count > 1)
        {
            sunCrystals[1].GetComponent<CircleCollider2D>().enabled = true;
            sunCrystals[1].GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            sunCrystals[0].GetComponent<CircleCollider2D>().enabled = true;
            sunCrystals[0].GetComponent<Image>().color = Color.cyan;
        }
        HideCrystal(0);
        if (sunCrystals.Count == 0)
        {
            gm.LvlUp();
            return;
        }
    }
    private void HideCrystal(int index)
    {
        Destroy(sunCrystals[index]);
        sunCrystals.RemoveAt(index);
        //sunCrystalArray[index].GetComponent<CircleCollider2D>().enabled = false;
        //sunCrystalArray[index].SetActive(false);
    }
    private void DestroyCrystal(GameObject go)
    {
        Destroy(go);
        sunCrystals.Remove(go);
    }
}
