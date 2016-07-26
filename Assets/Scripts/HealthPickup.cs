using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
    public float healthAmt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEntered2d(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>();
            theHealth.addHealth(healthAmt);
            Destroy(gameObject);
        }
    }
}
