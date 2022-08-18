using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinLean : MonoBehaviour
{
    public GameObject[] regionList;
    public GameObject region;
    public GameObject korea;
    public GameObject Back;

    public void MapIn(GameObject on)
    {
        Back.SetActive(true);
        on.SetActive(true);
        LeanTween.moveLocal(region, new Vector3(500, -500, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
        LeanTween.moveLocal(korea, new Vector3(500, 1000, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
    }

    public void MapOut()
    {
        for (int i = 0; i < regionList.Length; i++)
        {
            regionList[i].SetActive(false);
        }
        Back.SetActive(false);
        LeanTween.moveLocal(region, new Vector3(500, 1000, 0f), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
        LeanTween.moveLocal(korea, new Vector3(500, 0, 0f), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
    }
}
