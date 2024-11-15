using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour
{
    public List<Activator> activators = new List<Activator>();

    public PlayerTriggered playerTriggered;

    public delegate void PlayerTriggered();

    public void SetAcctivation()
    {
        foreach (var activator in activators)
        {
            activator.gameObject.SetActive(activator.activate);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        SetAcctivation();
        playerTriggered?.Invoke();
    }
}

[System.Serializable]
public class Activator
{
    public GameObject gameObject;
    public bool activate;
}