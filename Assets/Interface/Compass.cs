
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using Unity.Mathematics;

public class Follow : MonoBehaviour
{
    public Transform lookAtTarget;
    public Transform gazebo;
    public Transform playerCam;

    Vector3 vector;

    float distance;

    void Update()
    {
        lookAtTarget.transform.LookAt(gazebo);

        distance = Vector3.Distance(gazebo.position, playerCam.position);

        vector.z = playerCam.eulerAngles.y - lookAtTarget.eulerAngles.y;

        transform.eulerAngles = vector;
    }
}