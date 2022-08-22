using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Button mapOpenButton;
    public GameObject largeMap;

    // Start is called before the first frame update
    void Start()
    {
        mapOpenButton.onClick.AddListener(() => MapOpenButtonClick());
    }

    public void MapOpenButtonClick()
    {
        largeMap.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
