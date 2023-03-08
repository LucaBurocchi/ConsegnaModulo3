using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // GameObject per il muro da creare
    public GameObject wallPrefab;

    // Flag che indica se il muro è stato creato o distrutto
    private bool isWallCreated = false;

    // Riferimento all'istanza del muro
    private GameObject wallInstance;

    // Metodo per creare il muro
    private void CreateWall()
    {
        // Crea l'istanza del muro a partire dal prefab e la posiziona nella posizione corrente del GameObject
        wallInstance = Instantiate(wallPrefab, transform.position, transform.rotation);
        // Imposta il flag a true per indicare che il muro è stato creato
        isWallCreated = true;
    }

    // Metodo per distruggere il muro
    public void DestroyWall()
    {
        // Distrugge l'istanza del muro
        Destroy(wallInstance);
        // Imposta il flag a false per indicare che il muro è stato distrutto
        isWallCreated = false;
    }

    // Metodo per gestire l'interazione con il bottone
    public void ButtonInteraction()
    {
        if (isWallCreated)
        {
            // Se il muro è già stato creato, distruggilo
            DestroyWall();
        }
        else
        {
            // Se il muro non è stato ancora creato, crealo
            CreateWall();
        }
    }
}
