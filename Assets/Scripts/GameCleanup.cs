using UnityEngine;
using System.Collections;

public class GameCleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth playerFall = other.GetComponent<playerHealth>();
            playerFall.makeDead();
        }else
        {
            Destroy(other.gameObject);
        }
    }
}
