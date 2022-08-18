using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Alpha값(0.1f) 이상만 버튼 클릭되도록 하는 부착 스크립트
/// </summary>
public class ATTACHAlphaButton : MonoBehaviour
{
    public float iAlphaThreshhold = 0.1f;

    private void Start()
    {
        this.GetComponent<Image>()
            .alphaHitTestMinimumThreshold = this.iAlphaThreshhold;
    }
}