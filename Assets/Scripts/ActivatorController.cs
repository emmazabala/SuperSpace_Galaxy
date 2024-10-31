using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour
{
    public List<Activator> activators = new List<Activator>();

    public void SetAcctivation() {
        foreach (var activator in activators) { 
            activator.gameObject.SetActive(activator.activate);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        SetAcctivation();
    }
}

[System.Serializable]
public class Activator{
    public GameObject gameObject;
    public bool activate;
}
