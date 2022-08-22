using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvataManager : MonoBehaviour
{
    public GameObject[] tapViewImage;

    public Button hatButton;
    public Button hairButton;
    public Button topButton;
    public Button pantsButton;
    public Button shoesButton;

    public Button manButton;
    public Button womanButton;
    public Button saveButton;
    public Button exitButton;
    public RectTransform EmphasisImage;


    public void Start()
    {
        hatButton.onClick.AddListener(() => HatButton());
        hairButton.onClick.AddListener(() => HairButton());
        topButton.onClick.AddListener(() => TopButton());
        pantsButton.onClick.AddListener(() => PantsButton());
        shoesButton.onClick.AddListener(() => ShoesButton());

        manButton.onClick.AddListener(() => ManButton());
        womanButton.onClick.AddListener(() => WoManButton());
        saveButton.onClick.AddListener(() => Save());
        exitButton.onClick.AddListener(() => Exit());
    }

    public void PanelOff()
    {
        for (int i = 0; i < tapViewImage.Length; i++)
        {
            tapViewImage[i].SetActive(false);
        }
    }

    public void HatButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(hatButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[0].SetActive(true);
    }
    public void HairButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(hairButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[1].SetActive(true);
    }
    public void TopButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(topButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[2].SetActive(true);
    }
    public void PantsButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(pantsButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[3].SetActive(true);
    }
    public void ShoesButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(shoesButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[4].SetActive(true);
    }

    public void ManButton()
    {
        manButton.GetComponent<Image>().color = Color.blue;
        womanButton.GetComponent<Image>().color = Color.gray;
    }

    public void WoManButton()
    {
        womanButton.GetComponent<Image>().color = Color.red;
        manButton.GetComponent<Image>().color = Color.gray;
    }

    public void Save()
    {
        GameManager.instance.SceneChange("2Main");
    }

    public void Exit()
    {
        GameManager.instance.SceneChange("2Main");
    }
}
