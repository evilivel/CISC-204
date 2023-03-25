using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 4.5f;
    public float jumpForce =12.0f;

    private Rigidbody2D body;
    private BoxCollider2D box;
    private Animator anim;

    void Start() 
    {
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>(); 
        anim = GetComponent<Animator>();

    }

    void Update() 
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = body.velocity.y;

        anim.SetFloat("speed", Mathf.Abs(deltaX));
        anim.SetFloat("jump speed", Mathf.Abs(deltaY));
        
        if (!Mathf.Approximately(deltaX, 0)) 
        {
        transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1); 
        }

        
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }

        anim.SetBool("grounded", grounded);

        body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0)) ? 0 : 1; 

        if (grounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
