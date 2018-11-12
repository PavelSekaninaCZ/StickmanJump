using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlaye : MonoBehaviour
{

    public Vector3 respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            transform.position = respawnPoint;
        }

        if (other.gameObject.tag == "Odvaha")
        {
            respawnPoint = other.transform.position;
        }
    }
}
