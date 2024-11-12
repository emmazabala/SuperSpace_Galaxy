using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] public float fallDelay = 0.5f;
    [SerializeField] public float destroyDelay = 1f;
    [SerializeField] public float regenDelay = 3.5f;
    private bool falling = false;
    public float Speed = 4f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] public BoxCollider2D block;
    Vector2 initialPos;
    Vector2 fallPos;

    void Start()
    {
        initialPos = transform.position;
        fallPos = new Vector2(initialPos.x, -8f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (falling)
            return;
        if (col.transform.tag == "Player")
        {
            StartCoroutine(StartFall());
        }
    }
    private IEnumerator StartFall()
    {
        falling = true;

        yield return new WaitForSeconds(fallDelay);

        //rb.bodyType = RigidbodyType2D.Dynamic;

        transform.position = Vector2.MoveTowards(transform.position, fallPos, Speed);
        block.enabled = false;
        StartCoroutine(StartRegen());

        //wait to hide 
        //disable Renderer and collider
        //move plataform
        //Wait to spawn
    }
    private IEnumerator StartRegen()
    {
        StopCoroutine(StartFall());
        falling = false;

        yield return new WaitForSeconds(regenDelay);
        //rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = initialPos;
        block.enabled = true;


    }
}