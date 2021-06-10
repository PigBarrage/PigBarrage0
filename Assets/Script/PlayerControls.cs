using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public Rigidbody2D rb;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
    public LayerMask whatIsResetArea;
    public Transform resetPoint;

    public bool onReset;
	public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = new Vector2(3, rb.velocity.y);
         onReset = Physics2D.OverlapCircle(groundCheck.position, 	
         groundCheckRadius, whatIsResetArea);
         if(onReset)
         {
             rb.position = resetPoint.position;
             rb.velocity = new Vector2(0, 0);
             rb.angularVelocity = 0f;
             transform.rotation = Quaternion.identity;
         }
         onGround = Physics2D.OverlapCircle(groundCheck.position, 	
         groundCheckRadius, whatIsGround);        
         if (Input.GetMouseButtonDown(0) && onGround) {
                 rb.velocity = new Vector2(rb.velocity.x, 6);
                 }
        
    }
}
