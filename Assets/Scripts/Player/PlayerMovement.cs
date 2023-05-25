using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float dashSpeed = 15.0f;
    public float dashTime = 0.2f;
    public float dashCooldown = 2.0f;
    private float nextDash = 0.0f;
    private bool isDashing = false; 
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    
    float distance = 60;

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position=new Vector2(transform.position.x,transform.position.y - distance); 
            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position=new Vector2(transform.position.x,transform.position.y + distance); 
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time > nextDash)
    {
        StartCoroutine(Dash());
        GetComponent<PlayerHealth>().AreaAttack(); // perform the area attack
        nextDash = Time.time + dashCooldown; // update the nextDash time
    }

    
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;   
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = angle;
        }
    }

     IEnumerator Dash()
{
    float startTime = Time.time;

    // Get direction vector towards the mouse cursor
    Vector2 direction = (mousePos - rb.position).normalized;

    isDashing = true;
    
    while (Time.time < startTime + dashTime)
    {
        rb.velocity = direction * dashSpeed;
        yield return null; 
    }

    isDashing = false;
}

}
