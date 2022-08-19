using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject targetPosition;
    public bool movetarget;
    // Start is called before the first frame update
    void Start()
    {
        //movetarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveTarget();
    }

    public void moveTarget()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 0.02f);
    }
}
