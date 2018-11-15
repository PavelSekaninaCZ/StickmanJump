using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 TargetPosition;

    private PhotonView PhotonView;

    public CharacterController2D controller;
    public Animator animator;
    public GameObject playerCamera;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    public bool jump { get; private set; }

    public bool UseTransformView = true;
    private Animator m_animator;

    private void SmoothMove()
    {
        if (UseTransformView)
            return;

        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.25f);
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        PhotonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (PhotonView.isMine)
            CheckInput();

        else

            SmoothMove();

        if (PhotonView.isMine)
        {
            playerCamera.SetActive(true);
        }
        else
        {
            playerCamera.SetActive(false);
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (UseTransformView)
            return;


        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            TargetPosition = (Vector3)stream.ReceiveNext();
        }
    }

    private void CheckInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown("space"))
        {
            jump = true;
        }

        m_animator.GetFloat("Input, vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            m_animator.SetTrigger("Taunt");
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    

}
