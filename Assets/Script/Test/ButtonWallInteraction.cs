using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWallInteraction : MonoBehaviour
{
    public GameObject wallToCreate;
    public float buttonPressThreshold = 1f;

    private bool isPlayerOnButton = false;
    private WallController wallController;

    private void Start()
    {
        // Ottieni il riferimento allo script del muro
        wallController = wallToCreate.GetComponent<WallController>();
    }

    private void Update()
    {
        if (isPlayerOnButton)
        {
            // Se il player è sopra il bottone, distruggi il muro
            wallController.DestroyWall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = false;
        }
    }
}
