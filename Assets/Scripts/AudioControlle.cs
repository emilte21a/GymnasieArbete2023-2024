using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlle : MonoBehaviour
{
    [Header("Audio")]
    public Transform monsterPosition;
    public AudioSource audioSource;

    float distance;

    private bool isWithinDistance;

    /*
    Ray ray;

    private float maxDistance = 90;

    public LayerMask layerMask;

    private void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }
    */
    void Update()
    {
        distance = Vector3.Distance(monsterPosition.position, transform.position);

        //if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        //{

            if (!isWithinDistance && distance < 40f)
            {
                isWithinDistance = true;
                audioSource.Play();
            }

            if (isWithinDistance && distance > 40f)
            {
                isWithinDistance = false;
                audioSource.Stop();
            }

        //}
    }
}
