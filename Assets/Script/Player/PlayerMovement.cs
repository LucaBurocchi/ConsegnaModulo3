using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movimento di base
    private float horizontal; // Input orizzontale del giocatore
    private float speed = 8f; // Velocità di movimento del personaggio
    private float jumpingPower = 16f; // Forza del salto del personaggio
    private bool isFacingRight = true; // Indica se il personaggio sta guardando verso destra

    // Dash
    private bool canDash = true; // Indica se il personaggio può effettuare un dash
    private bool isDashing; // Indica se il personaggio sta effettuando un dash
    private float dashingPower = 24f; // Forza del dash
    private float dashingTime = 0.2f; // Durata del dash
    private float dashingCooldown = 1f; // Tempo di cooldown del dash

    // Doppio salto
    private bool doubleJump; // Indica se il personaggio può effettuare un doppio salto

    // Componenti del personaggio
    public Rigidbody2D rb; // Rigidbody2D del personaggio
    public Transform groundCheck; // Posizione da cui controllare se il personaggio è a terra
    public LayerMask groundLayer; // Livello del terreno su cui il personaggio può camminare
    public TrailRenderer tr; // Effetto del trail del dash

    private void Update()
    {
        if (isDashing)
        {
            return; // Se il personaggio sta effettuando un dash, esce dall'Update
        }

        // Movimento orizzontale
        horizontal = Input.GetAxis("Horizontal"); // Prende l'input orizzontale del giocatore

        // Salto
        if (IsGrounded() && !Input.GetButton("Jump")) // Controlla se il personaggio è a terra e il tasto di salto non è premuto
        {
            doubleJump = false; // Resetta la possibilità di effettuare un doppio salto
        }

        if (Input.GetButtonDown("Jump")) // Controlla se il tasto di salto è stato premuto
        {
            if (IsGrounded() || doubleJump) // Controlla se il personaggio è a terra o può effettuare un doppio salto
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // Applica una forza di salto al personaggio

                doubleJump = !doubleJump; // Imposta la possibilità di effettuare un doppio salto in base allo stato precedente
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) // Controlla se il tasto di salto è stato rilasciato e il personaggio sta ancora salendo
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // Riduce la velocità verticale del personaggio
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) // Controlla se il tasto di dash è stato premuto e il personaggio può effettuare un dash
        {
            StartCoroutine(Dash()); // Avvia la coroutine per il dash
        }

        Flip(); // Gira il personaggio se necessario
    }



    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        // Imposta la velocità dell'oggetto in base all'input orizzontale e alla velocità massima.
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Restituisce true se l'oggetto è a contatto con il terreno, altrimenti false.
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Inverte la scala dell'oggetto (ovvero lo gira) se l'oggetto sta guardando a destra ma l'input orizzontale è negativo (ovvero va a sinistra), o se l'oggetto sta guardando a sinistra ma l'input orizzontale è positivo (ovvero va a destra).
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        // Imposta la capacità di dash dell'oggetto a false (ovvero non può dashare).
        canDash = false;
        // Imposta la variabile isDashing a true.
        isDashing = true;
        // Salva il valore della gravità originale dell'oggetto e la imposta a 0.
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        // Imposta la velocità dell'oggetto in modo che dashi nella direzione in cui sta guardando, con una forza dashingPower.
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        // Attiva gli effetti speciali per il dash.
        tr.emitting = true;
        // Aspetta per un certo periodo di tempo (dashingTime).
        yield return new WaitForSeconds(dashingTime);
        // Disattiva gli effetti speciali per il dash.
        tr.emitting = false;
        // Ripristina il valore originale della gravità dell'oggetto.
        rb.gravityScale = originalGravity;
        // Imposta la variabile isDashing a false.
        isDashing = false;
        // Aspetta per un certo periodo di tempo (dashingCooldown).
        yield return new WaitForSeconds(dashingCooldown);
        // Imposta la capacità di dash dell'oggetto a true (ovvero può dashare di nuovo).
        canDash = true;
    }
}