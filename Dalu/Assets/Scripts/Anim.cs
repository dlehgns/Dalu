using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //animPause();
        //animPlay();
    }

    public void animPlay()
    {
        anim["Event"].speed = 0;
    }
    public void animPause()
    {
        anim["Event"].speed = 0;
    }
}
