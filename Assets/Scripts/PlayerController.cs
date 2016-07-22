using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float maxSpeed;
    Rigidbody2D rigidBody;
    Animator animator;
    bool facingRight;

    //jump code start
    bool isGrounded;
    float groundCheckRadius;
    public LayerMask groundLayer;
    public Transform groundCheckTransform;
    public float jumpHeight;

    //jump code end

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        facingRight = true;

        //jump code start
        isGrounded = false;
        groundCheckRadius = 0.2f;
        //jump code end
	}
    void Update()
    {
        //start jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
            rigidBody.AddForce(new Vector2(0, jumpHeight));
        }
        //end jump code
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));//change animation 


            rigidBody.velocity = new Vector2(100*20, rigidBody.velocity.y);

            if (move > 0&& !facingRight)//D button , forward
            {
                flip();
            }
            else if (move < 0&& facingRight)//A button backwards
            {
                flip();
            }


        //start jump code
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius,groundLayer); //parameter the pt at which to draw,radius,layer
        animator.SetBool("isGrounded", isGrounded);
        //the real jumping code
        animator.SetFloat("verticalSpeed", rigidBody.velocity.y);

        //end jump code

        
    }
    
    void flip()
    {
        //flip graphic
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;

    }
}
