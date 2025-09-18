using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    private Animator animator;

    float horizontal;
    public float speed = 5f;
    public float jumpForce = 3f;
    private bool isGrounded;

    [Header("Escena a cargar cuando toca la bandera")]
    public string nextSceneName; // ← Nombre de la siguiente escena

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        float currentSpeed = Mathf.Abs(_Rigidbody2D.linearVelocity.x);
        animator.SetFloat("Speed", currentSpeed);

        // Saltar
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            _Rigidbody2D.linearVelocity = new Vector2(_Rigidbody2D.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true); // Activar animación de salto
        }

        // Si está en el suelo, desactivar animación de salto
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        _Rigidbody2D.linearVelocity = new Vector2(horizontal * speed, _Rigidbody2D.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            // Cargar la escena indicada en el Inspector
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("No se asignó ninguna escena en 'nextSceneName'");
            }
        }
    }
}
