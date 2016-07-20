using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float maxSpeed;
    Rigidbody2D rigidBody;
    Animator animator;
    bool facingRight;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        facingRight = true;
	}

    void flip()
    {
        //flip graphic
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* android code
        * Touch t = Input.GetTouch(0);

       if (t.phase==TouchPhase.Began
           && !facingRight)//D button , forward
       {
           flip();
       }
       else if (t.phase==TouchPhase.Moved
           && facingRight)//A button backwards
       {
           flip();
       }
       */

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));


            rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y*1);


            if (move > 0&& !facingRight)//D button , forward
            {
                flip();
            }
            else if (move < 0&& facingRight)//A button backwards
            {
                flip();
            }
        }
        
    
}
