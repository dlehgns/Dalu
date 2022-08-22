using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gps : MonoBehaviour
{
    float xx = 0.01f;
    float yy = 0.01f;

    public Transform player;

    public Text coordinate;

    private void Update()
    {
        GPSInput();
    }

    public void GPSInput() // 위경도 입력
    {
        float longitude = 127.15f + (player.transform.position.x * xx); // 경도 36.37 + 12017*0.13
        float latitude = 36.37f + (player.transform.position.z * yy); // 위도

        int loD = Mathf.FloorToInt(longitude);
        int loM = Mathf.FloorToInt((longitude - loD) * 60);
        int loS = Mathf.FloorToInt(((longitude - loD) * 60 - loM) * 60);

        int laD = Mathf.FloorToInt(latitude);
        int laM = Mathf.FloorToInt((latitude - laD) * 60);
        int laS = Mathf.FloorToInt(((latitude - laD) * 60 - laM) * 60);

        coordinate.text = $"{loD}°{loM}'{loS}E   {laD}°{laM}'{laS}N";
    }
}
