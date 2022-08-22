using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Button daejeonButton;
    public Button sejongButton;
    public Button avataButton;

    public void Start()
    {
        daejeonButton.onClick.AddListener(()=> DaejeonSelect());
        sejongButton.onClick.AddListener(()=> SejongSelect());
        avataButton.onClick.AddListener(() => AvataChange());
    }

    public void SejongSelect()
    {
        GameManager.instance.SceneChange("3World");
    }

    public void DaejeonSelect()
    {
        GameManager.instance.SceneChange("3World");
    }

    public void AvataChange()
    {
        GameManager.instance.SceneChange("5Avata");
    }
}
