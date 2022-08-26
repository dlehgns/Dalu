using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControll : MonoBehaviour
{
    private PhotonView pv;
    private Animator animator;
    private Rigidbody rigid;

    public float movementSpeed = 2f;
    public float rotationSpeed;
    public float jumpPower = 1f;

    public Transform mainCamera;

    float h, v;

    float animationtime = 0;

    public bool isRun;
    private bool isJump;

    private void Start()
    {
        movementSpeed = 2f;
        animationtime = 0;
        pv = GetComponent<PhotonView>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pv.IsMine)
        { 
            Move();
            Jump();
        }


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
        //if (isJump) { return; }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 lookForward = new Vector3(mainCamera.forward.x, 0, mainCamera.forward.z).normalized;
            Vector3 lookRight = new Vector3(mainCamera.right.x, 0, mainCamera.right.z).normalized;
            Vector3 moveDir = lookForward * v + lookRight * h;

            //transform.forward = moveDir;
            rigid.MovePosition(moveDir);
            rigid.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.3f));

            if (Input.GetKey(KeyCode.LeftShift)) // ¶Ù±â
            {
                AnimationControll(5);
                transform.position += moveDir * Time.deltaTime * movementSpeed * 2;
            }
            else
            {
                AnimationControll(3);
                transform.position += moveDir * Time.deltaTime * movementSpeed;
            }
        }
        else
        {
            AnimationControll(1f);
        }
    }

    public void AnimationControll(float times)
    {
        animationtime = Mathf.SmoothStep(animationtime, times, Time.deltaTime * 50);

        animator.SetFloat("MoveState", animationtime);
    }

    public void Jump()
    {
        if (isJump) { return; }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(2);
            //rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            rigid.velocity += jumpPower * Vector3.up;

            isJump = true;

            Invoke("JumpLimit", 1.0f);
        }
    }

    public void JumpLimit()
    {
        isJump = false;
    }

}
