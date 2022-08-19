using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player; // �÷��̾� ����Ʈ. 
    public Transform maincamera; // ī�޶� �ġ
    public float playerHigh;
    public float xmove = 2; // X�� ���� �̵��� 
    public float ymove = 25; // Y�� ���� �̵��� 
    public float distance = 1;
    private float wheelspeed = 10.0f;
    private Vector3 Player_Height;
    private Vector3 Player_Side;

    RaycastHit hit;

    private float firstDistance;

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
        // ���콺 ��Ŭ�� �߿��� ī�޶� ���� ��� 
        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X");
            ymove -= Input.GetAxis("Mouse Y");
        }

        transform.rotation = Quaternion.Euler(ymove, xmove, 0); // �̵����� ��� ī�޶��� �ٶ󺸴� ����� ���մϴ�. 


        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;

        Vector3 Eye = player.transform.position + transform.rotation * Player_Side + Player_Height;
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        // ī�޶� �ٶ󺸴� �չ���� Z ���Դϴ�. �̵����� �� Z ������� ���͸� ���մϴ�. 
        transform.position = Eye - transform.rotation * reverseDistance;

        Debug.DrawRay(transform.position, (player.transform.position + new Vector3(0, 1.5f, 0) - maincamera.transform.position).normalized * (distance), Color.blue);

        if (Physics.Raycast(transform.position, (player.transform.position + new Vector3(0, 1.5f, 0) - transform.position).normalized, out hit, distance))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                maincamera.localPosition = Vector3.Lerp(maincamera.localPosition, maincamera.localPosition + Vector3.forward, Time.deltaTime * 10);
                maincamera.position = hit.point;
            }
        }
        else
        {
        }
    }

    public void CameCon3()
    {
        // ���콺 ��Ŭ�� �߿��� ī�޶� ���� ��� 
        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X");
            ymove -= Input.GetAxis("Mouse Y");
        }

        transform.rotation = Quaternion.Euler(ymove, xmove, 0);
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        transform.position = player.transform.position - transform.rotation * reverseDistance;

        Debug.DrawRay(transform.position, (player.transform.position + new Vector3(0, 1.5f, 0) - maincamera.transform.position).normalized * (distance), Color.blue);

        if (Physics.Raycast(transform.position, (player.transform.position + new Vector3(0, 1.5f, 0) - transform.position).normalized, out hit, distance))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                maincamera.localPosition = Vector3.Lerp(maincamera.localPosition, maincamera.localPosition + Vector3.forward, Time.deltaTime * 10);
                maincamera.position = hit.point;
            }
        }
    }
}
