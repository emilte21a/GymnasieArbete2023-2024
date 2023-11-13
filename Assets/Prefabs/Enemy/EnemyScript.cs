using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform rayShooter;

    public Transform enemyTarget;
    public float speed = 2f;
    public Rigidbody rb;

    public Animator animator;

    Ray ray;

    RaycastHit hit;

    private float maxDistance = 120;

    public LayerMask layerMask;

    private bool shouldMove;


    private void Start()
    {
        rb.freezeRotation = true;
        shouldMove = true;
        animator.SetBool("ShouldMove", true);
    }


    Vector3 pos;
    void Update()
    {
        ray = new Ray(rayShooter.position, rayShooter.forward);
        Debug.DrawRay(rayShooter.position, rayShooter.forward * 50f, Color.red, 0.1f);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.tag != "Monster")
            {
                shouldMove = true;
                animator.SetBool("ShouldMove", true);
            }

            else
            {
                shouldMove = false;
                animator.SetBool("ShouldMove", false);
            }
        }

        if (shouldMove)
            pos = Vector3.MoveTowards(transform.position, rayShooter.position, speed * Time.deltaTime);

        else
            pos = transform.position;

        rb.MovePosition(pos);


        if (rayShooter != null)
        {
            transform.LookAt(enemyTarget);
        }
    }
}
