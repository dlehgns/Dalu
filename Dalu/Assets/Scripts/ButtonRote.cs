using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRote : MonoBehaviour
{
    float rotSpeed = 150f;    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
}
