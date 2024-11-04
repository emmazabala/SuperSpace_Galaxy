using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform Transform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject obj = GameObject.Find("Checkpoint");
            if (obj != null)
            {
                obj.transform.position = Transform.position;
            }
        }
    }
}
