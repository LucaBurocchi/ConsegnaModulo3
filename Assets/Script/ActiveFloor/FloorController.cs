using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject wall; // Riferimento all'oggetto "wall" da disattivare/attivare
    private int playerCount = 0; // Contatore del numero di player sulla pedana

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Controlla se il collider dell'oggetto entrante è quello del player o della box
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            // Incrementa il contatore del numero di player o box sulla pedana
            playerCount++;

            // Disattiva l'oggetto "wall"
            wall.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Controlla se il collider dell'oggetto uscente è quello del player o della box
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            // Decrementa il contatore del numero di player o box sulla pedana
            playerCount--;

            // Se non ci sono più player o box sulla pedana, attiva l'oggetto "wall"
            if (playerCount == 0)
            {
                wall.SetActive(false);
            }
        }
    }
}
