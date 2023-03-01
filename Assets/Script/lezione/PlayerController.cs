using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask groundMask;

    public int score = 0;

    bool isGrounded = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        //Polling input
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        //Costruisco il vettore movimento
        Vector3 playerMovement = (Vector3.right * xMove + Vector3.forward * zMove).normalized * speed /** Time.deltaTime*/;

        //Applico la mia velocity yverticale al vetore movimento
        //playerMovement.y = rb.velocity.y;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerMovement.y += Mathf.Sqrt(jumpHeight * -2f * (-9.81f));
        }


        //Applico il vettore movimento al rigidbody
        rb.velocity = playerMovement;



        Debug.DrawRay(transform.position, transform.forward * 10, Color.cyan);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, 10, groundMask)) ;
        {
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collectible"))
        {
            score++;
            Debug.Log(score);
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
}
