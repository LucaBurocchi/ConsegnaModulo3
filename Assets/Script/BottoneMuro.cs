using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottoneMuro : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.SendMessage("il muro si sposta");
        }
    }

    float muro;
    

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            muro = DestroyImmediate;
        }
    }

    int bumpCount;
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DodgemCar")
        {
            bumpCount++;
        }
    }
}


