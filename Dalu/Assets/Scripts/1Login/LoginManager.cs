using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField idInputField;
    public GameObject errorMSG;

    public void LoginButtonClick()
    {
        if (idInputField.text == "")
        {
            errorMSG.SetActive(true);
            return;
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.userName = idInputField.text;
        }

        GameManager.instance.SceneChange("2Main");
    }
}
