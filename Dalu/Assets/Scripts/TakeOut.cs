using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOut : MonoBehaviour
{
    public GameObject[] point_ins;
    public GameObject[] point_outs;

    public void delivery_now()
    {
        point_ins[0].gameObject.SetActive(true);
        point_ins[1].gameObject.SetActive(false);
        point_ins[2].gameObject.SetActive(false);
        point_outs[0].gameObject.SetActive(false);
        point_outs[1].gameObject.SetActive(true);
        point_outs[2].gameObject.SetActive(true);
    }
    public void takeOut()
    {
        point_ins[0].gameObject.SetActive(false);
        point_ins[1].gameObject.SetActive(true);
        point_ins[2].gameObject.SetActive(false);
        point_outs[0].gameObject.SetActive(true);
        point_outs[1].gameObject.SetActive(false);
        point_outs[2].gameObject.SetActive(true);
    }
    public void delivery_home()
    {
        point_ins[0].gameObject.SetActive(false);
        point_ins[1].gameObject.SetActive(false);
        point_ins[2].gameObject.SetActive(true);
        point_outs[0].gameObject.SetActive(true);
        point_outs[1].gameObject.SetActive(true);
        point_outs[2].gameObject.SetActive(false);
    }
}
