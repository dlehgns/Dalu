using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNickName : MonoBehaviour
{
    public Transform camRig;
    public Transform nickNameCanvas;
    public Text nickName;

    void Start()
    {
        if (GameManager.instance)
        {
            if (GameManager.instance.userName != null)
            {
                nickName.text = GameManager.instance.userName;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        nickNameCanvas.LookAt(camRig);


    }
}
