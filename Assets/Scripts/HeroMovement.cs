using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 500f; // Agrega una variable para controlar la fuerza del salto

    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = true; // Para rastrear si el personaje est� en el suelo

    private bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y); // Mant�n la velocidad vertical constante

        // Cambiar la direcci�n del personaje
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(6.7f, 6.7f, 6.7f); // Sin inversi�n
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-6.7f, 6.7f, 6.7f); // Inversi�n horizontal
        }

        // Actualizar la animaci�n de movimiento
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        // Saltar cuando se presiona la tecla "Space" y el personaje est� en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            isFalling = false;
            animator.SetBool("Caida", isFalling);
            isGrounded = false; // El personaje no est� en el suelo despu�s de saltar
        }

        if ((rb.velocity.y < 0) && !isFalling)
        {
            animator.SetBool("Jump", false);
            isFalling = true;
            animator.SetBool("Caida", isFalling);
        }
        if (isGrounded)
        {
            isFalling = false;
            animator.SetBool("Jump", false);
            animator.SetBool("Caida", isFalling);
        }
    }

    // Detectar si el personaje est� en el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
