using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAreaScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CinemachineVirtualCamera myVirtualCamera;
    private Transform watchPoint;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        watchPoint = gameObject.transform.GetChild(0);
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            //objetoDeCamara.Transform.Position = objetoDeWatchPoint.Transform.Position
            myVirtualCamera.m_Follow = watchPoint;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            //objetoDeCamara.Transform.Position = objetoDeJugador.Transform.Position
            myVirtualCamera.m_Follow = playerTransform;
    }
}