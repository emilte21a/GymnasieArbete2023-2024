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


    void Update()
    {
        distance = Vector3.Distance(monsterPosition.position, transform.position);



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
