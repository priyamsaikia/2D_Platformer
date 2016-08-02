using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
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
    //shoot missile code start
    public Transform gunTip;
    public GameObject missile;
    public float fireRate;
    float nextFirePeriod = 0;
    //shoot missile code end

    //touch start code
    private Vector2 touchOrigin = -Vector2.one;
    //touch end code



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
        if (isGrounded && CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
            rigidBody.AddForce(new Vector2(0, jumpHeight));
        }
        //end jump code

        //shoot missile code start
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            fireMissile();
        }
        //shoot missile code end


            }
    // Update is called once per frame
    void FixedUpdate()
    {
     
        float move = CrossPlatformInputManager.GetAxis("Horizontal");

        //touch start code
      /*  if (CrossPlatformInputManager.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                //if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    move = x > 0 ? 1 : -1;
                }

            }
        }*/

        animator.SetFloat("speed", Mathf.Abs(move));//change animation 


            rigidBody.velocity = new Vector2(move*maxSpeed, rigidBody.velocity.y);


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

    void fireMissile()
    {
        if (Time.time > nextFirePeriod)
        {
            nextFirePeriod = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(missile, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(missile, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
