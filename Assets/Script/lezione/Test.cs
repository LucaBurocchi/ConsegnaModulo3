using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour

{
    // variabili
    //int = nr intero
    [SerializeField] int day = 9;
    // float = nr con virgola
    float myFloat = 4.5f;
    // bool = valore che definisce vero o falso
    bool myBool = true;
    // string = 
    string myString = "aaaaa";

    public LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // roba indipendente dal frame rate
    private void FixedUpdate()
    {
        
    }

    // quando collidi con qualcosa, corporeo
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    // detecta collisione ma incorporeo
    private void OnTriggerEnter(Collider other)
    {
        
    }


    void LogDay()
    {
        Debug.Log($"Oggi è il giorno {day} febbraio");

    }
}
