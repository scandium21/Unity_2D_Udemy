using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // config parameters
    //[Header("")]
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float ClimbSpeed = 5f;

    // state
    bool isAlive = true;

    // cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myCollider;
    float gravityScaleAtStart;
    
    // Message then methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
    }

    private void Run()
    {
        // value is between -1 to +1
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); 
        Vector2 playerRunVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerRunVelocity;

        // set animation to running
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);    
    }

    private void Jump()
    {
        // prevent multi-jumps
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;  }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd; 

        }
    }

    private void ClimbLadder()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        } 

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 playerClimbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * ClimbSpeed);
        myRigidBody.velocity = playerClimbVelocity;
        myRigidBody.gravityScale = 0f;


        // set animation to running
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void FlipSprite()
    {
        // if the player is moving horizontally
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            // reverse the current x scale
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), transform.localScale.y);
        }
    }
}
