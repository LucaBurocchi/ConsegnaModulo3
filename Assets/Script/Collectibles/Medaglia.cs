using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Medaglia : MonoBehaviour
{
    private static int numMedaglieRaccolte = 0; // Numero di medaglie raccolte

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Se il player raccoglie la medaglia
        {
            Destroy(gameObject); // La medaglia viene distrutta
            numMedaglieRaccolte++; // Aggiorna il numero di medaglie raccolte

            if (numMedaglieRaccolte == 3) // Se il player ha raccolto tutte le medaglie
            {
                SceneManager.LoadScene("FineLivello"); // Cambia scena
            }
        }
    }
}

