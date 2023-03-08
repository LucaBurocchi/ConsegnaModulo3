using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{
    public Transform pointA; // Riferimento al punto A della piattaforma
    public Transform pointB; // Riferimento al punto B della piattaforma
    public float speed; // Velocità di movimento della piattaforma
    private bool isMoving; // Flag per controllare se la piattaforma deve essere in movimento
    private bool isPlayerOn; // Flag per controllare se il player è sulla pedana

    private void FixedUpdate()
    {
        if (isMoving) // Se la piattaforma deve muoversi
        {
            // Muovi la piattaforma verso il punto B
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.fixedDeltaTime);

            // Se la piattaforma raggiunge il punto B, scambia i riferimenti tra i punti A e B
            if (transform.position == pointB.position)
            {
                Vector3 temp = pointA.position;
                pointA.position = pointB.position;
                pointB.position = temp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box")) // Se il player o la box entra nella zona di trigger della pedana
        {
            isPlayerOn = true; // Imposta il flag isPlayerOn a true
            isMoving = true; // Imposta il flag isMoving a true per far muovere la piattaforma
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Se il player lascia la pedana
        {
            isPlayerOn = false; // Imposta il flag isPlayerOn a false
        }

        if (!isPlayerOn) // Se non ci sono più player sulla pedana
        {
            isMoving = false; // Imposta il flag isMoving a false per fermare la piattaforma
        }
    }
}
