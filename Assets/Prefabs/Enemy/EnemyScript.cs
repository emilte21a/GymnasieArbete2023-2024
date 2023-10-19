using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public Rigidbody rb;

    private void Start()
    {
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        rb.MovePosition(pos);

        if (target != null)
        {
            transform.LookAt(target);
        }


    }
}
