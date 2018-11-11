using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private PhotonView PhotonView;

    public float jumpHeight;
    public Animator animator;
    public bool grounded;

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (PhotonView.isMine)
            CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            animator.SetBool("IsJumping", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
            animator.SetBool("IsJumping", true);

        }
    }
}
