using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Alpha��(0.1f) �̻� ��ư Ŭ���ǵ��� �ϴ� ���� ��ũ��Ʈ
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