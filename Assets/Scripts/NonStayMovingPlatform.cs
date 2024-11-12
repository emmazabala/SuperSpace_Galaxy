using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStayMovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector2 targetPos;
    void Start()
    {
        targetPos = posB.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
    }

}
