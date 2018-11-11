using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private Jump player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Jump>();
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
