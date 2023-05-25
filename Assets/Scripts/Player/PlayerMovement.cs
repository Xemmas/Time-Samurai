using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    Vector2 movementDirection;
    Vector2 mousePos;
    public Camera cam;
    
    float distance = 60;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {   
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position=new Vector2(transform.position.x,transform.position.y - distance); 
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position=new Vector2(transform.position.x,transform.position.y + distance); 
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Shoot");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Melee");
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            animator.SetBool("Move", true);
        }

        else 
        {
            animator.SetBool("Move", false);
        }

    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * moveSpeed;
    }
}
