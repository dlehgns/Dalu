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
            //tapViewImage[i].SetActive(false);

            LeanTween.moveLocal(tapViewImage[i], new Vector3(-750, -300, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
        }
    }

    public void HatButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(hatButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[0].SetActive(true);
        LeanTween.moveLocal(tapViewImage[0], new Vector3(0, -300, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
    }
    public void HairButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(hairButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[1].SetActive(true);
        LeanTween.moveLocal(tapViewImage[1], new Vector3(0, -300, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
    }
    public void TopButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(topButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[2].SetActive(true);
        LeanTween.moveLocal(tapViewImage[2], new Vector3(0, -300, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
    }
    public void PantsButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(pantsButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[3].SetActive(true);
        LeanTween.moveLocal(tapViewImage[3], new Vector3(0, -300, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
    }
    public void ShoesButton()
    {
        EmphasisImage.anchoredPosition = new Vector3(shoesButton.GetComponent<RectTransform>().anchoredPosition.x, EmphasisImage.anchoredPosition.y, 0);
        PanelOff();
        tapViewImage[4].SetActive(true);
        LeanTween.moveLocal(tapViewImage[4], new Vector3(0, -300, 0), 0.7f).setDelay(.1f).setEase(LeanTweenType.easeInOutCirc);
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
