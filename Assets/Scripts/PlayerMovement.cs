using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    
    float distance = 60;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position=new Vector2(transform.position.x,transform.position.y - distance); 
            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position=new Vector2(transform.position.x,transform.position.y + distance); 
        }

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;   
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = angle;
    }
}
