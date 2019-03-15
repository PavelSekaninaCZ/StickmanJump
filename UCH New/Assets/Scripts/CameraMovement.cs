using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Vector3 cameraPosition = Vector3.zero;
    public Transform target;

    void FixedUpdate()
    {

        cameraPosition = new Vector3(
                        Mathf.SmoothStep(transform.position.x, target.transform.position.x, 0.9f),
                        Mathf.SmoothStep(transform.position.y, target.transform.position.y, 0.2f));

    }

    void LateUpdate()
    {

        transform.position = cameraPosition + Vector3.forward * -1;

    }

}
