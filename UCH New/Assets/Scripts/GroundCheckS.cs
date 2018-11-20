using System.Collections;
using UnityEngine;

public class GroundCheckS : MonoBehaviour
{

    private JumpS player;


    void Start()
    {
        player = gameObject.GetComponentInParent<JumpS>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}
