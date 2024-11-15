using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private MaxMovement maxMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("compare al player");
            maxMovement = GameObject.FindObjectOfType<MaxMovement>();
            if (maxMovement != null)
            {
                maxMovement.Kill();
            }
        }
    }
}
