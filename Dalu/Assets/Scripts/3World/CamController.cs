using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    public Transform maincamera;
    public float playerHigh;
    public float xmove = 2;
    public float ymove = 25;
    public float distance = 1;
    private float wheelspeed = 10.0f;
    private Vector3 Player_Height;
    private Vector3 Player_Side;

    RaycastHit hit;

    void Start()
    {
        Player_Height = new Vector3(0, 1.5f, 0f);
        Player_Side = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        CameCon();
    }

    public void CameCon()
    {
        #region Zoom in Out

        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;

        if (distance < 1f) { distance = 1f; }
        if (distance > 5) { distance = 5f; }

        #endregion

        #region Camera Rotate

        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X");
            ymove -= Input.GetAxis("Mouse Y");
        }

        transform.rotation = Quaternion.Euler(ymove, xmove, 0);

        Vector3 Eye = player.transform.position + transform.rotation * Player_Side + Player_Height;
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);

        transform.position = Eye - transform.rotation * reverseDistance;

        #endregion

        #region Camera not Pass Object

        //Debug.DrawRay(transform.position, (player.transform.position + new Vector3(0, 1.5f, 0) - maincamera.transform.position).normalized * (distance), Color.blue);

        if (Physics.Raycast(transform.position, (player.transform.position + new Vector3(0, 1.5f, 0) - transform.position).normalized, out hit, distance))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                maincamera.localPosition = Vector3.Lerp(maincamera.localPosition, maincamera.localPosition + Vector3.forward, Time.deltaTime * 10);
                maincamera.position = hit.point;
            }
        }

        #endregion
    }

}
