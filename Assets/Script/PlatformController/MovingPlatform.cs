using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // punto di partenza
    public Transform pointB; // punto di arrivo
    public float speed; // velocità di movimento della piattaforma
    private bool isMoving; // indica se la piattaforma è in movimento
    private int movingDirection = 1; // indica la direzione del movimento
    private int currentTargetPoint = 0; // indica il punto di destinazione corrente
    private GameObject player; // riferimento al GameObject Player
    private GameObject box; // riferimento al GameObject Box
                            // Metodo chiamato all'avvio del gioco
    private void Start()
    {
        // Assegniamo ai riferimenti "player" e "box" i GameObject corrispondenti tramite il loro tag
        player = GameObject.FindGameObjectWithTag("Player");
        box = GameObject.FindGameObjectWithTag("Box");
    }

    // Metodo chiamato a intervalli di tempo costanti, indipendentemente dalle prestazioni del computer
    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Calcoliamo la nuova posizione della piattaforma in base alla velocità e alla direzione di movimento
            Vector3 newPosition = transform.position + (movingDirection * speed * Time.fixedDeltaTime * Vector3.right);

            // Controlliamo se la piattaforma ha raggiunto il punto di destinazione corrente
            if (movingDirection > 0 && newPosition.x >= pointB.position.x || movingDirection < 0 && newPosition.x <= pointA.position.x)
            {
                // Invertiamo la direzione di movimento
                movingDirection *= -1;

                // Impostiamo il nuovo punto di destinazione corrente
                currentTargetPoint = currentTargetPoint == 0 ? 1 : 0;
            }

            // Spostiamo la piattaforma nella nuova posizione
            transform.position = newPosition;
        }
    }

    // Metodo chiamato quando un GameObject entra nella zona di attivazione della piattaforma
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Controlliamo se il GameObject che entra in collisione ha il tag "Player" o "Box"
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            Debug.Log("Player/Box entrato nella zona di attivazione della piattaforma");

            // Se la piattaforma non è in movimento, inizia il movimento
            if (!isMoving)
            {
                Debug.Log("La piattaforma inizia il movimento");

                isMoving = true;
            }
        }
    }

    // Metodo chiamato quando un GameObject esce dalla zona di attivazione della piattaforma
    private void OnTriggerExit2D(Collider2D other)
    {
        // Controlliamo se il GameObject che esce dalla collisione ha il tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player uscito dalla zona di attivazione della piattaforma");

            // Se il player e la box non sono più sopra la pedana, la piattaforma si ferma
            if (!box.activeSelf && !player.activeSelf)
            {
                Debug.Log("La piattaforma si ferma");

                isMoving = false;
            }
        }
    }
}