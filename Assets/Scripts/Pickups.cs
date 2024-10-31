using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private int _ReplacementCount = 0;
    public int ReplacementLimit = 9;

    private void Update()
    {
        if (_ReplacementCount == ReplacementLimit)
        {
            Debug.Log("Recogiste todos los pickup!!");
        }
        return;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _ReplacementCount++;
            Destroy(gameObject);
        }
    }

}
