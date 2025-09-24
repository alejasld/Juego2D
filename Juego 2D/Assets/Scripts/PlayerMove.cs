using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator animator;

    float horizontal;
    public float speed = 3f;
    public float jumpForce = 3f;
    private bool isGrounded;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        float currentSpeed = Mathf.Abs(_rigidbody2D.linearVelocity.x);
        animator.SetFloat("Speed", currentSpeed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }

        if (isGrounded)
            animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2(horizontal * speed, _rigidbody2D.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Escena1")
            {
                // Destruir jugador de Escena1
                Destroy(gameObject);
                // Cargar Escena2 donde habrá un nuevo jugador
                SceneManager.LoadScene("Escena2");
            }
            else if (currentScene == "Escena2")
            {
                SceneManager.LoadScene("Final");
            }
        }
    }
}
