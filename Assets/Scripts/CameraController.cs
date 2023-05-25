using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x - 1f, transform.position.y, transform.position.z);
    }
}
