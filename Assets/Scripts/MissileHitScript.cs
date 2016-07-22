using UnityEngine;
using System.Collections;

public class MissileHitScript : MonoBehaviour {
    public float weaponDamage;
    MissileController missileController;
    public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
        missileController = GetComponentInParent<MissileController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2d(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            missileController.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            missileController.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
