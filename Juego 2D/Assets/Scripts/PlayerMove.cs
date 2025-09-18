using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D _Rigidbody2D;
    float horizontal;   
    public float speed=5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal=Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {
        _Rigidbody2D.linearVelocity =new Vector2(horizontal*speed, _Rigidbody2D.linearVelocity.y);
    }   
}
