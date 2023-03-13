using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedagliaUI : MonoBehaviour
{
    public Text medaglieText; // Riferimento al componente Text della UI

    // Update is called once per frame
    void Update()
    {
        medaglieText.text = "Medaglie: " + Medaglia.numMedaglieRaccolte.ToString(); // Aggiorna il testo della UI con il numero di medaglie raccolte
    }
}
