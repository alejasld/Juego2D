using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;

    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Panel Final")]
    public PanelFinal panelFinal;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Bandera de la primera escena
        if (other.CompareTag("Finish1") && currentScene == "Escena1")
        {
            SceneManager.LoadScene("Escena2");
        }

        // Bandera de la segunda escena
        else if (other.CompareTag("Finish2") && currentScene == "Escena2")
        {
            if (panelFinal != null)
            {
                panelFinal.ShowFinalPanel(
                    GameManager.Instance.ScoreApple,
                    GameManager.Instance.ScoreBanana,
                    GameManager.Instance.GlobalTime
                );
            }

            Time.timeScale = 0f;
        }
    }
}
