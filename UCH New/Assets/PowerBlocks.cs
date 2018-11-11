using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlocks : MonoBehaviour {

    public Animator animator;
    public Vector3 respawnPoint;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Jump")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 14);
        }

        if (col.gameObject.tag == "Jump 17")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 19);
        }

        if (col.gameObject.tag == "Respawn")
        {
            transform.position = respawnPoint;
        }

        if (col.gameObject.tag == "Checkpoint")
        {
            respawnPoint = col.transform.position;
        }

        if (col.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }

    }
}
