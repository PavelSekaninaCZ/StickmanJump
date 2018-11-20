using System.Collections.Generic;
using UnityEngine;

public class JumpS : MonoBehaviour
{

    public float jumpHeight;
    public Animator animator;
    public bool grounded;



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            animator.SetBool("IsJumping", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
            animator.SetBool("IsJumping", true);

        }
    }

}
