using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCreateWallOnButton : MonoBehaviour
{
    // GameObject del bottone con cui interagisce il muro
    public GameObject button;

    // GameObject del muro da distruggere quando il bottone viene premuto
    public GameObject wallToDestroy;

    // GameObject del muro da creare quando il bottone non è premuto
    public GameObject wallToCreate;

    // Flag che indica se il player è sopra il bottone
    private bool isPlayerOnButton = false;

    public bool IsPlayerOnButton { get => isPlayerOnButton; set => isPlayerOnButton = value; }

    // Viene chiamato quando un collider entra nel trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica se il collider che ha attivato l'evento ha il tag "Player"
        if (other.CompareTag("Player"))
        {
            // Imposta il flag a true, indica che il player è sopra il bottone
            IsPlayerOnButton = true;

            // Distrugge il muro da distruggere
            Destroy(wallToDestroy);
        }
    }

    // Viene chiamato quando un collider esce dal trigger
    void OnTriggerExit(Collider other)
    {
        // Verifica se il collider che ha attivato l'evento ha il tag "Player"
        if (other.CompareTag("Player"))
        {
            // Imposta il flag a false, indica che il player non è più sopra il bottone
            IsPlayerOnButton = false;

            // Crea il nuovo muro nella posizione del muro distrutto, con la stessa rotazione
            Instantiate(wallToCreate, wallToDestroy.transform.position, wallToDestroy.transform.rotation);
        }
    }
}

