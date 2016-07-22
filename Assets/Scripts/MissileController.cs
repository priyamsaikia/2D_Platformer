using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {
    Rigidbody2D rigidBody;
    public float rocketSpeed;
	// Use this for initialization
	void Awake () {
        rigidBody = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
          rigidBody.AddForce(new Vector2(-1, 0) * rocketSpeed,ForceMode2D.Force);
        else
            rigidBody.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Force);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void removeForce()
    {
        rigidBody.velocity = new Vector2(0, 0);
    }
}
