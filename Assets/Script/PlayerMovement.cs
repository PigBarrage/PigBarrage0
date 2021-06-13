using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
	public Rigidbody2D rb;
	public Transform resetCheck;
	public LayerMask whatIsGround;
    public LayerMask whatIsResetArea;
    public Transform resetPoint;

    public bool onReset;
    public float resetCheckRadius = 1.5f;

    public float runSpeed = 40f;
    private float horizontalMove = 0;
    private float verticalMove = 0;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onReset = Physics2D.OverlapCircle(resetCheck.position, 	
        resetCheckRadius, whatIsResetArea);

        if(checkReset()) return;


        checkJump();
        checkMove();
    }

    void checkMove()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void FixedUpdate ()
    {
        bool chrouch = verticalMove < -0.5;
        controller.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, chrouch, jump);
        jump = false;
    }

    bool checkReset()
    {
        if(onReset)
        {
            rb.position = resetPoint.position;
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0f;
            rb.transform.rotation = Quaternion.identity;
            return true;
        }
        return false;
    }

    void checkJump()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            if(rb.velocity.y < 2) 
            {
                jump = true;
            }
        }
    }
}
