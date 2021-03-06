﻿using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private Jump player1;

    void Start()
    {
        player1 = gameObject.GetComponentInParent<Jump>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player1.grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player1.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player1.grounded = false;
    }
}
