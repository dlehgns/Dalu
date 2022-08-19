using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private PhotonView pv;
    private CharacterController controller;
    private Animator animator;
    public float movementSpeed = 2f;
    public float rotationSpeed;

    public Transform mainCamera;

    private Vector3 MoveDir;

    private float Gravity;

    float h, v;

    float animationtime = 0;

    public bool isRun;

    private void Start()
    {
        movementSpeed = 2f;
        animationtime = 0;
        pv = GetComponent<PhotonView>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pv.IsMine)
        { Move(); }


        if (pv.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.T))
            { animator.SetTrigger("Hi"); }
            if (Input.GetMouseButtonDown(0))
            { animator.SetTrigger("Punch"); }
        }
    }

    public void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 lookForward = new Vector3(mainCamera.forward.x, 0, mainCamera.forward.z).normalized;
            Vector3 lookright = new Vector3(mainCamera.right.x, 0, mainCamera.right.z).normalized;
            Vector3 moveDir = lookForward * v + lookright * h;

            transform.forward = moveDir;


            if (Input.GetKey(KeyCode.LeftShift)) // ¶Ù±â
            {
                Motion(5);
                transform.position += moveDir * Time.deltaTime * movementSpeed * 2;
            }
            else
            {
                Motion(3);
                transform.position += moveDir * Time.deltaTime * movementSpeed;
            }
        }
        else
        {
            Motion(1f);
        }
    }

    public void Motion(float times)
    {
        animationtime = Mathf.SmoothStep(animationtime, times, Time.deltaTime * 50);

        animator.SetFloat("MoveState", animationtime);
    }
}
